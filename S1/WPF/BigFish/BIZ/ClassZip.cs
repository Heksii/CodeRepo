using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class ClassZip
    {
        public ClassZip()
        {

        }

        /// <summary>
        /// Metode der komprimerer en string med GZip
        /// </summary>
        /// <param name="inString">string</param>
        /// <returns>string</returns>
        public string CompressZip(string inString)
        {
            string res = "";

            Encoding enc1252 = CodePagesEncodingProvider.Instance.GetEncoding(1252);
            byte[] asciiBytes = enc1252.GetBytes(inString);

            using (MemoryStream outputStream = new MemoryStream())
            {
                using (GZipStream gZipStream = new GZipStream(outputStream, CompressionMode.Compress))
                gZipStream.Write(asciiBytes, 0, asciiBytes.Length);

                byte[] outBytes = outputStream.ToArray();
                string outString = Convert.ToBase64String(outBytes);

                res = outString;
            }

            return res;
        }

        /// <summary>
        /// En metode der dekomprimerer en komprimeret string med GZip
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public string DecompressZip(string inString)
        {
            string res = "";

            byte[] asciiBytes = Convert.FromBase64String(inString);

            using (MemoryStream inputStream = new MemoryStream(asciiBytes))
            using (GZipStream gZipStream = new GZipStream(inputStream, CompressionMode.Decompress))
            using (StreamReader streamReader = new StreamReader(gZipStream))
            {
                res = streamReader.ReadToEnd();
            }

            return res;
        }
    }
}
