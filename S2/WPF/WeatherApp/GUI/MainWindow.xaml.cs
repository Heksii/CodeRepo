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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Repo;
using BIZ;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBiz biz = new ClassBiz();

        public MainWindow()
        {
            InitializeComponent();
            MainGrid.DataContext = biz;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(async () => await biz.StartWeatherApiCall());
        }
    }
}
