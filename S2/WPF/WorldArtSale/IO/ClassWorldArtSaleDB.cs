using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace IO
{
    public class ClassWorldArtSaleDB : ClassDbCon
    {
        public ClassWorldArtSaleDB()
        {
            SetCon(@"Server=(localdb)\MSSQLLocalDB;Database=WorldArtSaleDB;Trusted_Connection=True");
        }

        public List<ClassCustomer> GetAllCustomerFromDB()
        {
            List<ClassCustomer> res = new List<ClassCustomer>();
            string sqlQuery = @"SELECT TOP (100) PERCENT Customer.id, Customer.name, Customer.adress, Customer.country, Customer.email, Customer.zipCity, Customer.phone, Customer.maximumBid, Customer.preferredCurrency, 
                                Country.code, Country.countryName, Country.valutaName
                                FROM     Country LEFT OUTER JOIN
                                Customer ON Country.id = Customer.preferredCurrency
                                WHERE  (Customer.isActive = 1)";
            try
            {

                DataTable dt = DBReturnDataTable(sqlQuery);

                foreach (DataRow row in dt.Rows)
                {
                    ClassCustomer customer = new ClassCustomer();
                    ClassCountry country = new ClassCountry();

                    customer.customerID = (int)row["id"];
                    customer.name = (string)row["name"];
                    customer.adress = (string)row["adress"];
                    customer.zipCity = (string)row["zipCity"];
                    customer.country = (string)row["country"];
                    customer.email = (string)row["email"];
                    customer.phoneNo = (string)row["phone"];
                    customer.maxBid = Convert.ToDouble(row["maximumBid"]);

                    country.code = (string)row["code"];
                    country.countryName = (string)row["countryName"];
                    country.valutaName = (string)row["valutaName"];

                    customer.customerCurrencyData = country;

                    res.Add(customer);
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                CloseDB();
            }

            return res;
        }
        public List<ClassArt> GetAllArtFromDB()
        {
            List<ClassArt> res = new List<ClassArt>();

            string sqlQuery = @"SELECT * FROM ArtTable";

            try
            {
                DataTable dt = DBReturnDataTable(sqlQuery);

                foreach (DataRow row in dt.Rows)
                {
                    ClassArt ca = new ClassArt();

                    ca.artID = Convert.ToInt32(row["id"]);
                    ca.picturePath = row["picturePath"].ToString();
                    ca.pictureDescription = row["description"].ToString();
                    ca.pictureTitle = row["title"].ToString();
                    ca.isActive = Convert.ToBoolean(row["isActive"]);

                    res.Add(ca);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB();
            }

            return res;
        }
        public List<ClassCountry> GetCountryData()
        {
            List<ClassCountry> res = new List<ClassCountry>();

            try
            {
                DataTable dt = DBReturnDataTable("SELECT * FROM Country");

                foreach (DataRow row in dt.Rows)
                {
                    ClassCountry country = new ClassCountry();

                    country.id = Convert.ToInt32(row["id"]);
                    country.code = row["code"].ToString();
                    country.countryName = row["countryName"].ToString();
                    country.valutaName = row["valutaName"].ToString();

                    res.Add(country);
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return res;
        }
        public List<ClassCountry> GetValutaData()
        {
            List<ClassCountry> res = new List<ClassCountry>();

            try
            {
                DataTable dt = DBReturnDataTable("SELECT * FROM Country ORDER BY valutaName, countryName");

                foreach (DataRow row in dt.Rows)
                {
                    ClassCountry country = new ClassCountry();

                    country.id = (int)row["id"];
                    country.code = (string)row["code"];
                    country.countryName = (string)row["countryName"];
                    country.valutaName = (string)row["valutaName"];

                    res.Add(country);
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return res;
        }
        public int InsertCountryInDB(ClassCountry inCountry)
        {
            int res = 0;
            string sqlQuery = "INSERT INTO Country " +
                                "(code, countryName, valutaName) " +
                                "VALUES " +
                                "(@code, @countryName, @valutaName) ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@code", SqlDbType.NVarChar).Value = inCountry.code;
                    cmd.Parameters.Add("@countryName", SqlDbType.NVarChar).Value = inCountry.countryName;
                    cmd.Parameters.Add("@valutaName", SqlDbType.NVarChar).Value = inCountry.valutaName;

                    OpenDB();
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                CloseDB();
            }

            return res;
        }
        public int UpdateCustomerInDB(ClassCustomer inCustomer)
        {
            int res = 0;
            string sqlQuery = "UPDATE Customer " +
                              "SET " +
                              "name = @name, " +
                              "adress = @adress, " +
                              "zipCity = @zipCity, " +
                              "country = @country, " +
                              "email = @email, " +
                              "phone = @phone, " +
                              "maximumBid = @maxBid, " +
                              "preferredCurrency = @preferredCurrency, " +
                              "isActive = @isActive " +
                              "WHERE " +
                              "id = @id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = inCustomer.name;
                    cmd.Parameters.Add("@adress", SqlDbType.NVarChar).Value = inCustomer.adress;
                    cmd.Parameters.Add("@zipCity", SqlDbType.NVarChar).Value = inCustomer.zipCity;
                    cmd.Parameters.Add("@country", SqlDbType.NVarChar).Value = inCustomer.country;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = inCustomer.email;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = inCustomer.phoneNo;
                    cmd.Parameters.Add("@maxBid", SqlDbType.Money).Value = inCustomer.maxBid;
                    cmd.Parameters.Add("@preferredCurrency", SqlDbType.Int).Value = inCustomer.customerCurrencyData.id;
                    cmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = inCustomer.isActive;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = inCustomer.customerID;

                    OpenDB();
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                CloseDB();
            }

            return res;
        }
        public int InsertCustomerInDB(ClassCustomer inCustomer)
        {
            int res = 0;

            string sqlQuery = "INSERT INTO Customer " +
                               "(name, adress, zipCity, country, email, phone, maximumBid, preferredCurrency, isActive) " +
                               "VALUES " +
                               "(@name, @adress, @zipCity, @country, @email, @phone, @maxBid, @preferredCurrency, @isActive) " +
                               "SELECT SCOPE_IDENTITY()";
                                
            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = inCustomer.name;
                    cmd.Parameters.Add("@adress", SqlDbType.NVarChar).Value = inCustomer.adress;
                    cmd.Parameters.Add("@zipCity", SqlDbType.NVarChar).Value = inCustomer.zipCity;
                    cmd.Parameters.Add("@country", SqlDbType.NVarChar).Value = inCustomer.country;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = inCustomer.email;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = inCustomer.phoneNo;
                    cmd.Parameters.Add("@maxBid", SqlDbType.Money).Value = inCustomer.maxBid;
                    cmd.Parameters.Add("@preferredCurrency", SqlDbType.Int).Value = inCustomer.customerCurrencyData.id;
                    cmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = inCustomer.isActive;

                    OpenDB();
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                CloseDB();
            }

            return res;
        }
        public int UpdateArtInDB(ClassArt inArt)
        {
            int res = 0;
            string sqlQuery = "UPDATE ArtTable " +
                              "SET " +
                              "title = @pictureTitle, " +
                              "description = @pictureDescription, " +
                              "picturePath = @picturePath, " +
                              "isActive = @isActive " +
                              "WHERE " +
                              "id = @id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@pictureTitle", SqlDbType.NVarChar).Value = inArt.pictureTitle;
                    cmd.Parameters.Add("@picturePath", SqlDbType.NVarChar).Value = inArt.picturePath;
                    cmd.Parameters.Add("@pictureDescription", SqlDbType.NVarChar).Value = inArt.pictureDescription;
                    cmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = inArt.isActive;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = inArt.artID;

                    OpenDB();
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                CloseDB();
            }

            return res;
        }
        public int InsertArtInDB(ClassArt inArt)
        {
            int res = 0;

            string sqlQuery = "INSERT INTO ArtTable " +
                               "(picturePath, description, title, isActive) " +
                               "VALUES " +
                               "(@picturePath, @pictureDescription, @pictureTitle, @isActive) " +
                               "SELECT SCOPE_IDENTITY()";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@pictureTitle", SqlDbType.NVarChar).Value = inArt.pictureTitle;
                    cmd.Parameters.Add("@picturePath", SqlDbType.NVarChar).Value = inArt.picturePath;
                    cmd.Parameters.Add("@pictureDescription", SqlDbType.NVarChar).Value = inArt.pictureDescription;
                    cmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = inArt.isActive;

                    OpenDB();
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                CloseDB();
            }

            return res;
        }
    }
}
