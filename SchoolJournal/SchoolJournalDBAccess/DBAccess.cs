using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolJournalDBAccess
{
    public static class DBAccess
    {
        public static string ConexiuneCurenta = "SCHOOLJOURNALconn";

        public static SqlConnection OpenConnection(string connName)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[connName].ConnectionString);
            //connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            connection.Open();
            return connection;
        }

        public static void CloseConnection(SqlConnection connection)
        {
            connection.Close();
        }

        public static void ExecuteReader(SqlConnection connection, string commandText)
        {
            SqlCommand command = new SqlCommand(commandText);
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"\t {reader[i]}");
                }
                Console.WriteLine();
            }
            reader.Close();
        }

        public static SqlDataReader GetObjectFromReader(SqlConnection connection, string commandText)
        {
            SqlCommand command = new SqlCommand(commandText);
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public static void CloseReader(SqlDataReader reader)
        {
            reader.Close();
        }

        public static SqlParameter newParam(string paramName, object paramValue)
        {
            SqlParameter parameter = new SqlParameter { Value = paramValue, ParameterName = paramName };
            return parameter;
        }
    }
}
