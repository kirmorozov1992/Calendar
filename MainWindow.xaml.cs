using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Calendar
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //вывод значения текущей даты
            Label_curr_date.Content = Calendar.GetCurrDate();
            //вывод значения текущего дня недели
            Label_day_of_week.Content = Calendar.GetCurrDayOfWeek();
            //вывод значения текущего времени
            Label_curr_time.Content = Calendar.GetCurrTime();
            //проверка наличия праздника на текущую дату
            Calendar.CheckHoliday();
            //вывод значения текущего праздника
            Label_curr_holiday.Content = Calendar.holidayToday;
            //проверка наличия напоминания на текущую дату
            Calendar.CheckReminder();
            //вывод значения текущего напоминания
            Label_curr_reminder.Content = Calendar.reminderToday;
        }


        //метод добавления нового праздника
        //сначала создается объект
        //новый объект сохраняется в файл holidaysFile в строковом формате
        //очищается поле ввода названия праздника
        //вывод оповещения о добавлении
        //проверка и вывод праздника
        private void Button_add_holiday_Click(object sender, RoutedEventArgs e)
        {
            Holiday new_holiday = new Holiday(DatePicker_add_holiday.ToString().Substring(0, DatePicker_add_holiday.ToString().Length - 12), TextBox_holiday_name.Text);
            using (StreamWriter sw = File.AppendText(Calendar.holidaysFile))
            {
                sw.WriteLine(new_holiday.ToString());
            }
            TextBox_holiday_name.Clear();
            MessageBox.Show("Added");
            Calendar.CheckHoliday();
            Label_curr_holiday.Content = Calendar.holidayToday;
        }
        //метод вывода всего списка праздников в окно-оповещение
        //сначала считывается файл holidaysFile в массив
        //сохранение данных в переменную allHolidays и вывод на экран
        private void Button_show_all_holidays_Click(object sender, RoutedEventArgs e)
        {
            string[] holidays = File.ReadAllLines(Calendar.holidaysFile);
            string allHolidays = "";
            foreach (string h in holidays)
            {
                allHolidays += h + "\n";
            }
            MessageBox.Show(allHolidays);
        }
        //метод добавления нового напоминания
        //сначала создается объект
        //новый объект сохраняется в файл remindersFile в строковом формате
        //очищается поле ввода названия напоминания
        //вывод оповещения о добавлении
        //проверка и вывод напоминания
        private void Button_add_reminder_Click(object sender, RoutedEventArgs e)
        {
            Reminder new_reminder = new Reminder(DatePicker_add_reminder.ToString().Substring(0, DatePicker_add_reminder.ToString().Length - 8), TextBox_reminder_time.Text, DatePickerTextBox_reminder_text.Text);
            using (StreamWriter sw = File.AppendText(Calendar.remindersFile))
            {
                sw.WriteLine(new_reminder.ToString());
            }
            TextBox_reminder_time.Clear();
            DatePickerTextBox_reminder_text.Clear();
            MessageBox.Show("Added");
            Calendar.CheckReminder();
            Label_curr_reminder.Content = Calendar.reminderToday;
        }
        //метод вывода всего списка напоминаний в окно-оповещение
        //сначала считывается файл remindersFile в массив
        //сохранение данных в переменную allReminders и вывод на экран
        private void Button_show_all_reminders_Click(object sender, RoutedEventArgs e)
        {
            string[] reminders = File.ReadAllLines(Calendar.remindersFile);
            string allReminders = "";
            foreach (string r in reminders)
            {
                allReminders += r + "\n";
            }
            MessageBox.Show(allReminders);
        }
        //методы корректировки списка праздников и списка напоминаний
        //методы максимально упрощены и требуют усовершенствования
        //текстовый файл открывается в блокноте, можно произвести удаление данных или корректировку
        //в идеале нужны списки с выводом каждого значения
        //по клику по определенному значению открывалось бы окно с функциями удаления или корректировки
        private void Button_edit_holidays_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"notepad.exe", Calendar.holidaysFile);
        }

        private void Button_edit_reminders_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"notepad.exe", Calendar.remindersFile);
        }

        //также требуется доработка вывода данных в реальном времени (чтобы время менялось)
        //плюс обновление вывода праздника и напоминания
        //чтобы, например, при удалении праздника на текущую дату, данные выводились без перезапуска программы
        //но асинхронный метод записи не позволяет добавить методы - возникают баги
        //это нужно изучить
        //также требуют доработки напоминания, чтобы они появлялись во время работы программы на заданное время
        //TO DO
    }
}
