// SPDX-FileCopyrightText: 2025 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;

namespace GLTFast
{
    /// <summary>
    /// Wraps a managed array and provides a <see cref="ReadOnlyBuffer{T}"/> for accessing it.
    /// </summary>
    sealed class ReadOnlyBufferManagedArray<T> : IDisposable
        where T : unmanaged
    {
        public ReadOnlyBuffer<T> Buffer { get; }

        GCHandle m_BufferHandle;
        readonly bool m_Pinned;

        public unsafe ReadOnlyBufferManagedArray(T[] original)
        {
            if (original == null)
                throw new ArgumentNullException(nameof(original));

            m_BufferHandle = GCHandle.Alloc(original, GCHandleType.Pinned);
            fixed (void* bufferAddress = &original[0])
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                var safety = AtomicSafetyHandle.Create();
                Buffer = new ReadOnlyBuffer<T>(bufferAddress, original.Length, ref safety);
#else
                Buffer = new ReadOnlyBuffer<T>(bufferAddress, original.Length);
#endif
            }

            m_Pinned = true;
        }

        /// <summary>
        /// Disposes the managed <see cref="ReadOnlyBuffer&lt;T&gt;" />.
        /// </summary>
        public void Dispose()
        {
            if (m_Pinned)
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
#endif
                m_BufferHandle.Free();
            }
        }
    }
}
