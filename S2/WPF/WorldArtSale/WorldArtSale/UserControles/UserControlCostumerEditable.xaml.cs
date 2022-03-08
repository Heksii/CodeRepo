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

namespace WorldArtSale
{
    /// <summary>
    /// Interaction logic for UserControlCostumerEditable.xaml
    /// </summary>
    public partial class UserControlCostumerEditable : UserControl
    {
        ClassBiz biz;
        Grid parentGrid;

        public UserControlCostumerEditable(ClassBiz inBiz, Grid inGrid)
        {
            InitializeComponent();
            GridCostumerEditable.DataContext = inBiz;

            biz = inBiz;
            parentGrid = inGrid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (biz.editCustomer.customerID > 0)
            {
                biz.UpdateCustomer();
                parentGrid.Children.Remove(this);
            }
            else
            {
                biz.AddNewCustomer();
                parentGrid.Children.Remove(this);
            }
            
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            biz.editCustomer = new ClassCustomer();
            parentGrid.Children.Remove(this);

            biz.topMiddleEnabled = biz.classCustomer.customerID > 0;
            biz.topRightEnabled = biz.classCustomer.customerID > 0 && biz.classArt.artID > 0;
        }
    }
}
