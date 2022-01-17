using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BIZ;
using Microsoft.Win32;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBiz BIZ;
        public MainWindow()
        {
            InitializeComponent();
            BIZ = new ClassBiz();
            MainGrid.DataContext = BIZ;
        }

        private void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = @"C:\KodeMappe";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            
            if (saveFileDialog.ShowDialog() == true)
            {
                BIZ.SaveFileToTekst(saveFileDialog.FileName);
            }
        }

        private void LoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = @"C:\KodeMappe";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == true)
            {
                BIZ.OpenFileAndShowText(openFileDialog.FileName);
            }
        }

        private void encrypt_Click(object sender, RoutedEventArgs e)
        {
            BIZ.StartEncryption();
        }

        private void decrypt_Click(object sender, RoutedEventArgs e)
        {
            BIZ.StartDecryption();
        }

        private void rollingEncrypt_Click(object sender, RoutedEventArgs e)
        {
            BIZ.StartRollingEncryption();
        }

        private void rollingDecrypt_Click(object sender, RoutedEventArgs e)
        {
            BIZ.StartRollingDecryption();
        }

        private void rollingDecryptExtra_Click(object sender, RoutedEventArgs e)
        {
            BIZ.StartRollingDecryptionExtra();
        }

        private void rollingEncryptExtra_Click(object sender, RoutedEventArgs e)
        {
            BIZ.StartRollingEncryptionExtra();
        }
    }
}
