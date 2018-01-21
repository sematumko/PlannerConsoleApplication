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
            using (TaskContext db = new TaskContext())
            {
                string query = "";

                while (true)
                {
                    Console.Clear();

                    db.showTasks();

                    Console.WriteLine("\nДля отображения списка команд введите help\n");
                    Console.Write("PlannerApp>");
                    query = Console.ReadLine();


                    if (query.ToLower().StartsWith("add "))
                    {
                        db.addTask(cutCommand(query));
                    }
                    else if (query.ToLower().StartsWith("upd "))
                    {
                        var tmpTask = db.findWithValidation(cutCommand(query));

                        if (tmpTask != null)
                        {
                            Console.WriteLine("\nСТАРОЕ ЗНАЧЕНИЕ : {0}", tmpTask.Content);
                            Console.Write("НОВОЕ ЗНАЧЕНИЕ  : ");
                            string newValue = Console.ReadLine();

                            db.updateTask(tmpTask, newValue);
                        }
                    }
                    else if (query.ToLower().StartsWith("del "))
                    {
                        db.removeTask(cutCommand(query));
                    }
                    else if (query.Equals("clear", StringComparison.InvariantCultureIgnoreCase))
                    {
                        db.removeAllTasks();
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
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("\nНеизвестная команда или формат. Для получения списка команд введите help");
                        Console.ReadKey();
                    }
                }
            }
        }

        // отсекает команду
        public static string cutCommand(string _query) => _query.Remove(0, _query.IndexOf(" ") + 1);
    }
}