using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_Manager
{
    internal abstract class TaskItem
    {
        private int _id;
        private string _title;
        private bool _isCompleted;     

        public int Id 
        {
            get { return _id; }
            private set { _id = value; }    
        }

        public string Title 
        {
            get { return _title; }
            set { _title = value; }
        }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            private set { _isCompleted = value; }
        }

        public void SetId(int id) { Id = id; }

        public abstract void DisplayDetails();

        public abstract void UpdateFrom(TaskItem other);

        public void MarkAsComplete()
        {
            IsCompleted = true;
        }

        public TaskItem(string title)
        {
            Title = title;
            IsCompleted = false;
        }

        public TaskItem(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public TaskItem(string title, bool isCompleted)
        {
            Title = title;
            IsCompleted = isCompleted;
        }
    }
}









// New C# feature 
//public string Title { get; set; } = title;
