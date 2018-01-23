using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseWorker dbWorker = new DataBaseWorker();
            string query = "";

            while (true)
            {
                Console.Clear();
                dbWorker.showTasks();

                Console.WriteLine("\nДля отображения списка команд введите help\n");
                Console.Write("PlannerApp>");
                query = Console.ReadLine();

                if (query.ToLower().StartsWith("add "))
                {
                    dbWorker.addTask(cutCommand(query));
                }
                else if (query.ToLower().StartsWith("upd "))
                {
                    var tmpTask = dbWorker.findTask(cutCommand(query));

                    if (tmpTask != null)
                    {
                        Console.WriteLine("\nСТАРОЕ ЗНАЧЕНИЕ : {0}", tmpTask.Content);
                        Console.Write("НОВОЕ ЗНАЧЕНИЕ  : ");
                        string newValue = Console.ReadLine();

                        dbWorker.updateTask(tmpTask, newValue);
                     }
                }
                else if (query.ToLower().StartsWith("del "))
                {
                    dbWorker.removeTask(cutCommand(query));
                }
                else if (query.Equals("clear", StringComparison.InvariantCultureIgnoreCase))
                {
                    dbWorker.removeAllTasks();
                }
                else if (query.Equals("help", StringComparison.InvariantCultureIgnoreCase))
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
                else if (query.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("\nBye");
                    System.Threading.Thread.Sleep(300);
                    dbWorker.close();
                    Environment.Exit(0);
                 }
                 else
                 {
                    Console.WriteLine("\nНеизвестная команда или формат. Для получения списка команд введите help");
                    Console.ReadKey();
                 }
            }
        }

        // отсекает команду
        public static string cutCommand(string _query) => _query.Remove(0, _query.IndexOf(" ") + 1);
    }
}