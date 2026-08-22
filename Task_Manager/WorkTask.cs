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
            Console.WriteLine($"{Id}|Work|{Title}|{Company}");
        }

        public WorkTask(string title, string company) 
            : base(title)
        {
            Company = company;
        }
    }
}
