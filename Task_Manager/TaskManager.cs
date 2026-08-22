using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    internal class TaskManager
    {
        private string filePath = "tasks.txt";

        private List<TaskItem> tasks = new List<TaskItem>();

        private Logger logger = new Logger();

        public IReadOnlyList<TaskItem> Tasks
        {
            get { return tasks; }
        }

        private int nextId = 0;

        // Add a Task
        public void AddTask(TaskItem task)
        {
            nextId++;
            task.SetId(nextId);
            tasks.Add(task);
            SaveTasks();
            logger.Log($"Task Added: {task.Title}");
        }

        // Update a Task
        public bool UpdateTask(int id, string title)
        {
            if (id > 0) {

                var taskToUpdate = tasks.Find(t => t.Id == id);
                if (taskToUpdate != null)
                {
                    taskToUpdate.Title = title;
                    SaveTasks();
                    logger.Log($"Task Updated: {taskToUpdate.Title}");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            
        }

        // Delete a Task
        public bool DeleteTask(int id)
        {
            if (id <= 0) { return false; }

            var removedCount = tasks.RemoveAll(t => t.Id == id);

            if (removedCount == 0) { return false; }

            SaveTasks();
            logger.Log($"Task Deleted: {id}");
            return true;
        }


        // Search Tasks
        public IReadOnlyList<TaskItem> SearchTasks(string search)
        {
            return tasks
                .Where(task => task.Title.ToLower().Contains(search.ToLower()))
                .ToList();
        }

        
        //save tasks to file
        public void SaveTasks()
        {
            var taskItem = tasks.Select(task =>
            {
                if (task is WorkTask workTask)
                {
                    return $"{workTask.Id}|Work|{workTask.Title}|{workTask.Company}";
                }

                if (task is PersonalTask personalTask)
                {
                    return $"{personalTask.Id}|Personal|{personalTask.Title}|{personalTask.Person}";
                }

                return "";

            }).ToList();

            File.WriteAllLines(filePath, taskItem);
        }

        // load task
        public void LoadTasks()
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

                        TaskItem taskItem;

                        if(type == "Work")
                        {
                            string company = task[3];
                            taskItem = new WorkTask(title, company);
                        }
                        else if(type == "Personal")
                        {
                            string person = task[3];
                            taskItem = new PersonalTask(title, person);
                        }
                        else
                        {
                             continue; 
                        }

                        taskItem.SetId(id);

                        tasks.Add(taskItem);
                    }
                    if(tasks.Count > 0)
                    {
                        nextId = tasks.Max(t => t.Id);
                    }
                }

            }
        }

    }
}
