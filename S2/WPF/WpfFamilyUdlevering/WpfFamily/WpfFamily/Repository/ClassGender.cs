using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Denne class er en simpel datatype der kan holde et Id og tekst med kønsidentifikation
    /// </summary>
    public class ClassGender : ClassNotify
    {
        /// <summary>
        /// De fields der knytter sig til de Property som er oprettet i ClassGender
        /// </summary>
        private int _Id;
        private string _genderType;


        /// <summary>
        /// Default konstruktor hvor alle Property initialiseres til en standardværdi.
        /// </summary>
        public ClassGender()
        {
            Id = 0;
            genderType = "";
        }
        /// <summary>
        /// Overloaded konstruktor som modtager et parameter af datatypen ClassGender.
        /// Værdierne fra parameteren indsættes i den nye instans af ClassGender.
        /// </summary>
        /// <param name="inGender">ClassGender</param>
        public ClassGender(ClassGender inGender)
        {
            Id = inGender.Id;
            genderType = inGender.genderType;
        }

        /// <summary>
        /// Parameteren genderType holder en string der beskriver en given kønsidentifikation.
        /// </summary>
        public string genderType
        {
            get { return _genderType; }
            set
            {
                if (_genderType != value)
                {
                    _genderType = value;
                }
                Notify("genderType");
            }
        }
        /// <summary>
        /// Parameteren Id holder den unikke identifikator som er knyttet til kønsidentifikationen som beskrevet i genderTYpe
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
