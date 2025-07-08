// SPDX-FileCopyrightText: 2025 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

using GLTFast.Logging;

#if UNITY_ANIMATION
namespace GLTFast.Documentation.Examples
{
#region CustomGltfImportPlayables
    using System;
    using UnityEngine;

    public class CustomGltfImportPlayables : MonoBehaviour
    {
        public string Uri;

        async void Start()
        {
            try
            {
                var gltfImport = new GltfImport(logger:new ConsoleLogger());
                var instantiator = new CustomGameObjectInstantiator(gltfImport, transform);
                var importSettings = new ImportSettings { AnimationMethod = AnimationMethod.Playables };

                await gltfImport.Load(Uri, importSettings);
                await gltfImport.InstantiateMainSceneAsync(instantiator);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
#endregion
}
#endif
