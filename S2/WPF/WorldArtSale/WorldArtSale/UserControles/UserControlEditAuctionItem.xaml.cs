using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace WorldArtSale
{
    /// <summary>
    /// Interaction logic for UserControlEditAuctionItem.xaml
    /// </summary>
    public partial class UserControlEditAuctionItem : UserControl
    {
        ClassBiz biz;
        Grid parentGrid;

        private string defaultPath;

        public UserControlEditAuctionItem(ClassBiz inBiz, Grid inGrid)
        {
            InitializeComponent();

            biz = inBiz;
            EditAuctionGrid.DataContext = biz;
            parentGrid = inGrid;

            defaultPath = @"C:\ImageSale";
        }

        private void AddNewArtToDB_Click(object sender, RoutedEventArgs e)
        {
            if (biz.editArt.pictureTitle.Trim().Length == 0 || 
                biz.editArt.picturePath.Trim().Length == 0 || 
                biz.editArt.pictureDescription.Trim().Length == 0)
            {
                MessageBox.Show("Der mangler data", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Forlad metoden hvis mindst en af fælterne er tomme
            }

            if (biz.editCustomer.customerID > 0)
            {
                biz.UpdateArt();
            }
            else
            {
                biz.AddNewArt();
            }

            parentGrid.Children.Remove(this);
        }

        private void FindImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.InitialDirectory = defaultPath;
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog().Equals(true))
                {
                    string newPath = defaultPath + @"\" + openFileDialog.SafeFileName;

                    if (!File.Exists(newPath))
                    {
                        File.Copy(openFileDialog.FileName, newPath);
                    }

                    biz.editArt.picturePath = newPath;
                }
            }
            catch (IOException ex)
            {

                throw ex;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Opacity = box.Text.Length > 0 ? 1 : 0.6;
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            biz.editArt = new ClassArt();
            parentGrid.Children.Remove(this);

            biz.topMiddleEnabled = biz.classCustomer.customerID > 0;
            biz.topRightEnabled = biz.classCustomer.customerID > 0 && biz.classArt.artID > 0;
        }
    }
}
