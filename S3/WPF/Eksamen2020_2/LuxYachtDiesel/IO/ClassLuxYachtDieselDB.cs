using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace IO
{
    public class ClassLuxYachtDieselDB : ClassDbCon
    {
        #region Private Fields

        private static string sqlConStr = @"Server=(localdb)\MSSQLLOCALDB;Database=LuxYachtDieselDB;Trusted_Connection=True;";

        #endregion Private Fields

        #region Public Constructors

        public ClassLuxYachtDieselDB()
        {
            SetCon(sqlConStr);
        }

        #endregion Public Constructors

        #region Public Methods

        public List<ClassCustomer> GetAllCustomersFromDB()
        {
            List<ClassCustomer> res = new List<ClassCustomer>();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = con;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spGetAllCustomersFromDB";

                try
                {
                    using (DataTable dtres = MakeCallToStoredProcedure(command))
                    {
                        foreach (DataRow row in dtres.Rows)
                        {
                            ClassCustomer cus = new ClassCustomer();
                            ClassCountry count = new ClassCountry();
                            
                            cus.Id = (int)row["id"];
                            cus.name = row["name"].ToString();
                            cus.address = row["address"].ToString();
                            cus.city = row["city"].ToString();
                            cus.postalCode = row["postalCode"].ToString();
                            cus.phone = row["phone"].ToString();
                            cus.mailAdr = row["mailAdr"].ToString();

                            count.Id = (int)row["country"];
                            count.country = row["countryName"].ToString();
                            count.currencyCode = row["currencyCode"].ToString();
                            count.currency = row["currency"].ToString();

                            cus.country = count;
                            
                            res.Add(cus);
                        }
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
                
            }

            return res;
        }

        public List<ClassCountry> GetAllCountriesFromDB()
        {
            List<ClassCountry> res = new List<ClassCountry>();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = con;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spGetAllCountriesFromDB";

                try
                {
                    using (DataTable dtres = MakeCallToStoredProcedure(command))
                    {
                        foreach (DataRow row in dtres.Rows)
                        {
                            ClassCountry count = new ClassCountry();

                            count.Id = (int)row["Id"];
                            count.country = row["country"].ToString();
                            count.currencyCode = row["currencyCode"].ToString();
                            count.currency = row["currency"].ToString();

                            res.Add(count);
                        }
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

            }

            return res;
        }

        public List<ClassDieselPrice> GetAllOilPriceFromDB()
        {
            List<ClassDieselPrice> res = new List<ClassDieselPrice>();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = con;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spGetAllDieselPricesFromDB";

                try
                {
                    using (DataTable dtres = MakeCallToStoredProcedure(command))
                    {
                        foreach (DataRow row in dtres.Rows)
                        {
                            ClassDieselPrice cdp = new ClassDieselPrice();

                            cdp.Id = (int)row["id"];

                            double.TryParse(row["price"].ToString(), out double price);
                            cdp.price = price;
                            cdp.date = (DateTime)row["date"];

                            res.Add(cdp);
                        }
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

            }

            return res;
        }

        public List<ClassSupplier> GetAllSuppliersFromDB()
        {
            List<ClassSupplier> res = new List<ClassSupplier>();

            return res;
        }

        public ClassDieselPrice GetOilPriceFromDB()
        {
            ClassDieselPrice res = new ClassDieselPrice();

            return res;
        }

        public void InsertOilPriceInDB(ClassDieselPrice inDiesel)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSaveDieselPriceInDB";

                cmd.Parameters.Add("@date", SqlDbType.Date).Value = inDiesel.date;
                cmd.Parameters.Add("@price", SqlDbType.Money).Value = inDiesel.price;

                MakeCallToStoredProcedure(cmd);
            }
        }

        public void SaveOrderToDB(ClassOrder inOrder)
        {
        }

        public void InsertCustomerInDB(ClassCustomer inCustomer)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertCustomerInDB";

                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = inCustomer.name;
                cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = inCustomer.address;
                cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = inCustomer.city;
                cmd.Parameters.Add("@postalCode", SqlDbType.NVarChar).Value = inCustomer.postalCode;
                cmd.Parameters.Add("@country", SqlDbType.Int).Value = inCustomer.country.Id;
                cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = inCustomer.phone;
                cmd.Parameters.Add("@mailAdr", SqlDbType.NVarChar).Value = inCustomer.mailAdr;

                MakeCallToStoredProcedure(cmd);
            }
        }

        public void UpdateCustomerInDB(ClassCustomer cc)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = con;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spUpdateCustomerInDB";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = cc.name;
                command.Parameters.Add("@address", SqlDbType.NVarChar).Value = cc.address;
                command.Parameters.Add("@city", SqlDbType.NVarChar).Value = cc.city;
                command.Parameters.Add("@postalCode", SqlDbType.NVarChar).Value = cc.postalCode;
                command.Parameters.Add("@Country", SqlDbType.Int).Value = cc.country.Id;
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = cc.phone;
                command.Parameters.Add("@mailAdr", SqlDbType.NVarChar).Value = cc.mailAdr;
                command.Parameters.Add("@id", SqlDbType.Int).Value = cc.Id;

                MakeCallToStoredProcedure(command); 
            }
        }
        
        public void UpdateSupplierInDB(ClassCustomer res)
        {
        }

        #endregion Public Methods
    }
}
