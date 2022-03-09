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
using GUI.Usercontrols;
using BIZ;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserControlCustomer UCCustomer;
        private UserControlOrderMeat UCOrderMeat;
        private ClassBiz BIZ;

        public MainWindow()
        {
            InitializeComponent();

            BIZ = new ClassBiz();
            MainGrid.DataContext = BIZ;

            UCCustomer = new UserControlCustomer(BIZ, LeftGrid, RightGrid);
            UCOrderMeat = new UserControlOrderMeat(BIZ, LeftGrid, RightGrid);

            LeftGrid.Children.Add(UCCustomer);
            RightGrid.Children.Add(UCOrderMeat);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                BIZ.apiRates = await BIZ.GetApiRates();
                await Task.Delay(600000);
            }
            
        }
    }
}
