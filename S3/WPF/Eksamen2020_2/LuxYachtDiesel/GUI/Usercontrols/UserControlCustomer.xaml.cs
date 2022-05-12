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
using Repository;

namespace GUI
{
    /// <summary>
    /// Interaction logic for UserControlCustomer.xaml
    /// </summary>
    public partial class UserControlCustomer : UserControl
    {
        ClassBIZ biz;

        public UserControlCustomer(ClassBIZ inBiz)
        {
            InitializeComponent();

            biz = inBiz;
            MainGrid.DataContext = biz;
        }

        private void ButtonRediger_Click(object sender, RoutedEventArgs e)
        {
            if (biz.selectedCustomer.Id != 0) {
                biz.fallbackCustomer = new ClassCustomer(biz.selectedCustomer);
                biz.isEditingCustomer = true;
            }
        }

        private void ButtonFortryd_Click(object sender, RoutedEventArgs e)
        {
            biz.selectedCustomer = new ClassCustomer(biz.fallbackCustomer);
            biz.isEditingCustomer = false;
        }

        private void ButtonOpret_Click(object sender, RoutedEventArgs e)
        {
            if (biz.selectedCustomer.Id != 0)
            {
                biz.fallbackCustomer = new ClassCustomer(biz.selectedCustomer);
            }

            biz.selectedCustomer = new ClassCustomer();
            biz.isEditingCustomer = true;
        }
    }
}
