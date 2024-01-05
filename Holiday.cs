using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{   //класс праздник
    internal class Holiday
    {   
        //поля класса дата праздника и название
        private string date;
        private string name;
        //конструктор класса
        public Holiday(string date, string name)
        {
            this.date = date;
            this.name = name;
        }
        //метод получения и установки значения поля дата
        public string Date
        {
            get => date;
            set => date = value;
        }
        //метод получения и установки значения поля название
        public string Name
        {
            get => name;
            set => name = value;
        }
        //переопределение метода ToString() для вывода объекта в текстовом формате
        public override string ToString()
        {
            return Date + " " + Name;
        }
    }
}
