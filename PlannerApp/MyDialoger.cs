using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp
{
    static class MyDialoger
    {
        public static string inputtingDialog()
        {
            Console.WriteLine("\nДля отображения списка команд введите help\n");
            Console.Write("PlannerApp>");
            return Console.ReadLine();
        }

        public static string updatingDialog(string _oldValue)
        {
            Console.WriteLine("\nСТАРОЕ ЗНАЧЕНИЕ : {0}", _oldValue);
            Console.Write("НОВОЕ ЗНАЧЕНИЕ  : ");
            return Console.ReadLine();
        }

        public static void helpMessage()
        {
            Console.WriteLine("\nadd [задача]          Добавить задачу");
            Console.WriteLine("upd [id задачи]       Редактировать задачу");
            Console.WriteLine("del [id задачи]       Удалить задачу");
            Console.WriteLine("clear                 Удалить все задачи");
            Console.WriteLine("help                  Список команд");
            Console.WriteLine("exit                  Выход");

            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }

        public static void errorMessage()
        {
            Console.WriteLine("\nНеизвестная команда или формат. Для получения списка команд введите help");
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }

        public static void exitMessage() =>Console.WriteLine("\nBye");

        public static void clear() => Console.Clear();
    }
}
