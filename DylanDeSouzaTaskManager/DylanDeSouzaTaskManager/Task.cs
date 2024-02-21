using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Collections;
using Windows.Services.Store;

namespace DylanDeSouzaTaskManager
{
    internal class Task
    {
        public Guid Id { get; private set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public bool Completed { get; set; }
        private readonly DateTime? _completionDateTime;
        public static List<Task> TasksInDatabase = new List<Task>();

        public bool CheckOverdue
        {
            get
            {
                return _completionDateTime.HasValue && !Completed && _completionDateTime.Value.Date < DateTime.Now.Date;
            }
        }

        public DateTime? GetCompletionDateTime
        {
            get { return _completionDateTime; }
        }

        public Task(string description, string notes, DateTime? completionDateTime = null)
        {
            Id = Guid.NewGuid();
            Description = description;
            Notes = notes;
            this._completionDateTime = completionDateTime;
        }

        public static void AddTaskToDatabase(Task task)
        {
            TasksInDatabase.Add(task);
        }

        public static void RemoveTaskFromDatabase(Guid taskId)
        {
            var task = TasksInDatabase.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                TasksInDatabase.Remove(task);
            }
        }
    }
}
