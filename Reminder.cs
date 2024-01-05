using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{   //класс напоминание
    internal class Reminder
    {   //поля класса - дата, время и текст напоминания
        private string date;
        private string time;
        private string text;
        //конструктор класса
        public Reminder(string date, string time, string text)
        {
            this.date = date;
            this.time = time;
            this.text = text;
        }
        //метод для получения и установки поля дата
        public string Date
        {
            get => date;
            set
            {   //проверка устанавливаемой даты напоминания (дата не может быть ранее текущей)
                if (Convert.ToDateTime(Date) < DateTime.Now)
                {
                    throw new ArgumentException("Reminder time can`t be less then current time!");
                }
                else
                {
                    date = value;
                }
            }
        }
        //метод для получения и установки поля время
        public string Time
        {
            get => time;
            set => time = value;
        }
        //метод для получения и установки поля текст
        public string Text
        {
            get => text;
            set => text = value;
        }
        //переопределение метода ToString() для вывода объекта в текстовом формате
        public override string ToString()
        {
            return Date + " " + Time + " " + Text;
        }
    }
}
