using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Denne class er en simpel datatype der kan holde et Id, streetName, streetNumber, zipCode og cityName.
    /// </summary>
    public class ClassZipCity : ClassNotify
    {
        /// <summary>
        /// Samling af fields der knytter sig til de Property der er oprettet i denne class.
        /// </summary>
        private int _Id;
        private string _streetName;
        private string _streetNumber;
        private string _zipCode;
        private string _cityName;

        /// <summary>
        /// Default konstruktor hvor alle Property initialiseres til en standardværdi.
        /// </summary>
        public ClassZipCity()
        {
            Id = 0;
            streetName = "";
            streetNumber = "";
            zipCode = "";
            cityName = "";
        }
        /// <summary>
        /// Overloaded konstruktor som modtager et parameter af datatypen ClassZipCity.
        /// Værdierne fra parameteren indsættes i den nye instans af ClassZipCity.
        /// </summary>
        /// <param name="inZip">ClassZipCity</param>
        public ClassZipCity(ClassZipCity inZip)
        {
            Id = inZip.Id;
            streetName = inZip.streetName;
            streetNumber = inZip.streetNumber;
            zipCode = inZip.zipCode;
            cityName = inZip.cityName;
        }

        /// <summary>
        /// Property cityName holder en string med navnet på byen
        /// </summary>
        public string cityName
        {
            get { return _cityName; }
            set
            {
                if (_cityName != value)
                {
                    _cityName = value;
                }
                Notify("cityName");
            }
        }
        /// <summary>
        /// Property zipCode holder en string med postnummeret på byen
        /// </summary>
        public string zipCode
        {
            get { return _zipCode; }
            set
            {
                if (int.TryParse(value, out int X) || value == "")
                {
                    if (_zipCode != value)
                    {
                        _zipCode = value;
                    }
                }                
                Notify("zipCode");
            }
        }
        /// <summary>
        /// Property streetNumber holder en string med husnummeret
        /// </summary>
        public string streetNumber
        {
            get { return _streetNumber; }
            set
            {
                if (_streetNumber != value)
                {
                    _streetNumber = value;
                }
                Notify("streetNumber");
            }
        }
        /// <summary>
        /// Property streetName holder en string med navnet på gaden eller vejen
        /// </summary>
        public string streetName
        {
            get { return _streetName; }
            set
            {
                if (_streetName != value)
                {
                    _streetName = value;
                }
                Notify("streetName");
            }
        }
        /// <summary>
        /// Property Id holder en int med en unik værdi for denne instans
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                }
                Notify("Id");
            }
        }
    }
}
