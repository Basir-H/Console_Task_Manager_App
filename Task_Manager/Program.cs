using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Task_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "tasks.txt";

            bool program = true;
            List<string> tasks = new List<string>();

            if (File.Exists(filePath)) 
            {
                string[] loadedTasks = File.ReadAllLines(filePath);
                tasks = new List<string>(loadedTasks);

            }

            void SaveTasksToFile()
            {
                File.WriteAllLines(filePath, tasks);
            }


            //Show All Tasks
            void ShowTasks() 
            {
                
                    Console.Clear();
                    Console.WriteLine("======== All Tasks ========");

                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("Your task list is completely empty!");
                        return;
                    }

                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Console.WriteLine($"Task {i + 1}: {tasks[i]}, ");
                    }
              
            }

            //Create a Task
            void CreateTask()
            {
                    Console.Clear();
                while (true)
                {
                    Console.WriteLine("======== Create a Task ========");

                    Console.Write("Task Name or Press 0 to Exit: ");
                    string task = Console.ReadLine();

                    if(task == "0") { break; }

                    if (!string.IsNullOrEmpty(task))
                    {
                        tasks.Add(task);
                        SaveTasksToFile();
                        Console.WriteLine("Task Added Successfully!!");
                        Console.WriteLine();
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
                    Console.WriteLine("0 to Exit");
                        

                    Console.Write("Which Task Do you Want to Update: ");

                    if(!int.TryParse(Console.ReadLine(), out int taskIndex))
                    {
                        Console.WriteLine("Please Enter Valid Number!!!");
                        continue;
                    }

                    if(taskIndex == 0) { break;  }


                    if(taskIndex - 1 >= 0 && taskIndex - 1 < tasks.Count)
                    {
                        Console.Write("Write the new Task: ");
                        string newTask = Console.ReadLine();

                        tasks[taskIndex - 1] = newTask;
                        SaveTasksToFile();
                        Console.WriteLine("Task Updated Successfully!!!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Task Index");
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


                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("Nothing to delete!!");
                        return;
                    }
                    ShowTasks();

                    Console.Write("Which Task Do you Want to Delete or Press 0 to Exit: ");
                    
                    if (!int.TryParse(Console.ReadLine(), out int taskIndex))
                    {
                        Console.WriteLine("Please Enter a Valid Number!");
                        continue;
                    }

                    if (taskIndex == 0) { break; }
                    
                    if (taskIndex - 1 >= 0 && taskIndex - 1 < tasks.Count)
                    {

                        Console.WriteLine("Are you sure you want to delete?  1. Yes    2. No");
                        int.TryParse(Console.ReadLine(), out int choice);

                        if (choice == 1)
                        {
                            tasks.RemoveAt(taskIndex - 1);
                            SaveTasksToFile();
                            Console.WriteLine("Task Deleted Seccessfully!!");
                        }

                    }
                }

            }

            void LiveSearch()
            {
                string search = "";

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("Live Task Search");
                    Console.WriteLine("----------------");
                    Console.WriteLine($"Search: {search}");

                    var results = tasks
                        .Where(t => t.Contains(search.ToLower()))
                        .ToList();

                    Console.WriteLine("\nResults:");

                    foreach (var task in results)
                    {
                        Console.WriteLine($"- {task}");
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
