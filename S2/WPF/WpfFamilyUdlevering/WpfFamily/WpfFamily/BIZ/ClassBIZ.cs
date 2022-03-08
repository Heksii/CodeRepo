using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using IO;

namespace BIZ
{
    /// <summary>
    /// Denne class repræsentere forretningslaget i denne applikation.
    /// Det er i denne class at alle funktioner til manipulation af data ligger.
    /// </summary>
    public class ClassBIZ : ClassNotify
    {
        /// <summary>
        /// Samling af fields der knytter sig til de Property der er oprettet i denne class.
        /// </summary>
        private ClassPerson _selectedPerson;
        private ClassPerson _fallbackPerson;
        private List<ClassPerson> _listPerson;
        private bool _textLock;
        private bool _comboLock;

        ClassFamilyDB CFB = new ClassFamilyDB();

        /// <summary>
        /// Default konstruktor hvor alle Property initialiseres til en standardværdi.
        /// 
        /// I forbindelse med test, foretages et kald til metoden InsertDataInListView()
        /// </summary>
        public ClassBIZ()
        {
            selectedPerson = new ClassPerson();
            fallbackPerson = new ClassPerson();
            listPerson = new List<ClassPerson>();
            listGender = CFB.GetAllGenderFromDB();
            textLock = true;
            comboLock = false;
            InsertAllPersonsInListView();
            //InsertDataInListView();
        }

        

        

        public bool comboLock
        {
            get { return _comboLock; }
            set
            {
                if (_comboLock != value)
                {
                    _comboLock = value;
                }
                Notify("comboLock");
            }
        }

        private List<ClassGender> _listGender;
        public List<ClassGender> listGender
        {
            get { return _listGender; }
            set
            {
                if (_listGender != value)
                {
                    _listGender = value;
                }
                Notify("listGender");
            }
        }


        


        /// <summary>
        /// Property textLock holder en bool med angivelse af om TextBox på GUI kan redigeres af brugeren
        /// </summary>
        public bool textLock
        {
            get { return _textLock; }
            set
            {
                if (_textLock != value)
                {
                    _textLock = value;
                }
                Notify("textLock");
            }
        }

        /// <summary>
        /// Property listPerson holder en colection af datatypen ClassPerson.
        /// Denne samling udgør datagrundlaget for ListView på GUI
        /// </summary>
        public List<ClassPerson> listPerson
        {
            get { return _listPerson; }
            set
            {
                if (_listPerson != value)
                {
                    _listPerson = value;
                }
                Notify("listPerson");
            }
        }

        /// <summary>
        /// Property selectedPerson holder den i ListView selectede person.
        /// Når der bliver selected en person i ListView, overføres der fra ListView
        /// en instans af ClassPerson med data til selectedPerson.
        /// Alle TextBoxe på GUI er Binded til Property selectedPerson, så når der 
        /// selectes en person i ListView, vises alle data knyttet til denne person
        /// i de TextBoxe dere står til højre for ListView på GUI.
        /// </summary>
        public ClassPerson selectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                if (_selectedPerson != value)
                {
                    _selectedPerson = value;
                    //fallbackPerson = new ClassPerson(selectedPerson);
                }
                Notify("selectedPerson");
            }
        }
        /// <summary>
        /// Property fallbackPerson bruges som sikkerhedskopi af den sidst valgte pereson
        /// i forbindelse med Redigering og Opretelse af personer.
        /// </summary>
        public ClassPerson fallbackPerson
        {
            get { return _fallbackPerson; }
            set
            {
                if (_fallbackPerson != value)
                {
                    _fallbackPerson = value;
                }
            }
        }

        /// <summary>
        /// Denne metode benyttes kun i forbindelse med test og udvikling.
        /// Metoden har til formål at oprette 4 tilfældige dummy test datasæt.
        /// </summary>
        private void InsertDataInListView()
        {
            List<ClassPerson> LCP = new List<ClassPerson>(); // Tom instans af samme type som listPerson

            for (int i = 1; i <= 4; i++)
            {
                ClassPerson CP = new ClassPerson(); // Tom instans af samme type som kan indsættes i listPerson

                CP.name = "Hans Hansen " + i.ToString();
                CP.zipCity.streetName = "Borgergade";
                CP.zipCity.streetNumber = "" + i.ToString();
                CP.zipCity.zipCode = "650" + i.ToString();
                CP.zipCity.cityName = "Horsens C";
                CP.gender.genderType = "Type " + i.ToString();
                CP.phone = "31 32 20 3" + i.ToString();
                CP.mail = "jecl@aspit.dk";
                CP.job = "Lottospiller nr. " + i.ToString();
                CP.birthday = Convert.ToDateTime("1" + i.ToString() + "-05-1987");

                LCP.Add(CP);
            }
        }

        public void InsertAllPersonsInListView()
        {
            listPerson = CFB.spGetAllPersonsFromDB();
        }

        public void InsertNewPersonInDB()
        {
            selectedPerson.Id = CFB.spInsertPersonInDB(selectedPerson);
        }

        public void DeletPersonInDB()
        {
            CFB.spDeletePerson(selectedPerson);
        }

        public void UpdatePersonInDB()
        {
            CFB.spUpdatePersonInDB(selectedPerson);
        }

        public void InsertCityNameInGUI()
        {
            selectedPerson.zipCity.cityName = CFB.spGetCityName(selectedPerson.zipCity.zipCode);
        }
    }
}
