// SPDX-FileCopyrightText: 2025 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace GLTFast
{
    /// <summary>
    /// Wraps a <see cref="NativeArray{T}.ReadOnly"/> and provides a <see cref="ReadOnlyBuffer{T}"/> for accessing it.
    /// </summary>
    unsafe struct ReadOnlyBufferNativeArray
    {
        readonly ReadOnlyBuffer<byte> m_Buffer;
        public readonly ReadOnlyBuffer<byte> Buffer
        {
            get
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS && UNITY_2022_2_OR_NEWER
                // Making sure the source was not disposed already.
                // This indirectly triggers a check of the original's safety handle as in
                // `AtomicSafetyHandle.CheckReadAndThrow(m_Source.m_Safety);`
                m_Source.AsReadOnlySpan();
#endif
                return m_Buffer;
            }
        }

#if ENABLE_UNITY_COLLECTIONS_CHECKS && UNITY_2022_2_OR_NEWER
        NativeArray<byte>.ReadOnly m_Source;
#endif

        public ReadOnlyBufferNativeArray(NativeArray<byte>.ReadOnly data)
        {
            var bufferAddress = data.GetUnsafeReadOnlyPtr();
#if ENABLE_UNITY_COLLECTIONS_CHECKS
#if UNITY_2022_2_OR_NEWER
            m_Source = data;
#endif
            var safety = AtomicSafetyHandle.Create();
            m_Buffer = new ReadOnlyBuffer<byte>(bufferAddress, data.Length, ref safety);
#else
            m_Buffer = new ReadOnlyBuffer<byte>(bufferAddress, data.Length);
#endif
        }
    }
}
