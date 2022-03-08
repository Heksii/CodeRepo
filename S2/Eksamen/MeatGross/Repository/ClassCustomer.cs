using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassCustomer : ClassNotify
    {
        private int _id;
        private string _companyName;
        private string _address;
        private string _zipCode;
        private string _phone;
        private string _mail;
        private string _contactName;
        private ClassCountry _country;

        public ClassCustomer()
        {
            id = 0;
            companyName = "";
            address = "";
            zipCode = "";
            phone = "";
            mail = "";
            contactName = "";
            country = new ClassCountry();
        }
        public ClassCustomer(ClassCustomer inCustomer)
        {
            id = inCustomer.id;
            companyName = inCustomer.companyName;
            address = inCustomer.address;
            zipCode = inCustomer.zipCode;
            phone = inCustomer.phone;
            mail = inCustomer.mail;
            contactName = inCustomer.contactName;
            country = inCustomer.country;
        }

        public ClassCountry country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                }
                Notify("country");
            }
        }
        public string contactName
        {
            get { return _contactName; }
            set
            {
                if (_contactName != value)
                {
                    _contactName = value;
                }
                Notify("contactName");
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
        /// <summary>
        /// Denne property indeholder både post nr. og bynavn, 
        /// </summary>
        public string zipCode
        {
            get { return _zipCode; }
            set
            {
                if (_zipCode != value)
                {
                    _zipCode = value;
                }
                Notify("zipCode");
            }
        }
        public string address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                }
                Notify("adress");
            }
        }
        public string companyName
        {
            get { return _companyName; }
            set
            {
                if (_companyName != value)
                {
                    _companyName = value;
                }
                Notify("companyName");
            }
        }
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
                Notify("id");
            }
        }
    }
}
