﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForensicsCourseToolkit.Framework_Project.Compression
{
    public static class CompressionHelper
    {
        /// <summary>
        /// Compresses the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string Zip(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
            return Convert.ToBase64String(gZipBuffer);
        }

        /// <summary>
        /// Decompresses the string.
        /// </summary>
        /// <param name="compressedText">The compressed text.</param>
        /// <returns></returns>
        public static string Unzip(string compressedText)
        {
            byte[] gZipBuffer = Convert.FromBase64String(compressedText);
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }
        //public static void CopyTo(Stream src, Stream dest)
        //{
        //    byte[] bytes = new byte[4096];

        //    int cnt;

        //    while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
        //    {
        //        dest.Write(bytes, 0, cnt);
        //    }
        //}

        //public static string Zip(string str)
        //{
        //    var bytes = Encoding.Unicode.GetBytes(str);
         

        //    using (var msi = new MemoryStream(bytes))
        //    using (var mso = new MemoryStream())
        //    {
        //        using (var gs = new GZipStream(mso, CompressionLevel.Optimal))
        //        {
        //            //msi.CopyTo(gs);
        //            CopyTo(msi, gs);
        //        }

        //        return Convert.ToBase64String(mso.ToArray());
        //    }
        //}

        //public static string Unzip(string str)
        //{

        //    var bytes = Encoding.Unicode.GetBytes(str);
        //    using (var msi = new MemoryStream(bytes))
        //    using (var mso = new MemoryStream())
        //    {
        //        using (var gs = new GZipStream(msi, CompressionMode.Decompress))
        //        {
        //            //gs.CopyTo(mso);
        //            CopyTo(gs, mso);
        //        }

        //        return Encoding.UTF8.GetString(mso.ToArray());
        //    }
        //}
    }
}
