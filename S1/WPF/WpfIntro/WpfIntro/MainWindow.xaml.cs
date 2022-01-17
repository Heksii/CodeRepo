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
using System.Windows.Controls;
using WpfIntro.BIZ;

namespace WpfIntro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ClassBIZ classBiz = new ClassBIZ();

        private void ClearList(ListBox listBox)
        {
            listBox.ItemsSource = null;

            listBox.Items.Clear();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonOpg12_Click(object sender, RoutedEventArgs e)
        {
            classBiz.delOpg12(listBoxRes);
        }

        private void buttonOpg13_Click(object sender, RoutedEventArgs e)
        {
            classBiz.delOpg13(listBoxRes);
        }

        private void buttonOpg14_Click(object sender, RoutedEventArgs e)
        {
            classBiz.delOpg14(listBoxRes);
        }

        private void buttonOpg15_Click(object sender, RoutedEventArgs e)
        {
            classBiz.delOpg15(listBoxRes);
        }

        private void buttonOpg16_Click(object sender, RoutedEventArgs e)
        {
            classBiz.delOpg16(listBoxRes);
        }

        private void buttonOpg17_Click(object sender, RoutedEventArgs e)
        {
            classBiz.delOpg17(listBoxRes);
        }

        private void buttonOpg18_Click(object sender, RoutedEventArgs e)
        {
            ClearList(listBoxRes);
            listBoxRes.ItemsSource = classBiz.delOpg18();
        }

        private void buttonOpg19_Click(object sender, RoutedEventArgs e)
        {
            classBiz.delOpg19(listBoxRes);
        }

        private void buttonOpg110_Click(object sender, RoutedEventArgs e)
        {
            ClearList(listBoxRes);
            listBoxRes.ItemsSource = classBiz.delOpg110();
        }
    }
}
