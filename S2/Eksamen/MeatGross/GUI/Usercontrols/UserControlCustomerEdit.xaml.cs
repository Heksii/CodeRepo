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
using Repository;
using BIZ;

namespace GUI.Usercontrols
{
    /// <summary>
    /// Interaction logic for UserControlCustomerEdit.xaml
    /// </summary>
    public partial class UserControlCustomerEdit : UserControl
    {
        Grid leftGrid;
        Grid rightGrid;
        ClassBiz BIZ;

        public UserControlCustomerEdit(ClassBiz inBiz, Grid inLeftGrid, Grid inRightGrid)
        {
            InitializeComponent();

            BIZ = inBiz;
            MainGrid.DataContext = BIZ;
            leftGrid = inLeftGrid;
            rightGrid = inRightGrid;
        }

        private void buttonSaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            BIZ.selectedCustomer = BIZ.editOrNewCustomer;
            int newCustomerId = BIZ.SaveCustomer();
            BIZ.UpdateListCustomerAndSelectedCustomer(newCustomerId);

            leftGrid.Children.Remove(this);
        }

        private void buttonRegret_Click(object sender, RoutedEventArgs e)
        {
            BIZ.editOrNewCustomer = new ClassCustomer();
            leftGrid.Children.Remove(this);
        }
    }
}
