using System;
using System.Runtime.InteropServices;

namespace Lzfse
{
    internal unsafe static class NativeMethods
    {
        private const string LibraryPath = "lzfse";

        /// <summary>
        /// Decompress a buffer using LZFSE.
        /// </summary>
        /// <param name="decompressedBuffer">
        /// Pointer to the first byte of the destination buffer.
        /// </param>
        /// <param name="decompressedSize">
        /// Size of the destination buffer in bytes.
        /// </param>
        /// <param name="compressedBuffer">
        /// Pointer to the first byte of the source buffer.
        /// </param>
        /// <param name="compressedSize">
        /// Size of the source buffer in bytes.
        /// </param>
        /// <param name="scratchBuffer">
        /// If non-<see langword="null"/>, a pointer to scratch space for the routine to use as workspace;
        /// the routine may use up to <see cref="lzfse_decode_scratch_size"/> bytes of workspace
        /// during its operation, and will not perform any internal allocations. If
        /// <see langword="null"/>, the routine may allocate its own memory to use during operation via
        /// a single call to <c>malloc()</c>, and will release it by calling <c>free()</c> prior
        /// to returning. For most use, passing <see langword="null"/> is perfectly satisfactory, but if
        /// you require strict control over allocation, you will want to pass an
        /// explicit scratch buffer.
        /// </param>
        [DllImport(LibraryPath, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern UIntPtr lzfse_decode_buffer(byte* decompressedBuffer, UIntPtr decompressedSize, byte* compressedBuffer, UIntPtr compressedSize, void* scratchBuffer);

        /// <summary>
        /// Compress a buffer using LZFSE.
        /// </summary>
        /// <param name="compressedBuffer">
        /// Pointer to the first byte of the destination buffer.
        /// </param>
        /// <param name="compressedSize">
        /// Size of the destination buffer in bytes.
        /// </param>
        /// <param name="decompressedBuffer">
        /// Pointer to the first byte of the source buffer.
        /// </param>
        /// <param name="decompressedSize">
        /// Size of the source buffer in bytes.
        /// </param>
        /// <param name="scratchBuffer">
        /// If non-<see langword="null"/>, a pointer to scratch space for the routine to use as workspace;
        /// the routine may use up to <see cref="lzfse_encode_scratch_size"/> bytes of workspace
        /// during its operation, and will not perform any internal allocations. If
        /// <see langword="null"/>, the routine may allocate its own memory to use during operation via
        /// a single call to <c>malloc()</c>, and will release it by calling <c>free()</c> prior
        /// to returning. For most use, passing <see cref="null"/> is perfectly satisfactory, but if
        /// you require strict control over allocation, you will want to pass an
        /// explicit scratch buffer.
        /// </param>
        /// <returns></returns>
        [DllImport(LibraryPath, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern UIntPtr lzfse_encode_buffer(byte* compressedBuffer, UIntPtr compressedSize, byte* decompressedBuffer, UIntPtr decompressedSize, void* scratchBuffer);

        /// <summary>
        /// Get the required scratch buffer size to decompress using LZFSE.
        /// </summary>
        [DllImport(LibraryPath, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern UIntPtr lzfse_decode_scratch_size();

    }
}
