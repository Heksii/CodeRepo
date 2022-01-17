using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Repo;

namespace BIZ
{
    /// <summary>
    /// Business klassen der er ansvarlig for det meste af det funktionelle.
    /// </summary>
     public class ClassBiz
    {
        ClassEncryptText cet;
        ClassRollingEncrypt cre;
        ClassDecryptText cdt;
        ClassRollingDecrypt crd;
        ClassZip cz;

        private string[] myKey = new string[] { "T", "O", "R", "S", "K", "E", "M", "U", "N", "D" };

        private string[] myDummy = new string[] { "A", "B", "C", "#", "F", "G", "H", "¤", "I", "J",
                                                  "L", "P", "Q", "!", "V", "W", "X", "&", "{", "]" };
        private ClassText _encryptText;
        private ClassText _clearText;

        /// <summary>
        /// Constructoren til ClassBiz der initialisere alle fields
        /// </summary>
        public ClassBiz()
        {
            cet = new ClassEncryptText(myKey, myDummy);
            cre = new ClassRollingEncrypt(myKey, myDummy);
            cdt = new ClassDecryptText(myKey);
            crd = new ClassRollingDecrypt(myKey);
            cz = new ClassZip();
            clearText = new ClassText();
            encryptText = new ClassText();
        }

        public ClassText clearText
        {
            get { return _clearText; }
            set { _clearText = value; }
        }

        public ClassText encryptText
        {
            get { return _encryptText; }
            set { _encryptText = value; }
        }

        /// <summary>
        /// Kalder en metode der åbner en fil og returnere teksten inden i den 
        /// og sætter clearText.tekst til teksten som er bindet til en TextBox i GUI.
        /// </summary>
        /// <param name="inPath">string</param>
        public void OpenFileAndShowText(string inPath)
        {
            ClassFileHandler cfh = new ClassFileHandler();
            clearText.tekst = cfh.ReadTextFromFile(inPath);
        }

        /// <summary>
        /// Finder filen som inPath peger til filen og skriver encriptText.tekst ind i den.
        /// </summary>
        /// <param name="inPath">string</param>
        public void SaveFileToTekst(string inPath)
        {
            ClassFileHandler cfh = new ClassFileHandler();
            cfh.WriteTextToServerFile_StreamWriter(inPath, encryptText.tekst);
        }

        /// <summary>
        /// Kalder metoden i en instans af ClassEncryptText som kryptere teksten
        /// og sætter encryptText.tekst til den krypteret tekst.
        /// </summary>
        public void StartEncryption()
        {
            encryptText.tekst = cet.EncryptString(clearText.tekst);
        }

        /// <summary>
        /// Kalder metoden i en instans af ClassRollingEncrypt som kryptere teksten
        /// og sætter encryptText.tekst til den krypteret tekst.
        /// </summary>
        public void StartRollingEncryption()
        {
            encryptText.tekst = cre.EncryptString(clearText.tekst);
        }

        /// <summary>
        /// Kalder metoden i en instans af ClassDecryptText som dekryptere teksten i encryptTekst.
        /// </summary>
        public void StartDecryption()
        {
            clearText.tekst = cdt.DecryptString(encryptText.tekst);
        }

        /// <summary>
        /// Kalder metoden i en instans af ClassRollingDecrypt som dekryptere teksten i encryptTekst.
        /// </summary>
        public void StartRollingDecryption()
        {
            clearText.tekst = crd.DecryptString(encryptText.tekst);
        }

        public void StartRollingEncryptionExtra()
        {
            encryptText.tekst = cz.CompressZip(
                cre.EncryptString(clearText.tekst)
            );
        }

        public void StartRollingDecryptionExtra()
        {
            clearText.tekst = crd.DecryptString(
                cz.DecompressZip(encryptText.tekst)
            );
        }
    }
}
