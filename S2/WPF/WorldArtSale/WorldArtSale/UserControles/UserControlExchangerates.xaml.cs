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
    /// Interaction logic for UserControlExchangerates.xaml
    /// </summary>
    public partial class UserControlExchangerates : UserControl
    {
        ClassBiz biz;

        public UserControlExchangerates(ClassBiz inBiz)
        {
            InitializeComponent();

            biz = inBiz;
            MainGrid.DataContext = biz;
        }
    }
}
