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
    /// Interaction logic for UserControlDailyPrice.xaml
    /// </summary>
    public partial class UserControlDailyPrice : UserControl
    {
        ClassBIZ biz;

        public UserControlDailyPrice(ClassBIZ inBiz)
        {
            InitializeComponent();
            
            biz = inBiz;
            MainGrid.DataContext = biz;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(newDieselPrice.Text, out double resText))
            {
                biz.dieselPrice = new ClassDieselPrice();
                biz.dieselPrice.price = resText;
                biz.dieselPrice.date = DateTime.Now;

                biz.InsertDieselPriceInDB();
            }
            else
            {
                MessageBox.Show("Ugyldig værdi.", "Fejl!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
