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
                
                if (tasks.Count == 0)
                {
                    Console.WriteLine("Your task list is completely empty!");
                    return;
                }

                for (int i = 0;  i < tasks.Count; i++)
                {
                    Console.WriteLine($"Task {i}: {tasks[i]}, ");
                }
            }

            //Create a Task
            void CreateTask()
            {
                Console.Write("Task Name: ");
                string task = Console.ReadLine();

                if (!string.IsNullOrEmpty(task))
                {
                    tasks.Add(task);
                    SaveTasksToFile();
                    Console.WriteLine("Task Added Successfully!!");
                }

            }
            
            //Update a Task
            void UpdateTask()
            {
                ShowTasks();

                Console.Write("Which Task Do you Want to Update: ");

                if (int.TryParse(Console.ReadLine(), out int taskIndex) && taskIndex >= 0 && taskIndex < tasks.Count) 
                {
                    Console.Write("Write the new Task: ");
                    string newTask = Console.ReadLine();
                    
                    tasks[taskIndex] = newTask;
                    SaveTasksToFile();
                    Console.WriteLine("Task Updated Successfully!!!");
                }
                else
                {
                    Console.WriteLine("Invalid Task Index");
                }
            }

            
            //Delete a Task
            void DeleteTask()
            {
                ShowTasks();

                if(tasks.Count == 0)
                {
                    Console.WriteLine("Nothing to delete!!");
                    return;
                }
                
                Console.Write("Which Task Do you Want to Delete: ");
                
                if(int.TryParse(Console.ReadLine(), out int taskIndex) && taskIndex >= 0 && taskIndex < tasks.Count)
                {
                    Console.WriteLine("Are you sure you want to delete?  1. Yes    2. No");
                    int.TryParse(Console.ReadLine(), out int choice);

                    if(choice == 1)
                    {
                        tasks.RemoveAt(taskIndex);
                        SaveTasksToFile();
                        Console.WriteLine("Task Deleted Seccessfully!!");
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
                Console.WriteLine("\n1. Show All Tasks\n2. Create a Task\n3. Update a Task\n4. Delete a Task\n5. Exit the Program\n");

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

                    case 5: Exit(); break;

                    default:
                        Console.WriteLine("Enter a Valid Number (1-5)"); break;
                }


            }
        }
    }
}
