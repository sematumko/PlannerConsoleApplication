using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp
{
    class DataBaseWorker
    {
        private TaskContext taskContext;

        public DataBaseWorker() => taskContext = new TaskContext();


        public void addTask(string _queryBody)
        {
            if (Validator.addOrUpdateValidation(ref _queryBody))
            {
                taskContext.Tasks.Add(new Task { Content = _queryBody });
                taskContext.SaveChanges();
            }
        }

        public void updateTask(Task _task, string _newValue)
        {
            if (Validator.addOrUpdateValidation(ref _newValue))
            {
                _task.Content = _newValue;
                taskContext.SaveChanges();
            }
        }

        public void removeTask(string _queryBody)
        { 
            if (Validator.removeOrFindValidation(_queryBody, out int _tmpId) && taskContext.Tasks.Find(_tmpId) != null)
            {
                taskContext.Tasks.Remove(taskContext.Tasks.Find(_tmpId));
                taskContext.SaveChanges();
            }
        }

        public void removeAllTasks()
        {
            taskContext.Tasks.RemoveRange(taskContext.Tasks);
            taskContext.SaveChanges();
        }

        public Task findTask(string _queryBody)
        {
            if (Validator.removeOrFindValidation(_queryBody, out int _tmpId))
                    return taskContext.Tasks.Find(_tmpId);

            return null;
        }

        public void showTasks()
        {
            foreach (Task tsk in taskContext.Tasks)
                Console.WriteLine("{0}. {1}", tsk.Id, tsk.Content);
        }

        public void close() => taskContext.Dispose();
    }
}
