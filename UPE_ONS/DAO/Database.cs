using System.Data.SqlClient;
using System;
using System.Data;
using System.IO;
using UPE_ONS.Util;

namespace ScriptDB.DAO
{
    public static class Database
    {
        //private static String connectionString = "server=localhost;database=upe_ons;uid=root;password=;";
        
        public static IDbConnection openConnection()
        {
            SqlConnection connection = null;
            try
            {
                StreamReader connectionFile = new StreamReader("config.txt");
                String connectionString = connectionFile.ReadLine();
                connectionFile.Close();

                connection = new SqlConnection(connectionString);

                connection.Open();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.ERROR_OPEN_CONNECTION);
            }

            return connection;
        }
    }
}
