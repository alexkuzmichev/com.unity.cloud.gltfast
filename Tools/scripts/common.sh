#!/bin/sh

reset_materials()
{
    echo "Resetting Materials"
    # (potentially altered during previous tests)
    pushd Packages/com.unity.cloud.gltfast.tests/Tests
    git restore Runtime/Export/Materials/**/*.mat
    git restore Resources/Export/Materials/**/*.mat
    git restore Runtime/Export/ExportRenderTexture.renderTexture
    git restore Runtime/RenderPipelineAssets/URP-Forward.asset
    git restore Runtime/RenderPipelineAssets/URP-Forward_Renderer.asset
    popd
}
