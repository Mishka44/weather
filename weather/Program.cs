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
        static void New_inf(int prec, int temp, Action<string> action)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            string query =
                $"INSERT INTO WEATHER_COND(" +
            $"PRECIPITATION,  TEMPRETURE, DATE) " +
            $"VALUES(" +
            $"{prec}, {temp}, date('{dateTime.ToString("yyyy-MM-dd")}') );";

            DB_manipu_ations.AddData(query);
            action("Вся сводка по осадкам");
        }
        delegate void out_put(string text);


        static void SimplePrint(string text)
        {
            Console.WriteLine(text);

        }
        static void QuottedPrint(string text)
        {
            Console.WriteLine(text);
            string text_2 = "";
            text_2 = DB_manipu_ations.GetAllData(";");

            Console.WriteLine("Вся сводка по осадкам");
            var arr = text_2.Split(';');

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            int precipitation, temprature;
            string flag;
            try
            {
                int.TryParse(args[0], out precipitation);
                int.TryParse(args[1], out temprature);
                flag = args[2];
            }
            catch
            {
                Console.WriteLine("осадки: ");
                int.TryParse(Console.ReadLine(), out precipitation);
                Console.WriteLine("температура: ");
                int.TryParse(Console.ReadLine(), out temprature);
                Console.WriteLine("флаг на вывод: true/false?");
                flag = Console.ReadLine();
            }
            DB_manipu_ations.Prepare();

            if (flag == "true")
            {
                Action<string> _action = QuottedPrint;
                New_inf(precipitation, temprature, _action);
            }
            else
            {
                if (flag == "false") {
                    Action<string> _action = SimplePrint;
                    New_inf(precipitation, temprature, _action);
                }
            }

            /*DateTime dateTime = DateTime.UtcNow.Date;
            string query =
                $"INSERT INTO WEATHER_COND(" +
            $"PRECIPITATION,  TEMPRETURE, DATE) " +
            $"VALUES(" +
            $"{precipitation}, {temprature}, date('{dateTime.ToString("yyyy-MM-dd")}') );";

            string output = "";*/

            /*Console.WriteLine($"Информация в базу данных: осадки: {precipitation}, температура:{temprature}, дата:{dateTime.ToString("yyyy-MM-dd")} ");*/
       

            /*DB_manipu_ations.AddData(query);*/

            /*output = DB_manipu_ations.GetAllData(";");


            Console.WriteLine("Вся сводка по осадкам");

            var arr = output.Split(';');

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }*/



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
