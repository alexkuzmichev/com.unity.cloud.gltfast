// SPDX-FileCopyrightText: 2025 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

#if UNITY_PERFORMANCE_TESTS

using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using GLTFast.Logging;
using GLTFast.Tests.Import;
using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace GLTFast.Tests
{
    [Category("Performance")]
    class ImportPerformanceTests : IPrebuildSetup
    {
        const int k_Repetitions = 10;

        [UnityTest, Performance]
        public IEnumerator FlatHierarchy()
        {
            yield return AsyncWrapper.WaitForTask(TestWrapper(() => RunTest(
                TestGltfGenerator.FlatHierarchyPath), k_Repetitions)
            );
        }

        [UnityTest, Performance]
        public IEnumerator FlatHierarchyBinary()
        {
            yield return AsyncWrapper.WaitForTask(TestWrapper(() => RunTest(
                    TestGltfGenerator.FlatHierarchyBinaryPath), k_Repetitions)
            );
        }

        [UnityTest, Performance]
        public IEnumerator FlatHierarchyMemory()
        {
            yield return AsyncWrapper.WaitForTask(TestWrapper(() => RunTest(
                    TestGltfGenerator.FlatHierarchyPath, true), k_Repetitions)
            );
        }

        [UnityTest, Performance]
        public IEnumerator BigCylinder()
        {
            yield return AsyncWrapper.WaitForTask(TestWrapper(() => RunTest(
                TestGltfGenerator.BigCylinderPath), k_Repetitions, 3)
            );
        }

        [UnityTest, Performance]
        public IEnumerator BigCylinderBinary()
        {
            yield return AsyncWrapper.WaitForTask(TestWrapper(() => RunTest(
                TestGltfGenerator.BigCylinderBinaryPath), k_Repetitions, 3)
            );
        }

        [UnityTest, Performance]
        public IEnumerator BigCylinderBinaryMemory()
        {
            yield return AsyncWrapper.WaitForTask(TestWrapper(() => RunTest(
                TestGltfGenerator.BigCylinderBinaryPath, true), k_Repetitions, 3)
            );
        }

        public void Setup()
        {
            if (!TestGltfGenerator.CertifyPerformanceTestGltfs())
            {
                throw new InvalidDataException("Performance test glTFs have to be created first!\n" +
                    "See Menu -> Tools -> Create performance test glTFs");
            }
        }

        static async Task RunTest(string path, bool loadFromMemory = false)
        {
            var go = new GameObject();
            var loadLogger = new CollectingLogger();
            Debug.Log($"Loading {path}");

            using var gltf = new GltfImport(logger: loadLogger);

            bool success;
            if (loadFromMemory)
            {
                var data = await LoadTests.ReadAllBytesAsync(path);
                success = await gltf.Load(data, new Uri(path));
            }
            else
            {
                success = await gltf.Load(path);
            }

            if (!success)
            {
                loadLogger.LogAll();
            }
            Assert.IsTrue(success);

            var instantiateLogger = new CollectingLogger();
            var instantiator = AssetsTests.CreateInstantiator(gltf, instantiateLogger, go.transform);
            success = await gltf.InstantiateMainSceneAsync(instantiator);
            if (!success)
            {
                instantiateLogger.LogAll();
                throw new AssertionException("glTF instantiation failed");
            }
            Object.Destroy(go);
        }

        static async Task TestWrapper(Func<Task> action, int repeat, int warmup = 1)
        {
            for (var i = 0; i < warmup; i++)
            {
                await action();
            }

            for (var i = 0; i < repeat; i++)
            {
                using(Measure.Scope())
                {
                    await action();
                }
            }
        }
    }
}
#endif
