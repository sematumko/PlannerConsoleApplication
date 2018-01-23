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
            _queryBody = _queryBody.Trim(' ', '\t');

            if (_queryBody.Length > 0)
            {
                taskContext.Tasks.Add(new Task { Content = _queryBody });
                taskContext.SaveChanges();
            }
        }

        public void updateTask(Task _task, string _newValue)
        {
            _newValue = _newValue.Trim(' ', '\t');

            if (_newValue.Length > 0)
            {
                _task.Content = _newValue;
                taskContext.SaveChanges();
            }
        }

        public void removeTask(string _queryBody)
        {
            _queryBody = _queryBody.Trim(' ', '\t');

            int tmpId = -1;

            if (Int32.TryParse(_queryBody, out tmpId))
                if (tmpId > 0 && taskContext.Tasks.Find(tmpId) != null)
                {
                    taskContext.Tasks.Remove(taskContext.Tasks.Find(tmpId));
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
            _queryBody = _queryBody.Trim(' ', '\t');

            int tmpId = -1;

            if (Int32.TryParse(_queryBody, out tmpId))
                if (tmpId > 0)
                    return taskContext.Tasks.Find(tmpId);

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
