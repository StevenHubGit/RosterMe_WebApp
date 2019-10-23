using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RosterMe.Data.SQLQueries
{
    public class SelectQueries
    {
        //Class variables
        private static String LOG_TAG = "Select Queries class message";
        private static SqlCommand command;

        /* ---------- Table: Login Credentials ---------- */
        /* ---- Select table: Login Credentials ---- */
        public static Dictionary<String, String> selectDictionaryOfLoginCredentialsTable(SqlConnection connection)
        {
            //Create Dictionary to return
            Dictionary<String, String> loginCredentials_Dictionary = new Dictionary<String, String>();

            //Create query
            String query = "Select * From [LoginCredentials]";

            //Initialize command
            command = new SqlCommand(query, connection);

            //Set command connection
            command.Connection = connection;

            //Check if command connection is open
            if (command.Connection.State == ConnectionState.Closed)
            {
                //Open command connection
                command.Connection.Open();
            }

            //Check if command connection is open
            if (command.Connection.State == ConnectionState.Open)
            {
                try
                {
                    //Execute command & store in SQL Data Reader
                    SqlDataReader reader = command.ExecuteReader();

                    //Create counter
                    int counterData = 0;

                    //Loop through result
                    while (reader.Read())
                    {
                        //Add List to Dictionary
                        loginCredentials_Dictionary.Add
                        (
                            reader["Username"].ToString(),
                            reader["Password"].ToString()
                        );
                    }
                }
                catch (Exception e)
                {
                    //Print message
                    Console.WriteLine(LOG_TAG + ": Error !" +
                        "\nAn error occurred while trying to retrieve login credentials table" +
                        "\n- Message: " + e.Message +
                        "\n- Stacktrace: " + e.StackTrace
                    );
                }
                finally
                {
                    //Check if command connection is open
                    if (command.Connection.State == ConnectionState.Open)
                    {
                        //Close connection
                        command.Connection.Close();
                    }
                }
            }

            //Loop through login credentials Dictionary
            foreach (var loginCredentials in loginCredentials_Dictionary)
            {
                //Prin content
                Console.WriteLine(LOG_TAG + ": Login Credentials Dictionary content" +
                    "\n- Key: " + loginCredentials.Key +
                    "\n- Value: " + loginCredentials.Value
                );
            }

            //Return List
            return loginCredentials_Dictionary;
        }
    }
}
