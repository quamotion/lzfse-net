using System;

namespace Lzfse
{
    public class LzfseCompressor
    {
        /// <summary>
        /// Decompresses a LZFSE compressed buffer
        /// </summary>
        /// <param name="buffer">
        /// The buffer to decompress
        /// </param>
        /// <param name="decompressedBuffer">
        /// The buffer into which to decompress the data.
        /// </param>
        public static unsafe int Decompress(byte[] buffer, byte[] decompressedBuffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (decompressedBuffer == null)
            {
                throw new ArgumentNullException(nameof(decompressedBuffer));
            }

            return Decompress(buffer, 0, buffer.Length, decompressedBuffer, 0, decompressedBuffer.Length);
        }

        /// <summary>
        /// Decompresses a LZFSE compressed buffer
        /// </summary>
        /// <param name="buffer">
        /// The buffer to decompress
        /// </param>
        /// <param name="length">
        /// The amount of bytes to read from <paramref name="buffer"/>.
        /// </param>
        /// <param name="decompressedBuffer">
        /// The buffer into which to decompress the data.
        /// </param>
        /// <param name="decompressedLength">
        /// The amount of bytes to write to <paramref name="decompressedBuffer"/>.
        /// </param>
        /// <returns></returns>
        public static unsafe int Decompress(byte[] buffer, int offset, int length, byte[] decompressedBuffer, int decompressedOffset, int decompressedLength)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (length < 0 || length > buffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if (offset < 0 || offset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            if (offset + length > buffer.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (decompressedBuffer == null)
            {
                throw new ArgumentNullException(nameof(decompressedBuffer));
            }

            if (decompressedLength < 0 || decompressedLength > decompressedBuffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(decompressedLength));
            }

            if (decompressedOffset < 0 || decompressedOffset > decompressedBuffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(decompressedOffset));
            }

            if (decompressedLength + decompressedOffset < 0 || decompressedLength + decompressedOffset > decompressedBuffer.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            int actualDecompressedSize = 0;

            fixed (byte* decompressedBufferPtr = decompressedBuffer)
            fixed (byte* bufferPtr = buffer)
            {
                actualDecompressedSize = (int)NativeMethods.lzfse_decode_buffer(decompressedBufferPtr + decompressedOffset, (UIntPtr)decompressedLength, bufferPtr + offset, (UIntPtr)length, null);
            }

            if (actualDecompressedSize == 0)
            {
                throw new Exception("There was an error decompressing the specified buffer.");
            }

            return actualDecompressedSize;
        }

        /// <summary>
        /// Compresses a buffer using LZFSE.
        /// </summary>
        /// <param name="buffer">
        /// The buffer to compress.
        /// </param>
        /// <param name="compressedBuffer">
        /// The buffer into which to save the compressed data.
        /// </param>
        public static int Compress(byte[] buffer, byte[] compressedBuffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (compressedBuffer == null)
            {
                throw new ArgumentNullException(nameof(compressedBuffer));
            }

            return Compress(buffer, 0, buffer.Length, compressedBuffer, 0, compressedBuffer.Length);
        }

        /// <summary>
        /// Compresses a buffer using LZFSE.
        /// </summary>
        /// <param name="buffer">
        /// The buffer to compress.
        /// </param>
        /// <param name="length">
        /// The amount of bytes to read from <paramref name="buffer"/>.
        /// </param>
        /// <param name="compressedBuffer">
        /// The buffer into which to save the compressed data.
        /// </param>
        /// <param name="compressedLength">
        /// The amount of bytes to write to <paramref name="compressedBuffer"/>.
        /// </param>
        public static unsafe int Compress(byte[] buffer, int offset, int length, byte[] compressedBuffer, int compressedOffset, int compressedLength)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (offset < 0 || offset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            if (length < 0 || length > buffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            if (offset + length > buffer.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (compressedBuffer == null)
            {
                throw new ArgumentNullException(nameof(compressedBuffer));
            }

            if (compressedOffset < 0 || compressedOffset > compressedBuffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            if (compressedLength < 0 || compressedLength > compressedBuffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            if (compressedOffset + compressedLength > compressedBuffer.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            int actualCompressedSize = 0;

            fixed (byte* bufferPtr = buffer)
            fixed (byte* compressedBufferPtr = compressedBuffer)
            {
                actualCompressedSize = (int)NativeMethods.lzfse_encode_buffer(compressedBufferPtr + compressedOffset, (UIntPtr)compressedLength, bufferPtr + offset, (UIntPtr)length, null);
            }

            if (actualCompressedSize == 0)
            {
                throw new Exception("There was an error compressing the specified buffer.");
            }

            return actualCompressedSize;
        }
    }
}
