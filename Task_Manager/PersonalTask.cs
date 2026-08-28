using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    internal class PersonalTask : TaskItem
    {
        private string _person;

        public string Person
        {
            get{ return _person; }
            set { _person = value; }
        }

        public override void DisplayDetails()
        {

            Console.WriteLine($"ID       : {Id}");
            Console.WriteLine($"Type     : Personal");
            Console.WriteLine($"Title    : {Title}");
            Console.WriteLine($"Person   : {Person}");
            Console.WriteLine($"Status   : {(IsCompleted ? "Completed" : "Incomplete")}");

            Console.WriteLine("==============================");
            Console.WriteLine();
        }

        public override void UpdateFrom(TaskItem other)
        {
            if(!(other is PersonalTask personalTask))
            {
                throw new ArgumentException("Invalid task type for update.");
            }

            Title = personalTask.Title;
            Person = personalTask.Person;
        }

        public PersonalTask(string title, string person)
            :base(title)
        {
            Person = person;
        }

        public PersonalTask(string title, string person, bool isCompleted)
            : base(title, isCompleted)
        {
            Person = person;
        }
    }
}
