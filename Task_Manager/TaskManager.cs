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
        private int nextId = 0;
        
        //private List<TaskItem> tasks = new List<TaskItem>();
        ITaskRepository repository;

        private Logger logger = new Logger();

        public IReadOnlyList<TaskItem> Tasks
        {
            get { return repository.GetAll(); }
        }

        public TaskManager(ITaskRepository repository)
        {
            this.repository = repository;

            var tasks = repository.GetAll();

            if(tasks.Count > 0) 
            { 
                nextId = tasks.Max(t => t.Id);
            }
        }


        // Add a Task
        public void AddTask(TaskItem task)
        {
            nextId++;
            task.SetId(nextId);

            repository.Add(task);

            logger.Log($"Task Added: {task.Title}");
        }

        // Update a Task
        public bool UpdateTask(TaskItem task)
        {
            bool updated = repository.Update(task);

            if (updated)
            {
                logger.Log($"Task Updated: {task.Title}");
            }

            return updated;
        }

        // Delete a Task
        public bool DeleteTask(int id)
        {
            bool deleted = repository.Delete(id);

            if (deleted)
            {
                logger.Log($"Task Deleted: {id}");
            }

            return deleted;
        }

        // Search Tasks
        public IReadOnlyList<TaskItem> SearchTasks(string search)
        {
            return repository.GetAll()
                .Where(task => task.Title.ToLower().Contains(search.ToLower()))
                .ToList();
        }

        // mark as complete
        public bool CompleteTask(int id)
        {
            
            var taskToComplete = repository.GetAll().FirstOrDefault(t => t.Id == id);

            if(taskToComplete == null) { return false; }

            taskToComplete.MarkAsComplete();

            bool completed = repository.SaveMarkAsComplete();
            
            if (completed)
            {
                logger.Log($"Task Completed: {taskToComplete.Title}");
            }

            return completed;
        }

        public IReadOnlyList<TaskItem> FilterStatus(int choice)
        {
            if (choice == 1)
            {
                var tasks = repository.GetAll();
             
                return tasks;

            }
            else if (choice == 2)
            {
                var tasks = repository.GetAll()
                    .Where(task => task.IsCompleted).ToList();

                return tasks;

            }
            else
            {
                var tasks = repository.GetAll()
                    .Where(task => !task.IsCompleted).ToList();

                return tasks;

            }
        }

    }
}
