using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Repository;

namespace IO
{
    /// <summary>
    /// En klasse der er ansvarlig for at læse og skrive til eksterne filer.
    /// </summary>
    public class ClassFileIO
    {
        Encoding enc1252;
        Encoding encUTF8;

        /// <summary>
        /// En constructor der initialisere tekst encoding tabellerne.
        /// </summary>
        public ClassFileIO()
        {
            enc1252 = Encoding.GetEncoding("Windows-1252");
            encUTF8 = Encoding.GetEncoding("UTF-8");
        }

        /// <summary>
        /// En metode der læser tekst fra en .txt fil.
        /// 
        /// Den bruger FileStream og StreamReader til at gøre det mere sikkert,
        /// garbage collectoren ryder op efter dem med det samme efter de er blevet brugt.
        /// </summary>
        /// <param name="path">string</param>
        /// <returns>string</returns>
        public string ReadTextFromFile(string path)
        {
            string resText = "";

            if (path.Trim().Length == 0)
            {
                return $"Der er ikke angivet nogen sti til filen";
            }

            if (!File.Exists(path))
            {
                return $"Filen med følgende sti\n\n{path}\n\nblev IKKE fundet";
            }

            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream, enc1252))
                    {
                        resText = reader.ReadToEnd();
                    }
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
            return resText;
        }

        /// <summary>
        /// En metode der skriver tekst ind i en .txt fil.
        /// 
        /// Den bruger StreamWriter som lader metoden
        /// oprette nye filer og låse filer den skriver til,
        /// den får garbage collectoren til at rydde op
        /// efter den når den har brugt en StreamWriter.
        /// </summary>
        /// <param name="path">string</param>
        /// <param name="text">string</param>
        public void WriteTextToServerFile_StreamWriter(string path, string text)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(File.Create(path), enc1252))
                {
                    writer.AutoFlush = true;
                    writer.WriteLine(text);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        public List<ClassCountry> ReadCountryDataFromCsvFile()
        {
            List<ClassCountry> res = new List<ClassCountry>();

            try
            {
                string filePath = Directory.GetParent(
                    Directory.GetCurrentDirectory()
                    ).Parent.Parent.FullName +
                    @"\Repository\DataFiles\ValutaKoderOgNavne.csv";

                using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("Windows-1252")))
                {
                    while (reader.Peek() > -1)
                    {
                        ClassCountry cc = new ClassCountry();
                        string line = reader.ReadLine();
                        string[] splitLine = line.Split(';');

                        cc.code = splitLine[0];
                        cc.countryName = splitLine[1];
                        cc.valutaName = splitLine[2];

                        res.Add(cc);
                    }
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }

            return res;
        }

        public Dictionary<string, string> ReadDataFromCurrencyFile()
        {
            Dictionary<string, string> res = new Dictionary<string, string>();

            return res;
        }

    }
}
