// SPDX-FileCopyrightText: 2023 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

#if KTX_UNITY_2_2_OR_NEWER || (!UNITY_2021_2_OR_NEWER && KTX_UNITY_1_3_OR_NEWER)
#define KTX
#endif

#if KTX

using System.Threading.Tasks;
using KtxUnity;
using Unity.Collections;

namespace GLTFast {
    class KtxLoadNativeContext : KtxLoadContextBase {
        ReadOnlyBuffer<byte> m_Data;

        public KtxLoadNativeContext(int index,ReadOnlyBuffer<byte> data) {
            imageIndex = index;
            m_Data = data;
            m_KtxTexture = new KtxTexture();
        }

        public override async Task<TextureResult> LoadTexture2D(bool linear) {
            var errorCode = m_KtxTexture.Open(m_Data.ToSlice());
            if (errorCode != ErrorCode.Success) {
                return new TextureResult(errorCode);
            }

            var result = await m_KtxTexture.LoadTexture2D(linear);
            m_KtxTexture.Dispose();
            return result;
        }
    }
}
#endif // KTX_UNITY
