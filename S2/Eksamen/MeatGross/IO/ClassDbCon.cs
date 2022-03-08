using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace IO
{
    /// <summary>
    /// Denne class har ansvaret for kommunikationen
    /// med den database der bliver knyttet til via
    /// den aktive ConnectionString
    /// </summary>
    public class ClassDbCon
    {
        private string _connectionString;
        protected SqlConnection con;
        private SqlCommand _command;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ClassDbCon()
        {
            _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=MeatGrossDB;Trusted_Connection=True";
            con = new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Overloaded constructor med en parameter der initialisere '_connectionString' til verdien af den parameter
        /// </summary>
        /// <param name="inConnectionString">string</param>
        public ClassDbCon(string inConnectionString)
        {
            _connectionString = inConnectionString;
            con = new SqlConnection(_connectionString);
        }

        /// <summary>
        /// En metode med en string parameter der sætter '_connectionString' til verdien af parameteren
        /// </summary>
        /// <param name="inConnectionString">string</param>
        protected void SetCon(string inConnectionString)
        {
            _connectionString = inConnectionString;
            con = new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Denne metode åbner forbindelsen til databasen
        /// </summary>
        protected void OpenDB()
        {
            try
            {
                if (this.con != null && this.con.State == ConnectionState.Closed)
                {
                    // Hvis databasen er lukket så åben forbindelsen
                    this.con.Open();
                }
                else
                {
                    if (this.con.State == ConnectionState.Open)
                    {
                        // Hvis databasen allerede er åben så lukker den databasen og metoden kalder sig selv igen for at åbne forbindelsen
                        CloseDB();
                        OpenDB(); // Recursivt kald af metoden
                    }
                    else
                    {

                        this.con = new SqlConnection(_connectionString);
                        OpenDB(); // Recursivt kald af metoden
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Denne metode lukker forbindelsen til databasen
        /// </summary>
        protected void CloseDB()
        {
            try
            {
                this.con.Close(); // Luk forbindelsen til databasen
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    
        /// <summary>
        /// Denne metode kører SQL udtryk i databasen og giver svar tilbage om det var succesfuldt  
        /// </summary>
        /// <param name="sqlQuery">string</param>
        /// <returns>int</returns>
        protected int ExecuteNonQuery(string sqlQuery)
        {
            int res = 0;

            try
            {
                OpenDB(); // Åben forbindelsen til databasen
                using (_command = new SqlCommand(sqlQuery, this.con)) // Initialiser '_command' med en SqlCommand i et using scope
                {                                                     // så garbage collectoren kan ryde op efter den
                    res = _command.ExecuteNonQuery(); // Kør SQL kommandoen 
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB(); // Helt til sidst lukkes forbindelsen
            }

            return res;
        }
    
        /// <summary>
        /// En metode der kan vælge data fra databasen og returnere en DataTable der indeholder den data
        /// </summary>
        /// <param name="sqlQuery">string</param>
        /// <returns>DataTable</returns>
        protected DataTable DBReturnDataTable(string sqlQuery)
        {
            DataTable dtRes = new DataTable();

            try
            {
                OpenDB(); // Åben forbindelsen til databasen

                using (_command = new SqlCommand(sqlQuery, this.con)) // Initialisere '_command' med en ny SqlCommand inde i et using scope
                {                                                     // så garbage collectoren nemt kan ryde op efter den
                    using (SqlDataAdapter adapter = new SqlDataAdapter(_command)) // Laver en ny SqlDataAdapter i et using scope,
                    {                                                             // den bliver brugt til at hente data fra databasen og adaptere det til data vi kan bruge,
                        adapter.Fill(dtRes);                                      // derefter fylder den dataen ind i et Datatable som returneres
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB(); // Til sidst lukkes forbindelsen til databasen
            }

            return dtRes;
        }

        /// <summary>
        /// En metode der kan spørge databasen om data og få dataen tilbage som en stor string
        /// </summary>
        /// <param name="sqlQuery">string</param>
        /// <returns>string</returns>
        protected string DbReturnString(string sqlQuery)
        {
            string res = "";
            bool foundData = false;

            try
            {
                OpenDB(); // Åben forbindelse til databasen

                using (SqlCommand cmd = new SqlCommand(sqlQuery, this.con)) // Lav en SqlCommand med vores 'sqlQuery'
                {                                                           // inden i et using scope for at hjælpe garbage collectoren

                    using (SqlDataReader reader = cmd.ExecuteReader()) // Kør 'cmd.ExecuteReader()'
                                                                       // Denne metode får en SqlDataReader til at læse dataen i databasen
                                                                       // og returnere den SqlDataReader der er igang med at læse
                    {
                        while (reader.Read()) // Imens vores SqlDataReader er i gang med at læse,
                                              // sæt 'res' til det den indtil videre har læst og sæt vores bool 'foundData' til true
                        {
                            res = reader.GetString(0);
                            foundData = true;
                        }
                        if (!foundData)
                        {
                            res = "Intet data blev fundet."; // Hvis der ikke blev fundet noget data så sæt 'res' til en default verdi
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB(); // Til sidst lukkes forbindelsen til databasen
            }

            return res;
        }
    
        /// <summary>
        /// Denne metode skal håndtere forespørgelser til databasen som skal returnere et resultatsæt.
        /// Forespørgelsen skal foretages gennem en StoredProcedure på SqlServeren
        /// Det resultatsæt der modages fra databasen, konverteres over i en collection af typen DataTable
        /// </summary>
        /// <param name="inCommand">SqlCommand</param>
        /// <returns>DataTable</returns>
        protected DataTable MakeCallToStoredProcedure(SqlCommand inCommand)
        {
            DataTable dtRes = new DataTable();

            try
            {
                OpenDB(); // Forbindelsen til databasen åbnes

                using (SqlDataAdapter adapter = new SqlDataAdapter(inCommand)) // En instans af SqlDataAdapter bliver initialiseret med 'inCommand'
                {
                    adapter.Fill(dtRes); // Den adapteret data bliver fyldt i 'dtRes'
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                CloseDB(); // Forbindelsen lukkes
            }

            return dtRes;
        }
    }
}
