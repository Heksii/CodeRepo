using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using System.Data;
using System.Data.SqlClient;

namespace IO
{
    public class ClassFamilyDB : ClassDbCon
    {
        public ClassFamilyDB() : base(@"Server=(localdb)\MSSQLLocalDB;Database=FamilyDB;Trusted_Connection=True")
        {

        }

        public List<ClassPerson> GetAllPersonsFromDB()
        {
            List<ClassPerson> listPerson = new List<ClassPerson>();

            string sqlQuery = @"SELECT Familymembers.Id, Familymembers.name, Familymembers.adress, Familymembers.steetNo, Familymembers.phone, Familymembers.mail, Familymembers.birthday, Familymembers.job, 
                    Familymembers.zipCode, ZipCity.cityName, ZipCity.streetName, Familymembers.genderId, Gender.genderDescription
                    FROM     Familymembers LEFT OUTER JOIN
                    ZipCity ON Familymembers.zipCode = ZipCity.zipCode LEFT OUTER JOIN
                    Gender ON Familymembers.genderId = Gender.Id";

            DataTable DT = DBReturnDataTable(sqlQuery);

            foreach (DataRow row in DT.Rows)
            {
                ClassPerson person = new ClassPerson();
                ClassGender gender = new ClassGender();
                ClassZipCity city = new ClassZipCity();

                gender.Id = (int)row["genderId"];
                gender.genderType = row["genderDescription"].ToString();
                
                city.zipCode = row["zipCode"].ToString();
                city.cityName = row["cityName"].ToString();
                city.streetName = row["adress"].ToString();
                city.streetNumber = row["steetNo"].ToString();

                person.Id = (int)row["Id"];
                person.name = row["name"].ToString();
                person.birthday = (DateTime)row["birthday"];
                person.job = row["job"].ToString();
                person.mail = row["mail"].ToString();
                person.phone = row["phone"].ToString();

                person.gender = gender;
                person.zipCity = city;

                listPerson.Add(person);
            }

            return listPerson;
        }

        public List<ClassGender> GetAllGenderFromDB()
        {
            List<ClassGender> genderList = new List<ClassGender>();

            string sqlQuery = @"SELECT *
                                FROM Gender";

            DataTable DT = DBReturnDataTable(sqlQuery);

            foreach (DataRow row in DT.Rows)
            {
                ClassGender gender = new ClassGender();
                gender.Id = (int)row["Id"];
                gender.genderType = row["genderDescription"].ToString();

                genderList.Add(gender);
            }

            return genderList;
        }
    
        public int UpdatePersonInDB(ClassPerson inPerson)
        {
            int res = 0;

            string sqlQuery =
                "UPDATE Familymembers " + 
                "SET " + 
                "name = @navn, " + 
                "adress = @adresse, " + 
                "steetNo = @gadenr, " + 
                "phone = @telefonNr, " + 
                "mail = @mail, " +
                "birthday = @foedselsdag, " +
                "job = @arbejde, " +
                "zipCode = @postNr, " +
                "genderId = @koen " +
                "WHERE " +
                "Id = @personId";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@personId", SqlDbType.Int).Value = inPerson.Id;
                    cmd.Parameters.Add("@navn", SqlDbType.NVarChar).Value = inPerson.name;
                    cmd.Parameters.Add("@adresse", SqlDbType.NVarChar).Value = inPerson.zipCity.streetName;
                    cmd.Parameters.Add("@gadeNr", SqlDbType.NVarChar).Value = inPerson.zipCity.streetNumber;
                    cmd.Parameters.Add("@telefonNr", SqlDbType.NVarChar).Value = inPerson.phone;
                    cmd.Parameters.Add("@mail", SqlDbType.NVarChar).Value = inPerson.mail;
                    cmd.Parameters.Add("@foedselsdag", SqlDbType.Date).Value = inPerson.birthday;
                    cmd.Parameters.Add("@arbejde", SqlDbType.NVarChar).Value = inPerson.job;
                    cmd.Parameters.Add("@postNr", SqlDbType.NVarChar).Value = inPerson.zipCity.zipCode;
                    cmd.Parameters.Add("@koen", SqlDbType.Int).Value = inPerson.gender.Id;

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
    
        public int InsertPersonInDB(ClassPerson inPerson)
        {
            int res = 0;
            string sqlQuery = 
                "INSERT INTO Familymembers " +
                "(name, adress, steetNo, phone, mail, birthday, job, zipCode, genderId) " +
                "VALUES " +
                "(@name, @adress, @steetNo, @phone, @mail, @birthday, @job, @zipCode, @genderId) " +
                "SELECT SCOPE_IDENTITY()";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = inPerson.name;
                    cmd.Parameters.Add("@adress", SqlDbType.NVarChar).Value = inPerson.zipCity.streetName;
                    cmd.Parameters.Add("@steetNo", SqlDbType.NVarChar).Value = inPerson.zipCity.streetNumber;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = inPerson.phone;
                    cmd.Parameters.Add("@mail", SqlDbType.NVarChar).Value = inPerson.mail;
                    cmd.Parameters.Add("@birthday", SqlDbType.Date).Value = inPerson.birthday;
                    cmd.Parameters.Add("@job", SqlDbType.NVarChar).Value = inPerson.job;
                    cmd.Parameters.Add("@zipCode", SqlDbType.NVarChar).Value = inPerson.zipCity.zipCode;
                    cmd.Parameters.Add("@genderId", SqlDbType.Int).Value = inPerson.gender.Id;

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
    
        public int DeletePerson(ClassPerson inPerson)
        {
            return ExecuteNonQuery($"DELETE FROM Familymembers WHERE Id = {inPerson.Id}");
        }

        public string GetCityName(string inZipCode)
        {
            string res = DbReturnString($"SELECT cityName FROM ZipCity WHERE zipCode LIKE '{inZipCode}%'");
            
            return res;
        }

        // Stored procedures

        public List<ClassPerson> spGetAllPersonsFromDB()
        {
            List<ClassPerson> res = new List<ClassPerson>();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetAllPersonsFromDB";

                using (DataTable dt = MakeCallToStoredProcedure(cmd))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ClassPerson person = new ClassPerson();
                        ClassGender gender = new ClassGender();
                        ClassZipCity city = new ClassZipCity();

                        gender.Id = (int)row["genderId"];
                        gender.genderType = row["genderDescription"].ToString();

                        city.zipCode = row["zipCode"].ToString();
                        city.cityName = row["cityName"].ToString();
                        city.streetName = row["adress"].ToString();
                        city.streetNumber = row["steetNo"].ToString();

                        person.Id = (int)row["Id"];
                        person.name = row["name"].ToString();
                        person.birthday = (DateTime)row["birthday"];
                        person.job = row["job"].ToString();
                        person.mail = row["mail"].ToString();
                        person.phone = row["phone"].ToString();

                        person.gender = gender;
                        person.zipCity = city;

                        res.Add(person);
                    }
                }
            }

            return res;
        }

        public List<ClassGender> spGetAllGenderFromDB()
        {
            List<ClassGender> res = new List<ClassGender>();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetAllGenderFromDB";

                using (DataTable dt = MakeCallToStoredProcedure(cmd))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ClassGender gender = new ClassGender();
                        gender.Id = (int)row["Id"];
                        gender.genderType = row["genderDescription"].ToString();

                        res.Add(gender);
                    }
                }
            }

            return res;
        }

        public int spUpdatePersonInDB(ClassPerson inPerson)
        {
            int res = 0;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertPersonInDB";

                cmd.Parameters.Add("@personId", SqlDbType.Int).Value = inPerson.Id;
                cmd.Parameters.Add("@navn", SqlDbType.NVarChar).Value = inPerson.name;
                cmd.Parameters.Add("@adresse", SqlDbType.NVarChar).Value = inPerson.zipCity.streetName;
                cmd.Parameters.Add("@gadeNr", SqlDbType.NVarChar).Value = inPerson.zipCity.streetNumber;
                cmd.Parameters.Add("@telefonNr", SqlDbType.NVarChar).Value = inPerson.phone;
                cmd.Parameters.Add("@mail", SqlDbType.NVarChar).Value = inPerson.mail;
                cmd.Parameters.Add("@foedselsdag", SqlDbType.Date).Value = inPerson.birthday;
                cmd.Parameters.Add("@arbejde", SqlDbType.NVarChar).Value = inPerson.job;
                cmd.Parameters.Add("@postNr", SqlDbType.NVarChar).Value = inPerson.zipCity.zipCode;
                cmd.Parameters.Add("@koen", SqlDbType.Int).Value = inPerson.gender.Id;

                using (DataTable dt = MakeCallToStoredProcedure(cmd))
                {
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    res = row["cityName"].ToString();
                    //}
                }
            }

            return res;
        }

        public int spInsertPersonInDB(ClassPerson inPerson)
        {
            int res = 0;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertPersonInDB";

                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = inPerson.name;
                cmd.Parameters.Add("@adress", SqlDbType.NVarChar).Value = inPerson.zipCity.streetName;
                cmd.Parameters.Add("@steetNo", SqlDbType.NVarChar).Value = inPerson.zipCity.streetNumber;
                cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = inPerson.phone;
                cmd.Parameters.Add("@mail", SqlDbType.NVarChar).Value = inPerson.mail;
                cmd.Parameters.Add("@birthday", SqlDbType.Date).Value = inPerson.birthday;
                cmd.Parameters.Add("@job", SqlDbType.NVarChar).Value = inPerson.job;
                cmd.Parameters.Add("@zipCode", SqlDbType.NVarChar).Value = inPerson.zipCity.zipCode;
                cmd.Parameters.Add("@genderId", SqlDbType.Int).Value = inPerson.gender.Id;

                using (DataTable dt = MakeCallToStoredProcedure(cmd))
                {
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    res = row["cityName"].ToString();
                    //}
                }
            }

            return res;
        }

        public int spDeletePerson(ClassPerson inPerson)
        {
            int res = 0;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spDeletePerson";

                cmd.Parameters.Add("@personId", SqlDbType.Int).Value = inPerson.Id;

                using (DataTable dt = MakeCallToStoredProcedure(cmd))
                {
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    res = row["cityName"].ToString();
                    //}
                }
            }

            return res;
        }

        public string spGetCityName(string inZip)
        {
            string res = "";

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetCityName";

                cmd.Parameters.Add("@inZipCode", SqlDbType.NVarChar).Value = inZip;

                using (DataTable dt = MakeCallToStoredProcedure(cmd))
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        res = row["cityName"].ToString();
                    }
                }
            }

            return res;
        }
    }
}
