# Graphics Tests for gltFast

## Overview

Graphics tests are done using  [Unity Graphic tests framework](https://github.cds.internal.unity3d.com/unity/com.unity.testframework.graphics)
This document outlines the graphics tests and how to add them.

## How to add a new graphic test

### Importing the files

Graphics files for testing are located inside the `Packages\com.unity.cloud.gltfast.tests\Assets~\Graphic` folder.

Place the desired gltf file(s) inside the `Graphic` folder.

### Update the tests set

The testcases set is located inside the `Packages/com.unity.cloud.gltfast.tests/Tests/Runtime/TestCaseSets/glTF-Graphic-Tests-Assets.asset` file.
Add the imported asset to set, there is two ways to do this:

1. **Manually**: Open the `Graphic-Tests-Assets.asset` file and add the imported asset to the list.
2. **Automatically**: Using the button "Scan for glTF test files" in the inspector of the `Graphic-Tests-Assets.asset` file. This will scan the `Graphic` folder and add all gltf files to the list.

### Update the testcases

Update the tests attributes by changing the `testCaseCount` parameter on each test.

### Import reference images

Run a Yamato job to generate the reference images. The job will fail then you can use it's artifacts inside the  [tool created by the graphics team](https://gtt.ds.unity3d.com/) to download the reference images.
The reference images for the tests are located inside the `Projects\glTFast-Test\Assets\ReferenceImages` folder. Copy the downloaded images inside the `ReferenceImages` folder.

With that you are done adding a new graphic test.
