using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    internal class WorkTask : TaskItem
    {
        private string _company;

        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }

        public override void DisplayDetails()
        {

            Console.WriteLine($"ID       : {Id}");
            Console.WriteLine($"Type     : Work");
            Console.WriteLine($"Title    : {Title}");
            Console.WriteLine($"Company  : {Company}");
            Console.WriteLine($"Status   : {(IsCompleted ? "Completed" : "Incomplete")}");

            Console.WriteLine("==============================");
            Console.WriteLine();
        }

        public override void UpdateFrom(TaskItem other)
        {
            if(!(other is WorkTask workTask))
            {
                throw new ArgumentException("Invalid task type for update.");
            }
            
            Title = workTask.Title;
            Company = workTask.Company;            
        }

        public WorkTask(string title, string company) 
            : base(title)
        {
            Company = company;
        }

        public WorkTask(string title, string company, bool isCompleted)
            : base(title, isCompleted)
        {
            Company = company;
        }
    }
}
