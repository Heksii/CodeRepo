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

namespace WorldArtSale
{
    /// <summary>
    /// Interaction logic for UserControlAuctionItem.xaml
    /// </summary>
    public partial class UserControlAuctionItem : UserControl
    {
        ClassBiz biz;
        Grid parentGrid;

        public UserControlAuctionItem(ClassBiz inBiz, Grid inGrid)
        {
            InitializeComponent();

            
            biz = inBiz;
            MainGrid.DataContext = biz;
            parentGrid = inGrid;
        }

        private void AddNewArtToDB_Click(object sender, RoutedEventArgs e)
        {
            UserControlEditAuctionItem edit = new UserControlEditAuctionItem(biz, parentGrid);
            parentGrid.Children.Add(edit);

            biz.topRightEnabled = false;
        }
    }
}
