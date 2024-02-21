using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DylanDeSouzaTaskManager
{
    internal class Folder
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        private int _numberOfIncompleteTasks;
        public List<Guid> Tasks { get; set; }

        public static List<Guid> FoldersInDatabase = new List<Guid>();

        public Folder(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Tasks = new List<Guid>();
        }

        public int NumberOfIncompleteTasks
        {
            get
            {
                _numberOfIncompleteTasks = 0;
                foreach (Guid taskId in Tasks)
                {
                    var task = Task.TasksInDatabase.FirstOrDefault(t => t.Id == taskId);
                    if (task != null)
                    {
                        if (!task.Completed)
                        {
                            _numberOfIncompleteTasks += 1;
                        }
                    }
                }
                return _numberOfIncompleteTasks;
            }
        }

        public void AddTaskToFolder(Guid taskId)
        {
            Tasks.Add(taskId);
        }

        public void RemoveTaskFromFolder(Guid taskId)
        {
            Tasks.Remove(taskId);
        }

        public static void AddFolderToDatabase(Folder folder)
        {
            FoldersInDatabase.Add(folder.Id);
        }

        public static void RemoveFolderFromDatabase(Guid folderId)
        {
            FoldersInDatabase.Remove(folderId);
        }
    }
}
