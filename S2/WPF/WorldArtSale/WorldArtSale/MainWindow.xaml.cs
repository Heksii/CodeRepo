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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBiz biz;

        UserControlExchangerates userControlExchangerates;
        UserControlCostumer userControlCostumer;
        UserControlAuctionItem userControlAuctionItem;
        UserControlBidCalculation userControlBidCalculation;

        public MainWindow()
        {
            InitializeComponent();

            biz = new ClassBiz();
            userControlExchangerates = new UserControlExchangerates(biz);
            userControlCostumer = new UserControlCostumer(biz, GridTopLeft);
            userControlAuctionItem = new UserControlAuctionItem(biz, GridTopMiddel);
            userControlBidCalculation = new UserControlBidCalculation(biz);

            GridBottom.Children.Add(userControlExchangerates);
            GridTopLeft.Children.Add(userControlCostumer);
            GridTopRight.Children.Add(userControlBidCalculation);
            GridTopMiddel.Children.Add(userControlAuctionItem);

            MainGrid.DataContext = biz;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await biz.StartCurrencyApiCall();
        }
    }
}
