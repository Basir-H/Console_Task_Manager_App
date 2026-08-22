using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Task_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            bool program = true;

            TaskManager manager = new TaskManager();
            manager.LoadTasks();


            //Show All Tasks

            void ShowTasks()
            {

                Console.Clear();
                Console.WriteLine("======== All Tasks ========");
                Console.WriteLine();

                if (manager.Tasks.Count == 0)
                {
                    Console.WriteLine("Your task list is completely empty!");
                    return;
                }

                foreach (TaskItem task in manager.Tasks)
                {
                    task.DisplayDetails();
                }

            }

            //Create a Task
            void CreateTask()
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("======== Create a Task ========");

                    Console.WriteLine("1. Work Task");
                    Console.WriteLine("2. Personal Task");

                    Console.Write("Which Knid of Tasks do you create or Press 0 to Exit: ");
                    string task = Console.ReadLine();

                    if(task == "0") { break; }

                    if (!string.IsNullOrEmpty(task))
                    {
                        if (task == "1")
                        {
                            Console.Write("Task Name: ");
                            string taskName = Console.ReadLine();

                            Console.Write("Task Company: ");
                            string taskCompany = Console.ReadLine();

                            manager.AddTask(new WorkTask(taskName, taskCompany));
                            Console.WriteLine("Task Added Successfully!!");
                        }
                        else if (task == "2")
                        {
                            Console.Write("Task Name: ");
                            string taskName = Console.ReadLine();

                            Console.Write("Task Person: ");
                            string taskPerson = Console.ReadLine();
                            
                            manager.AddTask(new PersonalTask(taskName, taskPerson));
                            Console.WriteLine("Task Added Successfully!!");
                        }
                        else
                        {
                            Console.WriteLine("Please Enter a Valid Number (1-2)!!");
                        }
                    }
                }

            }
            
            //Update a Task
            void UpdateTask()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("======== Update a Task ========");
                    ShowTasks();
                    Console.WriteLine();
                    Console.WriteLine("0 to Exit");
                        

                    Console.Write("Which Task Do you Want to Update: ");

                    if(!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Please Enter Valid Id!!!");
                        continue;
                    }

                    if(id == 0) { break; }

                    Console.Write("Write the new Task: ");
                    string title = Console.ReadLine();

                    if(manager.UpdateTask(id, title))
                    {
                        Console.WriteLine("Task Updated Successfully!!!");
                    }
                    else
                    {
                        Console.WriteLine("Task is not found or Id is invalid");
                    }
                    
                }
            }

            
            //Delete a Task
            void DeleteTask()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("======== Delete a Task ========");

                    if (manager.Tasks.Count == 0)
                    {
                        Console.WriteLine("Nothing to delete!!");
                        return;
                    }

                    ShowTasks();

                    Console.Write("Which Task Do you Want to Delete or Press 0 to Exit: ");
                    
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Please Enter a Valid Number!");
                        continue;
                    }

                    if (id == 0) { break; }

                    Console.WriteLine("Are you sure you want to delete?  1. Yes    2. No");

                    int.TryParse(Console.ReadLine(), out int choice);

                    if (choice == 1)
                    {
                        if (manager.DeleteTask(id))
                        {
                            Console.WriteLine("Task Deleted Seccessfully!!");
                        }
                        else
                        {
                            Console.WriteLine("Task not Found or Id is invalid");
                        }
                    }
                }

            }

            // Live Search 
            void LiveSearch()
            {
                string search = "";

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("Live Task Search");
                    Console.WriteLine("----------------");
                    Console.WriteLine($"Search: {search}");

                    var results =  manager.SearchTasks(search); 

                    Console.WriteLine("\nResults:");

                    foreach (var task in results)
                    {
                        Console.WriteLine($"- {task.Title}");
                    }

                    Console.WriteLine("\nPress ESC to exit.");

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    if (key.Key == ConsoleKey.Backspace)
                    {
                        if (search.Length > 0)
                        {
                            search = search.Substring(0, search.Length - 1);

                        }
                    }
                    else if (!char.IsControl(key.KeyChar))
                    {
                        search += key.KeyChar;
                    }
                }
            }

            // Exit The program 
            void Exit()
            {
                Console.Write("Do you wan to Exit the Program? 1. Yes   2.No    :");
                int.TryParse(Console.ReadLine(), out int choice);
                
                if(choice == 1)
                {
                    program = false;
                }
                
            }



            Console.WriteLine("===================== Task Manager Console App =============================");

            
            while (program) 
            {
                Console.WriteLine("\n1. Show All Tasks\n2. Create a Task\n3. Update a Task\n4. Delete a Task\n5. Search a Task\n6. Exit the Program\n");

                Console.WriteLine();

                Console.Write("Which Action Do You Want? : ");

                if(!int.TryParse(Console.ReadLine(), out int choice)) 
                {
                    Console.WriteLine("Please Enter a Valid Number!");
                    continue;
                }

                switch (choice)
                {
                    case 1: ShowTasks(); break;

                    case 2: CreateTask(); break;

                    case 3: UpdateTask(); break;

                    case 4: DeleteTask(); break;

                    case 5: LiveSearch(); break;

                    case 6: Exit(); break;

                    default:
                        Console.WriteLine("Enter a Valid Number (1-6)"); break;
                }


            }
        }
    }
}
