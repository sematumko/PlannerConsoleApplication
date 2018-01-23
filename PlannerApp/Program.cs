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
                MyDialoger.clear();
                dbWorker.showTasks();
                query = MyDialoger.inputtingDialog();


                if (query.ToLower().StartsWith("add "))
                    dbWorker.addTask(cutCommand(query));

                else if (query.ToLower().StartsWith("upd "))
                {
                    var tmpTask = dbWorker.findTask(cutCommand(query));

                    if (tmpTask != null)
                    {
                        string newValue = MyDialoger.updatingDialog(tmpTask.Content);
                        dbWorker.updateTask(tmpTask, newValue);
                     }
                }

                else if (query.ToLower().StartsWith("del "))
                    dbWorker.removeTask(cutCommand(query));

                else if (query.Equals("clear", StringComparison.InvariantCultureIgnoreCase))
                    dbWorker.removeAllTasks();

                else if (query.Equals("help", StringComparison.InvariantCultureIgnoreCase))
                    MyDialoger.helpMessage();

                else if (query.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    MyDialoger.exitMessage();
                    System.Threading.Thread.Sleep(300);
                    dbWorker.close();
                    Environment.Exit(0);
                 }

                 else
                    MyDialoger.errorMessage();
            }
        }

        // отсекает команду
        public static string cutCommand(string _query) => _query.Remove(0, _query.IndexOf(" ") + 1);
    }
}