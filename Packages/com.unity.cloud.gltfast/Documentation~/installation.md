# Installation

## Install the *Unity glTFast* package using the Unity Package Manager

To install the *Unity glTFast* package, follow these steps:

- In your Unity project, go to Windows > Package Manager.
- On the status bar, select the Add (+) button.
- From the Add menu, select Add + package by name. Name and Version fields appear.
- In the Name field, enter `com.unity.cloud.gltfast`.
- Select Add.
- The Editor installs the latest available version of the package and any dependent packages.

## Optional Packages

There are some related package that improve *Unity glTFast* by extending its feature set.

- [Built-in Packages](https://docs.unity3d.com/Manual/pack-build.html)
  - [Unity Web Request Texture](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/UnityEngine.UnityWebRequestTextureModule.html) (and [Image Conversion](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/UnityEngine.ImageConversionModule.html)) for import/export of Jpeg and PNG textures.
  - [Animation](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/UnityEngine.AnimationModule.html) for animation playback.
  - [Physics](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/UnityEngine.PhysicsModule.html) to create a glTF scene's [bounding box collider](xref:UnityEngine.BoxCollider) via [GltfBoundsAsset](xref:GLTFast.GltfBoundsAsset).
- [Draco&trade; for Unity][DracoForUnity] (provides support for [KHR_draco_mesh_compression][ExtDraco])
- [KTX&trade; for Unity][KtxUnity] (provides support for [KHR_texture_basisu][ExtBasisU])
- [*meshoptimizer decompression for Unity*][Meshopt] (provides support for [EXT_meshopt_compression][ExtMeshopt])

## Trademarks

*Unity&reg;* is a registered trademark of [Unity Technologies][unity].

*Khronos&reg;* is a registered trademark and [glTF&trade;][gltf] is a trademark of [The Khronos Group Inc][khronos].

*KTX&trade;* and the KTX logo are trademarks of the [The Khronos Group Inc][khronos].

*Draco&trade;* is a trademark of [*Google LLC*][GoogleLLC].

[DracoForUnity]: https://docs.unity3d.com/Packages/com.unity.cloud.draco@latest
[ExtBasisU]: https://github.com/KhronosGroup/glTF/tree/master/extensions/2.0/Khronos/KHR_texture_basisu
[ExtDraco]: https://github.com/KhronosGroup/glTF/tree/master/extensions/2.0/Khronos/KHR_draco_mesh_compression
[ExtMeshopt]: https://github.com/KhronosGroup/glTF/tree/main/extensions/2.0/Vendor/EXT_meshopt_compression
[gltf]: https://www.khronos.org/gltf
[GoogleLLC]: https://about.google/
[khronos]: https://www.khronos.org
[KtxUnity]: https://docs.unity3d.com/Packages/com.unity.cloud.ktx@latest/
[Meshopt]: https://docs.unity3d.com/Packages/com.unity.meshopt.decompress@latest/
[unity]: https://unity.com
