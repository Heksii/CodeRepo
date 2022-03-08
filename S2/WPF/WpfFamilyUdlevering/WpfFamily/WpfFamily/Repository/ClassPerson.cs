using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassPerson : ClassNotify
    {
        private int _Id;
        private string _name;
        private ClassGender _gender;
        private ClassZipCity _zipCity;
        private string _phone;
        private string _mail;
        private string _stringBirthday;
        private DateTime _birthday;
        private string _job;
        

        public ClassPerson()
        {
            Id = 0;
            name = "";
            gender = new ClassGender();
            zipCity = new ClassZipCity();
            phone = "";
            mail = "";
            stringBirthday = "";
            birthday = DateTime.Now;// Convert.ToDateTime("05-05-1945");
            job = "";
        }

        public ClassPerson(ClassPerson inPerson)
        {
            Id = inPerson.Id;
            name = inPerson.name;
            gender = new ClassGender(inPerson.gender);
            zipCity = new ClassZipCity(inPerson.zipCity);
            phone = inPerson.phone;
            mail = inPerson.mail;             
            birthday = inPerson.birthday;
            job = inPerson.job;
        }

        

        public string stringBirthday
        {
            get { return _stringBirthday; }
            set
            {
                if (_stringBirthday != value)
                {
                    _stringBirthday = value;
                }
                Notify("stringBirthday");
            }
        }



        public string job
        {
            get { return _job; }
            set
            {
                if (_job != value)
                {
                    _job = value;
                }
                Notify("job");
            }
        }


        public DateTime birthday
        {
            get { return _birthday; }
            set
            {                
                if (_birthday != value)
                {
                    if (value <= DateTime.Now)
                    {
                        _birthday = value;
                        stringBirthday = _birthday.ToLongDateString();
                    }
                    else
                    {
                        _birthday = DateTime.Now;
                        stringBirthday = _birthday.ToLongDateString();
                    }
                }
                Notify("birthday");
            }
        }


        public string mail
        {
            get { return _mail; }
            set
            {
                if (_mail != value)
                {
                    _mail = value;
                }
                Notify("mail");
            }
        }


        public string phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                }
                Notify("phone");
            }
        }


        public ClassZipCity zipCity
        {
            get { return _zipCity; }
            set
            {
                if (_zipCity != value)
                {
                    _zipCity = value;
                }
                Notify("zipCity");
            }
        }


        public ClassGender gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                }
                Notify("gender");
            }
        }


        public string name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                }
                Notify("name");
            }
        }


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
