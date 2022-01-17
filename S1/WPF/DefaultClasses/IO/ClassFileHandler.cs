using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IO
{
    public class ClassFileHandler
    {
        Encoding enc1252;
        Encoding encUTF8;

        public ClassFileHandler()
        {
            enc1252 = Encoding.GetEncoding("windows-1252");
            encUTF8 = Encoding.GetEncoding("UTF-8");
        }

        public string ReadTextFromFile(string path)
        {
            string text = "";

            if (path.Trim().Length == 0)
            {
                return "Der blev ikke angivet nogen sti til filen.";
            }

            if (!File.Exists(path))
            {
                return $"Filen {path} blev ikke fundet.";
            }

            try
            {
                using(FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream, enc1252))
                    {
                        text = reader.ReadToEnd();
                    }
                }
            }

            catch (IOException ex)
            {
                throw ex;
            }

            return text;
        }
    }
}
