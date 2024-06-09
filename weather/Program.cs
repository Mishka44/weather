using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Security.Claims;
using System.Xml.Linq;

namespace weather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int precipitation, temprature;
            try
            {
                int.TryParse(args[0], out precipitation);
                int.TryParse(args[1], out temprature);

            }
            catch
            {
                Console.WriteLine("осадки: ");
                int.TryParse(Console.ReadLine(), out precipitation);
                Console.WriteLine("температура: ");
                int.TryParse(Console.ReadLine(), out temprature);
            }
            DateTime dateTime = DateTime.UtcNow.Date;
            string query =
                $"INSERT INTO WEATHER_COND(" +
            $"PRECIPITATION,  TEMPRETURE, DATE) " +
            $"VALUES(" +
            $"{precipitation}, {temprature}, date('{dateTime.ToString("yyyy-MM-dd")}') );";

            string output = "";

            Console.WriteLine($"Информация в базу данных: осадки: {precipitation}, температура:{temprature}, дата:{dateTime.ToString("yyyy-MM-dd")} ");
       
            DB_manipu_ations.Prepare();
            DB_manipu_ations.AddData(query);

            output = DB_manipu_ations.GetAllData(";");


            Console.WriteLine("Вся сводка по осадкам");

            var arr = output.Split(';');

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }



            /*DateTime date1 = new DateTime(); // год - месяц - день
            Console.WriteLine(date1);*/

            /*DateTime dateTime = DateTime.UtcNow.Date;
            Console.WriteLine(dateTime.ToString("yyyy-MM-dd"));
            Console.WriteLine(DateTime.Now);*/
            /*  var alarm = DateTime.Now.Ticks;
              Console.WriteLine(alarm.ToString())*/

        }
    }
}
