// <copyright file="LzfseCompressorTests.cs" company="Quamotion">
// Copyright (c) Quamotion. All rights reserved.
// </copyright>

namespace Lzfse.Demo
{
    using System;
    using System.Text;
    using Lzfse;

    /// <summary>
    /// A demo program for lzfse-net
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entrypoint.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments
        /// </param>
        public static void Main(string[] args)
        {
            byte[] buffer = Encoding.UTF8.GetBytes("Hello, World!");

            byte[] compressedBuffer = new byte[1024];
            byte[] decompressedBuffer = new byte[1024];

            LzfseCompressor.Compress(buffer, compressedBuffer);
            int length = LzfseCompressor.Decompress(compressedBuffer, decompressedBuffer);

            Console.WriteLine(Encoding.UTF8.GetString(decompressedBuffer, 0, length));
        }
    }
}
