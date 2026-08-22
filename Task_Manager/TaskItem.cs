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
     

        public int Id {
            get { return _id; }
            private set { _id = value; }    
        }

        public string Title {
            get { return _title; }
            set { _title = value; }
        }

        public void SetId(int id) { Id = id; }

        public abstract void DisplayDetails();

        public TaskItem(string title)
        {
            Title = title;
        }

        public TaskItem(int id, string title)
        {
            Id = id;
            Title = title;
        } 


    }
}









// New C# feature 
//public string Title { get; set; } = title;
