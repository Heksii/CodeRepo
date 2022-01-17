using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using IO;

namespace BIZ
{
    public class BizClass
    {
        public BizClass()
        {

        }

        

        ClassFileHandler ioClass = new ClassFileHandler();

        public void GetTextForTextBox(TextBox textBox)
        {
            string text = ioClass.ReadTextFromFile(@"C:\KodeMappe\Text.txt");

            textBox.Text = text;
        }

        public int CountAllLines(TextBox textBox)
        {
            int res = 0;
            int lineCount = textBox.LineCount;

            for (int line = 0; line < lineCount; line++)
            {
                if (textBox.GetLineText(line).Trim().Length > 0)
                {
                    res++;
                }
            }

            return res;
        }

        public int CountAllChars(TextBox textBox)
        {
            return textBox.Text.Length;
        }

        public int CountAllVowels(TextBox textBox)
        {
            int numVowels = 0;

            foreach (char c in textBox.Text)
            {
                switch(char.ToUpper(c))
                {
                    case 'A':case 'E':case 'I':
                    case 'O':case 'U':case 'Y':
                    case 'Æ':case 'Ø':case 'Å':
                    numVowels++; break;
                }
            }

            return numVowels;
        }

        public string RemoveAllVowels(TextBox textBox)
        {
            string newText = textBox.Text;
            string[] vowels = new string[] { "a", "e", "i", "o", "u", "y", "æ", "ø", "å",
                                             "A", "E", "I", "O", "U", "Y", "Æ", "Ø", "Å" };
            foreach (string vowel in vowels)
            {
                newText = newText.Replace(vowel, "");
            }

            return newText;
        }

        public string FindWordOccurrences(TextBox textBox, string word)
        {
            string newText = textBox.Text;
            int wordCount = 0;
            int indexOffset = 0;

            for (int i = 0; i < newText.Length; i++)
            {
                if (i + indexOffset < textBox.Text.Length && textBox.Text.Substring(i, i + word.Length) == word)
                {
                    newText = newText.Insert(i + indexOffset, "#>");

                    indexOffset += word.Length;
                    wordCount++;
                }
            }

            newText = newText.Insert(0, $"Ordet \"{word}\" blev fundet {wordCount} gange.");

            return newText;
        }
        
    }
}
