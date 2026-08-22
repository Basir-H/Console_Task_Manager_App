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
            Console.WriteLine($"{Id}|Personal|{Title}|{Person}");
        }

        public PersonalTask(string title, string person)
            :base(title)
        {
            Person = person;
        }
    }
}
