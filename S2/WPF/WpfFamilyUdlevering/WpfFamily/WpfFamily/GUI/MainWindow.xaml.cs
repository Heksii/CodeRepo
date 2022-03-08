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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBIZ BIZ; // Her oprettes en tom instans af ClassBIZ hvor værdien af indholdet = NULL
        public MainWindow()
        {
            InitializeComponent(); // Denne metode ligger i Window, som er en Class der nedarves. Dnne metode læser XAML koden og laver brugergrænsefladen.
            BIZ = new ClassBIZ();  // Her initiliseres den tomm instans af BIZ til en instans med alle metoder og property der forefides i ClassBIZ.
            MainGrid.DataContext = BIZ;  // Her skabes forbindelsen mellem GUI og den Class (ClassBIZ) der skal benyttes i forbindelse med Binding.
        }

        /// <summary>
        /// Denne evnthandler, håndtere hvilke elementer der må tilgåes når der klikkes på knappen "Opret".
        /// Fjerner selectionen i ListView.
        /// Gør ListView utilgængelig.
        /// Sørger for at det bliver muligt at redigere i tekstfelterne.
        /// 
        /// Laver en ny instans af selectedPerson som indsættes i fallbackPerson.
        /// Initilisere selectedPerson med en ny instans af ClassPerson
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void ButtonOpret_Click(object sender, RoutedEventArgs e)
        {
            ButtonRediger.IsEnabled = false;
            ButtonSlet.IsEnabled = false;
            ButtonOpret.IsEnabled = false;
            ButtonGem.IsEnabled = true;
            ButtonFortryd.IsEnabled = true;

            MainList.SelectedItem = -1;
            MainList.IsEnabled = false;

            BIZ.textLock = false;
            BIZ.comboLock = true;

            BIZ.fallbackPerson = new ClassPerson(BIZ.selectedPerson);
            BIZ.selectedPerson = new ClassPerson();
        }

        private void ButtonRediger_Click(object sender, RoutedEventArgs e)
        {
            ButtonRediger.IsEnabled = false;
            ButtonSlet.IsEnabled = false;
            ButtonOpret.IsEnabled = false;
            ButtonGem.IsEnabled = true;
            ButtonFortryd.IsEnabled = true;

            MainList.SelectedItem = -1;
            MainList.IsEnabled = false;

            BIZ.textLock = false;
            BIZ.comboLock = true;
            if (BIZ.selectedPerson.Id != 0)
            {
                BIZ.fallbackPerson = new ClassPerson(BIZ.selectedPerson);
            }
            
        }

        /// <summary>
        /// Denne eventhandler håndtere handlingen når brugeren vil slette en person.
        /// Brugeren får mulighed for at fortryde, da der fremkommer en MessageBox med en tekst 
        /// som brugeren skal tage stilling til og svare Yes eller No til om man er sikker på der skal slettes.
        /// Hvis brugeren klikker Yes - Slettes personen uden yderligere advarsel
        /// Hvis brugeren klikker No - Bliver handlingen afbrudt og intet har ændret sig.
        /// MessageBoxen bliver indlejret i en if, som gøres afhængig af brugerens valg.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void ButtonSlet_Click(object sender, RoutedEventArgs e)
        {
            if (BIZ.selectedPerson.Id > 0)
            {
                if (MessageBox.Show("Er du sikker på at du vil slette\ndette familiemedlem for altid\nog uden mulighed for at fortryde?", "Fortryd eller ej !!!!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    BIZ.DeletPersonInDB();
                    BIZ.selectedPerson = new ClassPerson();
                    BIZ.listPerson = new List<ClassPerson>();
                    BIZ.InsertAllPersonsInListView();
                }
                //else
                //{
                //    MessageBox.Show("IKKE  -   SLETTÈT");
                //}
            }
            
        }

        private void ButtonGem_Click(object sender, RoutedEventArgs e)
        {
            BIZ.textLock = true;
            BIZ.comboLock = false;
            // Kald til metode der indsætter data i listen
            if (BIZ.selectedPerson.Id > 0)
            {
                try
                {
                    BIZ.UpdatePersonInDB();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    BIZ.InsertNewPersonInDB();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            ButtonRediger.IsEnabled = true;
            ButtonSlet.IsEnabled = true;
            ButtonOpret.IsEnabled = true;
            ButtonGem.IsEnabled = false;
            ButtonFortryd.IsEnabled = false;

            MainList.IsEnabled = true;

            BIZ.listPerson = new List<ClassPerson>();
            BIZ.InsertAllPersonsInListView();

            foreach (ClassPerson person in MainList.Items)
            {
                if (person.Id == BIZ.fallbackPerson.Id)
                {
                    MainList.SelectedItem = person;
                }
            }
        }

        private void ButtonFortryd_Click(object sender, RoutedEventArgs e)
        {
            ButtonRediger.IsEnabled = true;
            ButtonSlet.IsEnabled = true;
            ButtonOpret.IsEnabled = true;
            ButtonGem.IsEnabled = false;
            ButtonFortryd.IsEnabled = false;

            BIZ.textLock = true;
            BIZ.comboLock = false;

            MainList.IsEnabled = true;

            BIZ.selectedPerson = new ClassPerson(BIZ.fallbackPerson);
            BIZ.fallbackPerson = new ClassPerson();
            MainList.IsEnabled = true;

            foreach (var item in MainList.Items)
            {
                ClassPerson X = (ClassPerson)item;
                if (X.Id == BIZ.selectedPerson.Id)
                {
                    MainList.SelectedItem = item;
                }
            }

        }

        private void zipNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Trim().Length >= 1)
            {
                if (int.TryParse(tb.Text.Trim(),out int X))
                {
                    BIZ.InsertCityNameInGUI();
                }
            }
        }
    }
}
