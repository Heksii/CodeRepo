using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Repository;

namespace IO
{
    public class ClassMeatGrossDB : ClassDbCon
    {
        public ClassMeatGrossDB()
        {

        }

        public List<ClassCustomer> GetAllCustomersFromDB(ClassApiRates rates)
        {
            List<ClassCustomer> res = new List<ClassCustomer>();

            string sqlQuery =  "SELECT " +
                               "Customer.Id, Customer.CompanyName, Customer.Address, Customer.ZipCode, Customer.Phone, Customer.Mail, Customer.ContactName, CountryAndRates.CountryCode, " +
                               "CountryAndRates.CountryName, CountryAndRates.ValutaName, CountryAndRates.ValutaRate, CountryAndRates.UpdateTime, Customer.Country " +
                               "FROM   " +
                               "Customer " +
                               "LEFT OUTER JOIN " +
                               "CountryAndRates ON Customer.Country = CountryAndRates.Id";
            try
            {
                DataTable dt = DBReturnDataTable(sqlQuery);
                foreach (DataRow row in dt.Rows)
                {
                    ClassCustomer cc = new ClassCustomer();
                    ClassCountry co = new ClassCountry();

                    cc.id = Convert.ToInt32(row["Id"]);
                    cc.companyName = row["CompanyName"].ToString();
                    cc.address = row["Address"].ToString();
                    cc.zipCode = row["ZipCode"].ToString();
                    cc.phone = row["Phone"].ToString();
                    cc.mail = row["Mail"].ToString();
                    cc.contactName = row["ContactName"].ToString();

                    co.id = (int)row["Country"];
                    co.countryCode = row["CountryCode"].ToString();
                    co.countryName = row["CountryName"].ToString();
                    co.valutaName = row["ValutaName"].ToString();
                    co.valutaRate = rates.Rates[row["CountryCode"].ToString()];
                    co.updateTime = Convert.ToDateTime(row["UpdateTime"]);

                    cc.country = co;

                    res.Add(cc);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"ERROR Data Request did not return a Vaild Result! :\n\n {ex.Message}\n\n", "SQL-QUERY ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return res;
        }

        public List<ClassCountry> GetAllCountriesFromDB(ClassApiRates rates)
        {
            List<ClassCountry> res = new List<ClassCountry>();

            string sqlQuery = "SELECT * FROM dbo.CountryAndRates";

            try
            {
                DataTable dt = DBReturnDataTable(sqlQuery);
                foreach (DataRow row in dt.Rows)
                {
                    ClassCountry co = new ClassCountry();

                    co.id = Convert.ToInt32(row["id"]);
                    co.countryCode = row["CountryCode"].ToString();
                    co.countryName = row["CountryName"].ToString();
                    co.valutaName = row["ValutaName"].ToString();
                    co.valutaRate = rates.Rates[row["CountryCode"].ToString()];
                    co.updateTime = Convert.ToDateTime(row["UpdateTime"]);

                    res.Add(co);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"ERROR Data Request did not return a Vaild Result! : {ex.Message}", "SQL-QUERY ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return res;
        }

        public List<ClassMeat> GetAllMeatFromDB()
        {
            List<ClassMeat> res = new List<ClassMeat>();

            string sqlQuery = "SELECT * FROM dbo.Meat";

            try
            {
                DataTable dt = DBReturnDataTable(sqlQuery);
                foreach (DataRow row in dt.Rows)
                {
                    ClassMeat cm = new ClassMeat();

                    cm.id = Convert.ToInt32(row["Id"]);
                    cm.typeOfMeat = row["TypeOfMeat"].ToString();
                    cm.stock = row["Stock"].ToString();
                    cm.pricePerKG = Convert.ToDouble(row["Price"]);
                    cm.pricePerKGTimestamp = Convert.ToDateTime(row["PriceTimeStamp"]);

                    res.Add(cm);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"ERROR Data Request did not return a Vaild Result! : {ex.Message}", "SQL-QUERY ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return res;
        }

        public int SaveNewCustomerInDB(ClassCustomer inCustomer)
        {
            int res = 0;

            string sqlQuery = @"INSERT INTO Customer (CompanyName, Address, ZipCode, Phone, Mail, ContactName, Country) VALUES
                                (@CompanyName, @Address, @ZipCode, @Phone, @Mail, @ContactName, @Country)
                                SELECT SCOPE_IDENTITY()";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = inCustomer.companyName;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = inCustomer.address;
                    cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = inCustomer.zipCode;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = inCustomer.phone;
                    cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = inCustomer.mail;
                    cmd.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = inCustomer.contactName;
                    cmd.Parameters.Add("@Country", SqlDbType.Int).Value = inCustomer.country.id;

                    OpenDB();
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"ERROR Data Request did not return a Vaild Result! : {ex.Message}", "SQL-QUERY ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                CloseDB();
            }

            return res;
        }

        public void UpdateCustomerInDB(ClassCustomer inCustomer)
        {
            int res = 0;
            string sqlQuery = "UPDATE Customer " +
                              "SET CompanyName = @CompanyName, " +
                              "Address = @Address, " +
                              "ZipCode = @ZipCode, " +
                              "Phone = @Phone, " +
                              "Mail = @Mail, " +
                              "ContactName = @ContactName, " +
                              "Country = @Country " +
                              "WHERE id = @id";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = inCustomer.id;

                    cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = inCustomer.companyName;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = inCustomer.address;
                    cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = inCustomer.zipCode;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = inCustomer.phone;
                    cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = inCustomer.mail;
                    cmd.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = inCustomer.contactName;
                    cmd.Parameters.Add("@Country", SqlDbType.Int).Value = inCustomer.country.id;

                    OpenDB();
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"ERROR Data Request did not return a Vaild Result! : {ex.Message}", "SQL-QUERY ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                CloseDB();
            }
        }

        public void UpdateMeatVolume(ClassOrder inOrder)
        {

        }

        public void UpdatePriceForMeatInDB(string inMeat, double inPrice, int inWeight)
        {

        }

        public void UpdateTimestampForMeats()
        {

        }

        public int AddOrderToDB(ClassOrder inOrder)
        {
            int res = 0;


            return res;
        }
    }
}
