using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_Manager
{
    internal class FileTaskRepository : ITaskRepository
    {
        private string filePath = "tasks.txt";

        private List<TaskItem> tasks = new List<TaskItem>();

        public FileTaskRepository()
        {
            Load();
        }

        public IReadOnlyList<TaskItem> GetAll()
        {
            return tasks;
        }

        public void Add (TaskItem task)
        {
            tasks.Add(task);
            Save();
        }

        // update
        public bool Update(TaskItem task)
        {
            var taskToUpdate = tasks.Find(t => t.Id == task.Id);
            

            if (taskToUpdate != null)
            {
                taskToUpdate.UpdateFrom(task);
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool Delete(int id)
        {
            if(id <= 0) { return false; }

            var removedCount = tasks.RemoveAll(t => t.Id == id);
            if (removedCount == 0) { return false; }

            Save();
            return true;
        }

        public bool SaveMarkAsComplete()
        {
            Save();
            return true;
        }

        //save tasks to file
        private void Save()
        {
            var taskItem = tasks.Select(task =>
            {
                if (task is WorkTask workTask)
                {
                    return $"{workTask.Id}|Work|{workTask.Title}|{workTask.Company}|{workTask.IsCompleted}";
                }

                if (task is PersonalTask personalTask)
                {
                    return $"{personalTask.Id}|Personal|{personalTask.Title}|{personalTask.Person}|{personalTask.IsCompleted}";
                }

                return "";

            }).ToList();

            File.WriteAllLines(filePath, taskItem);
        }


        // load task
        private void Load()
        {
            if (File.Exists(filePath))
            {
                string[] loadedTasks = File.ReadAllLines(filePath);

                if (loadedTasks.Length > 0)
                {
                    foreach (string loadedTask in loadedTasks)
                    {
                        string[] task = loadedTask.Split('|');

                        int.TryParse(task[0], out int id);
                        string type = task[1];
                        string title = task[2];
                        bool status = Convert.ToBoolean(task[4]);

                        TaskItem taskItem;

                        if (type == "Work")
                        {
                            string company = task[3];
                            taskItem = new WorkTask(title, company, status);
                        }
                        else if (type == "Personal")
                        {
                            string person = task[3];
                            taskItem = new PersonalTask(title, person, status);
                        }
                        else
                        {
                            continue;
                        }

                        taskItem.SetId(id);

                        tasks.Add(taskItem);
                    }
                }

            }
        }

    }
}
