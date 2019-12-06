// <copyright file="LzfseCompressorTests.cs" company="Quamotion">
// Copyright (c) Quamotion. All rights reserved.
// </copyright>

namespace Lzfse.Tests
{
    using System;
    using System.Text;
    using Lzfse;
    using Xunit;

    /// <summary>
    /// Tests the <see cref="LzfseCompressor"/> class.
    /// </summary>
    public class LzfseCompressorTests
    {
        /// <summary>
        /// Tests compressing and decompressing a byte array.
        /// </summary>
        [Fact]
        public void RoundtripTest()
        {
            byte[] buffer = Encoding.UTF8.GetBytes("Hello, World!");
            byte[] compressedBuffer = new byte[1024];
            byte[] decompressedBuffer = new byte[1024];

            Assert.NotEqual(0, LzfseCompressor.Compress(buffer, compressedBuffer));
            Assert.Equal(buffer.Length, LzfseCompressor.Decompress(compressedBuffer, decompressedBuffer));

            Assert.Equal("Hello, World!", Encoding.UTF8.GetString(decompressedBuffer, 0, buffer.Length));
        }

        /// <summary>
        /// Tests the <see cref="LzfseCompressor.Decompress(byte[], int, int, byte[], int, int)"/> method with invalid arguments.
        /// </summary>
        /// <param name="offset">
        /// The offset for the offset parameter.
        /// </param>
        /// <param name="length">
        /// The value for the length parameter.
        /// </param>
        /// <param name="decompressedOffset">
        /// The value for the decompressedOffset parameter.
        /// </param>
        /// <param name="decompressedLength">
        /// The value for the decompressedLength parameter.
        /// </param>
        [InlineData(-1, 1, 0, 1)]
        [InlineData(0, -1, 0, 1)]
        [InlineData(1025, 1, 0, 1)]
        [InlineData(1, 1024, 0, 1)]
        [InlineData(1, 1025, 0, 1)]

        [InlineData(0, 1, -1, 1)]
        [InlineData(0, 1, 0, -1)]
        [InlineData(0, 1, 1025, 1)]
        [InlineData(0, 1, 1, 1024)]
        [InlineData(0, 1, 1, 1025)]
        [Theory]
        public void DecompressInvalidArgumentsTest(int offset, int length, int decompressedOffset, int decompressedLength)
        {
            byte[] buffer = new byte[1024];
            byte[] decompressedBuffer = new byte[1024];

            Assert.Throws<ArgumentOutOfRangeException>(() => LzfseCompressor.Decompress(buffer, offset, length, decompressedBuffer, decompressedOffset, decompressedLength));
        }

        /// <summary>
        /// Tests the <see cref="LzfseCompressor.Decompress(byte[], int, int, byte[], int, int)"/> method with <see langword="null"/> arguments.
        /// </summary>
        [Fact]
        public void CompressNullTest()
        {
            byte[] buffer = Array.Empty<byte>();

            Assert.Throws<ArgumentNullException>(() => LzfseCompressor.Compress(buffer, null));
            Assert.Throws<ArgumentNullException>(() => LzfseCompressor.Compress(null, buffer));

            Assert.Throws<ArgumentNullException>(() => LzfseCompressor.Compress(buffer, 0, 0, null, 0, 0));
            Assert.Throws<ArgumentNullException>(() => LzfseCompressor.Compress(null, 0, 0, buffer, 0, 0));
        }

        /// <summary>
        /// Tests the <see cref="LzfseCompressor.Compress(byte[], int, int, byte[], int, int)"/> method with invalid arguments.
        /// </summary>
        /// <param name="offset">
        /// The offset for the offset parameter.
        /// </param>
        /// <param name="length">
        /// The value for the length parameter.
        /// </param>
        /// <param name="compressedOffset">
        /// The value for the compressedOffset parameter.
        /// </param>
        /// <param name="compressedLength">
        /// The value for the compressedLength parameter.
        /// </param>
        [InlineData(-1, 1, 0, 1)]
        [InlineData(0, -1, 0, 1)]
        [InlineData(1025, 1, 0, 1)]
        [InlineData(1, 1024, 0, 1)]
        [InlineData(1, 1025, 0, 1)]

        [InlineData(0, 1, -1, 1)]
        [InlineData(0, 1, 0, -1)]
        [InlineData(0, 1, 1025, 1)]
        [InlineData(0, 1, 1, 1024)]
        [InlineData(0, 1, 1, 1025)]
        [Theory]
        public void CompressInvalidArgumentsTest(int offset, int length, int compressedOffset, int compressedLength)
        {
            byte[] buffer = new byte[1024];
            byte[] compressedBuffer = new byte[1024];

            Assert.Throws<ArgumentOutOfRangeException>(() => LzfseCompressor.Decompress(buffer, offset, length, compressedBuffer, compressedOffset, compressedLength));
        }

        /// <summary>
        /// Tests the <see cref="LzfseCompressor.Compress(byte[], int, int, byte[], int, int)"/> method with <see langword="null"/> arguments.
        /// </summary>
        [Fact]
        public void DecompressNullTest()
        {
            byte[] buffer = Array.Empty<byte>();

            Assert.Throws<ArgumentNullException>(() => LzfseCompressor.Decompress(buffer, null));
            Assert.Throws<ArgumentNullException>(() => LzfseCompressor.Decompress(null, buffer));

            Assert.Throws<ArgumentNullException>(() => LzfseCompressor.Decompress(buffer, 0, 0, null, 0, 0));
            Assert.Throws<ArgumentNullException>(() => LzfseCompressor.Decompress(null, 0, 0, buffer, 0, 0));
        }
    }
}
