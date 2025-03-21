// SPDX-FileCopyrightText: 2025 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections;
using System.Text.RegularExpressions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace GLTFast.Tests.Animation
{
    [Category("Animation")]
    class AnimationTests
    {
        [Test]
        public void AnimationLoopPlayable_WhenAutoSequence_SelectsNextClip()
        {
            var playableGraph = PlayableGraph.Create("PlayableGraph");
            var clips = new[] { new AnimationClip(), new AnimationClip() };

            var scriptPlayable = ScriptPlayable<AnimationLoopPlayable>.Create(playableGraph);
            var animationLoopPlayable = scriptPlayable.GetBehaviour();

            animationLoopPlayable.Init(scriptPlayable, playableGraph, true, clips);
            Assert.AreEqual(1, animationLoopPlayable.Mixer.GetInputWeight(0));
            Assert.AreEqual(0, animationLoopPlayable.Mixer.GetInputWeight(1));

            animationLoopPlayable.PrepareFrame(new Playable(), new FrameData());
            Assert.AreEqual(0, animationLoopPlayable.Mixer.GetInputWeight(0));
            Assert.AreEqual(1, animationLoopPlayable.Mixer.GetInputWeight(1));

            playableGraph.Destroy();
        }

        [Test]
        public void AnimationLoopPlayable_WhenTimeGreaterThanZero_SelectsSameClip()
        {
            var playableGraph = PlayableGraph.Create("PlayableGraph");
            var clips = new[] { new AnimationClip(), new AnimationClip() };

            var scriptPlayable = ScriptPlayable<AnimationLoopPlayable>.Create(playableGraph);
            var animationLoopPlayable = scriptPlayable.GetBehaviour();

            animationLoopPlayable.Init(scriptPlayable, playableGraph, true, clips);
            Assert.AreEqual(1, animationLoopPlayable.Mixer.GetInputWeight(0));
            Assert.AreEqual(0, animationLoopPlayable.Mixer.GetInputWeight(1));

            animationLoopPlayable.Time = 1f;
            animationLoopPlayable.PrepareFrame(new Playable(), new FrameData());
            Assert.AreEqual(1, animationLoopPlayable.Mixer.GetInputWeight(0));
            Assert.AreEqual(0, animationLoopPlayable.Mixer.GetInputWeight(1));

            playableGraph.Destroy();
        }

        [Test]
        public void AnimationPlayableComponent_WhenNullClips_ThrowsArgumentNullException()
        {
            var gameObject = new GameObject("AnimationPlayable");
            var animationPlayableComponent = gameObject.AddComponent<AnimationPlayableComponent>();
            Assert.Catch<ArgumentNullException>(() => animationPlayableComponent.Init(null, false));

            Object.Destroy(gameObject);
        }

        [Test]
        public void AnimationPlayableComponent_WhenEmptyClips_ThrowsArgumentOutOfRangeException()
        {
            var gameObject = new GameObject("AnimationPlayable");
            var animationPlayableComponent = gameObject.AddComponent<AnimationPlayableComponent>();
            Assert.Catch<ArgumentOutOfRangeException>(() => animationPlayableComponent.Init(Array.Empty<AnimationClip>(), false));

            Object.Destroy(gameObject);
        }

        [Test]
        public void AnimationPlayableComponent_WhenInitialized_PlayableIsNotNull()
        {
            var gameObject = new GameObject("AnimationPlayable");
            var animationPlayableComponent = gameObject.AddComponent<AnimationPlayableComponent>();
            animationPlayableComponent.Init(new[] { new AnimationClip() }, false);

            Assert.IsNotNull(animationPlayableComponent.Playable);

            Object.Destroy(gameObject);
        }

        [UnityTest]
        public IEnumerator AnimationPlayableComponent_WhenNotInitialized_FailsAssertion()
        {
            const string format = @"[\s\S]*{0}[\s\S]*";

            LogAssert.Expect(new Regex(string.Format(format, AnimationPlayableComponent.k_NotInitializedMessage)));
            var gameObject = new GameObject("AnimationPlayable");
            gameObject.AddComponent<AnimationPlayableComponent>();
            yield return null;

            LogAssert.Expect(new Regex(string.Format(format, AnimationPlayableComponent.k_InvalidGraphMessage)));
            Object.Destroy(gameObject);
            yield return null;
        }
    }
}
