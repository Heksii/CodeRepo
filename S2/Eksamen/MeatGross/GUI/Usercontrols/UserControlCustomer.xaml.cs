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
    /// Interaction logic for UserControlCustomer.xaml
    /// </summary>
    public partial class UserControlCustomer : UserControl
    {
        Grid leftGrid;
        Grid rightGrid;
        ClassBiz BIZ;
        UserControlCustomerEdit ucce;

        public UserControlCustomer(ClassBiz inBiz, Grid inLeftGrid, Grid inRightGrid)
        {
            InitializeComponent();

            BIZ = inBiz;
            MainGrid.DataContext = BIZ;
            leftGrid = inLeftGrid;
            rightGrid = inRightGrid;
        }

        private void buttonEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            {
                if (BIZ.selectedCustomer.id > 0)
                {
                    BIZ.editOrNewCustomer = new ClassCustomer(BIZ.selectedCustomer);
                    ucce = new UserControlCustomerEdit(BIZ, leftGrid, rightGrid);
                    leftGrid.Children.Add(ucce);
                }
            }
        }

        private void buttonNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            BIZ.editOrNewCustomer = new ClassCustomer();
            ucce = new UserControlCustomerEdit(BIZ, leftGrid, rightGrid);
            leftGrid.Children.Add(ucce);
        }
    }
}
