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
using System.Diagnostics;

namespace WorldArtSale
{
    /// <summary>
    /// Interaction logic for UserControlCostumer.xaml
    /// </summary>
    public partial class UserControlCostumer : UserControl
    {
        ClassBiz biz;
        Grid parentGrid;

        public UserControlCostumer(ClassBiz inBiz, Grid inGrid)
        {
            InitializeComponent();
            GridCostumer.DataContext = inBiz;

            biz = inBiz;
            parentGrid = inGrid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            biz.editCustomer = new ClassCustomer();
            UserControlCostumerEditable edit = new UserControlCostumerEditable(biz, parentGrid);
            parentGrid.Children.Add(edit);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (biz.classCustomer.customerID > 0)
            {
                biz.editCustomer = new ClassCustomer(biz.classCustomer);

                UserControlCostumerEditable edit = new UserControlCostumerEditable(biz, parentGrid);
                biz.topMiddleEnabled = false;
                biz.topRightEnabled = false;
                parentGrid.Children.Add(edit);
            }
        }
    }
}
