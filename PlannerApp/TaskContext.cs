using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PlannerApp
{
    class TaskContext : DbContext
    {
        public TaskContext()
            : base("DbConnection")
        { }

        public DbSet<Task> Tasks { get; set; }

        public void addTask(string _queryBody)
        {
            _queryBody = _queryBody.Trim(' ', '\t');

            if (_queryBody.Length > 0)
            {
                Tasks.Add(new Task { Content = _queryBody });
                this.SaveChanges();
            }
        }

        public void updateTask(Task _task, string _newValue)
        {
            _newValue = _newValue.Trim(' ', '\t');

            if (_newValue.Length > 0)
            {
                _task.Content = _newValue;
                this.SaveChanges();
            }
        }

        public void removeTask(string _queryBody)
        {
            _queryBody = _queryBody.Trim(' ', '\t');

            int tmpId = -1;

            if (Int32.TryParse(_queryBody, out tmpId))
                if (tmpId > 0 && Tasks.Find(tmpId) != null)
                {
                    Tasks.Remove(Tasks.Find(tmpId));
                    this.SaveChanges();
                }
        }

        public void removeAllTasks()
        {
            this.Tasks.RemoveRange(this.Tasks);
            this.SaveChanges();
        }

        public Task findWithValidation(string _queryBody)
        {
            _queryBody = _queryBody.Trim(' ', '\t');

            int tmpId = -1;

            if (Int32.TryParse(_queryBody, out tmpId))
                if (tmpId > 0)
                    return Tasks.Find(tmpId);

            return null;
        }

        public void showTasks()
        {
            foreach (Task tsk in this.Tasks)
            {
                Console.WriteLine("{0}. {1}", tsk.Id, tsk.Content);
            }
        }
    }
}