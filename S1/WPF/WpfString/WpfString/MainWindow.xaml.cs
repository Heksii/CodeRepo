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

namespace WpfString
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BizClass BC = new BizClass();

        public MainWindow()
        {
            InitializeComponent();
            BC.GetTextForTextBox(textBoxLeft);
        }

        private void Button_Opg1_Click(object sender, RoutedEventArgs e)
        {
            textBoxRight.Text = $"Mængden af linjer er {BC.CountAllLines(textBoxLeft)}";
        }

        private void Button_Opg2_Click(object sender, RoutedEventArgs e)
        {
            textBoxRight.Text = $"Mængden af tægn er {BC.CountAllChars(textBoxLeft)}";
        }

        private void Button_Opg3_Click(object sender, RoutedEventArgs e)
        {
            textBoxRight.Text = $"Mængden af vokaler er {BC.CountAllVowels(textBoxLeft)}";
        }

        private void Button_Opg4_Click(object sender, RoutedEventArgs e)
        {
            textBoxRight.Text = BC.RemoveAllVowels(textBoxLeft);
        }

        private void Button_Opg5_Click(object sender, RoutedEventArgs e)
        {
            textBoxRight.Text = BC.FindWordOccurrences(textBoxLeft, "grøn");
        }
    }
}
