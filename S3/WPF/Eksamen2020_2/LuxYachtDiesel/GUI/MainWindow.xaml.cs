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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBIZ biz;
        UserControlCustomer UCCustomer;
        UserControlDailyPrice UCDailyPrice;
        UserControlDiesel UCDiesel;
        UserControlSupplier UCSupplier;

        public MainWindow()
        {
            InitializeComponent();
            biz = new ClassBIZ();
            MainGrid.DataContext = biz;

            UCCustomer = new UserControlCustomer(biz);
            UCDailyPrice = new UserControlDailyPrice(biz);
            UCDiesel = new UserControlDiesel(biz);
            UCSupplier = new UserControlSupplier(biz);

            Customer.Children.Add(UCCustomer);
            DieselSale.Children.Add(UCDiesel);
            Supplier.Children.Add(UCSupplier);
            Price.Children.Add(UCDailyPrice);
        }
    }
}
