using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather
{
    internal class DB_manipu_ations
    {
        private static string conn_string = "Data Source = \"weather.db\";";

        private static string init_query =
            $"CREATE TABLE IF NOT EXISTS WEATHER_COND (" +
            $"ID     INTEGER PRIMARY KEY AUTOINCREMENT," +
            $"PRECIPITATION INTEGER," +
            $"TEMPRETURE INTEGER," +
            $" DATA TEXT);";


        private static string init_data =
            $"INSERT INTO WEATHER_COND (" +
            $"PRECIPITATION, TEMPRETURE, DATE) " +
            $"VALUES(" +
            $" 50, 25, date('2021-11-29') );";

        private static string select_all_data = "SELECT * FROM WEATHER_COND;";

        public static void Prepare()
        {
            SQLiteConnection connection = new SQLiteConnection(conn_string);
            connection.Open();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = init_query;
            command.ExecuteNonQuery();
            connection.Close();
        }


        public static void InitData()
        {
            AddData(init_data);
        }



        public static void AddData(string query)
        {
            SQLiteConnection connection = new SQLiteConnection(conn_string);
            connection.Open();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connection.Close();
        }



        public static string GetAllData(string separator = "\t|\t")
        {
            return GetData(select_all_data, separator);
        }



        public static string GetData(string query, string separator = "\t|\t")
        {
            string result = "";
            SQLiteConnection connection = new SQLiteConnection(conn_string);
            connection.Open();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = query;
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (i == reader.FieldCount - 1)
                    {
                        result += reader.GetValue(i);
                    }
                    else
                    {
                        result += reader.GetValue(i) + separator;
                    }
                }
                result += "\n";
            }
            connection.Close();
            return result;
        }
    }
}
