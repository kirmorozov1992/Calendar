using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Calendar
{   //статический класс календарь
    internal static class Calendar
    {   //поле по умолчанию праздник на текущую дату
        public static string holidayToday = " ";
        //поле по умолчанию напоминание на текущую дату
        public static string reminderToday = " ";
        //поле с указанием пути к файлу holidays.txt
        public static string holidaysFile = "holidays.txt";
        //поле с указанием пути к файлу reminders.txt
        public static string remindersFile = "reminders.txt";
        //поле, содержащее текущую дату в строковом формате
        private static string CurrDate = DateTime.Now.ToShortDateString();
        //поле, содержащее текущий день недели в строковом формате
        private static string CurrDayOfWeek = DateTime.Today.DayOfWeek.ToString();
        //поле, содержащее текущее время в строковом формате
        private static string CurrTime = DateTime.Now.ToString("HH:mm:ss");
        //метод для получения значения поля CurrDate
        public static string GetCurrDate() { return CurrDate; }
        //метод для получения значения поля CurrDayOfWeek
        public static string GetCurrDayOfWeek() { return CurrDayOfWeek; }
        //метод для получения значения поля CurrTime
        public static string GetCurrTime() { return CurrTime; }
        //метод считывает файл holidaysFile, содержащий все праздники
        //проверяет соответствие текущей даты и даты праздника
        //если дата соответствует, присваивает значение в поле holidayToday
        //если дата не соответствует, присваивает значение по умолчанию
        public static void CheckHoliday()
        {
            string[] hol_array = File.ReadAllLines(holidaysFile);
            foreach (string h in hol_array)
            {
                if (h.Substring(0, 6) == CurrDate.Substring(0, 6) & h.Substring(0, 6).Length == 6)
                {
                    holidayToday += "Holiday - " + h + "\n ";
                }
                else
                {
                    holidayToday = " ";
                }
            }
        }
        //метод считывает файл remindersFile, содержащий все напоминания
        //проверяет соответствие текущей даты и даты напоминания
        //если дата соответствует, присваивает значение в поле reminderToday
        //если дата не соответствует, присваивает значение по умолчанию
        public static void CheckReminder()
        {
            string[] rem_array = File.ReadAllLines(remindersFile);
            foreach (string r in rem_array)
            {
                if (r.Substring(0, 10) == CurrDate & r.Substring(0, 10).Length == 10)
                {
                    reminderToday += r + "\n ";
                }
                else
                {
                    reminderToday = " ";
                }
            }
        }
    }
}
