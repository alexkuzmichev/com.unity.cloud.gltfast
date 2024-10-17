# Sources

## Download Sources

*glTFast*'s sources are hosted in a [GitHub repository][UnityGltfastGitHub].

Download a local copy by [cloning][GitHubCloning]:

```sh
# Call this command in the directory you want the repository to be cloned into.
git clone git@github.com:Unity-Technologies/com.unity.cloud.gltfast.git
```

> **NOTE:** This particular method of cloning assumes you have a valid GitHub account and configured authentication properly. See [Cloning a repository][GitHubCloning] for detailed instructions and troubleshooting.
>
> **NOTE:** The repository uses [Git LFS](https://git-lfs.com/), so make sure to have it installed and initialized.

## Repository Structure

*glTFast* is part of a larger [Monorepo][Monorepo] and can be found in the subfolder `Packages/com.unity.cloud.gltfast`.

Here's an overview of the repository structure.

```none
<Root>
├── Packages
│   ├── com.unity.cloud.gltfast
│   └── com.unity.cloud.gltfast.tests
│       └── Assets~
└── Projects
    ├── glTFast-Test
    └── ...
```

- *Packages* - Unity&reg; packages
  - *com.unity.cloud.gltfast* - The actual *glTFast* package
  - *com.unity.cloud.gltfast.tests* - Test code and assets
    - *Assets~* - glTF&trade; test assets
- *Projects* - see [Test Projects](test-project-setup.md#test-projects)

## Trademarks

*Unity&reg;* is a registered trademark of [Unity Technologies][unity].

*Khronos&reg;* is a registered trademark and [glTF&trade;][gltf] is a trademark of [The Khronos Group Inc][khronos].

[GitHubCloning]: https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repositor
[gltf]: https://www.khronos.org/gltf
[khronos]: https://www.khronos.org
[Monorepo]: https://en.wikipedia.org/wiki/Monorepo
[UnityGltfastGitHub]: https://github.com/Unity-Technologies/com.unity.cloud.gltfast
[unity]: https://unity.com
