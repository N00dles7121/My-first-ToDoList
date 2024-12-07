using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace ToDoList
{
    static public class ProgramLogic
    {
        public static void ShowTaskList(List<string> taskList)
        {
            //  Checks if list is empty
            if (taskList.Count == 0)
            {
                System.Console.WriteLine("Your task list is empty.");
                return;
            }

            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Hese's your task list:");

            // Displays all the tasks
            for (int i = 0; i < taskList.Count; i++)
            {
                Console.WriteLine(i + 1 + " - " + taskList[i]);
            }

            System.Console.WriteLine("----------------------");
        }

        static private bool CheckForDuplicates(List<string> tasks, string task)
        {
            return tasks.Contains(task);
        }

        public static void RemoveTask(List<string> taskList)
        {
            ShowTaskList(taskList);

            // Request user inputs
            System.Console.WriteLine("Input task number to delete.");

            // Check if user input is valid option
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= taskList.Count)
            {

                // Remove task at specified index and ask for repeated removal
                taskList.RemoveAt(taskNumber - 1);
                System.Console.WriteLine($"\nTask #{taskNumber} was succesfully removed.");
                System.Console.Write("Would you like to add another task (Y/N): ");

                // Call method again and stop it after completion or return to main menu
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    RemoveTask(taskList);
                    return;
                }
                else return;
            }

            // Ask if user wants to input another option or return to main menu
            else
            {
                    System.Console.WriteLine("\nWrong input.\n1 - try again.\n0 - main menu.");
                    if (Console.ReadLine() == "1")
                    {
                        RemoveTask(taskList);
                        return;
                    }
                    else
                    {
                        return;
                    }
            }
        }

        public static void AddTask(List<string> taskList)
        {
            string menuNavigation = "";

            System.Console.WriteLine("Please type in the task:");
            string taskToAdd = Console.ReadLine();
            if (taskToAdd == "" || CheckForDuplicates(taskList, taskToAdd))
            {
                System.Console.WriteLine("\nTask can not be empty or this task already exists.\n1 - try again.\n0 - main menu.");
                menuNavigation = Console.ReadLine();
                if (menuNavigation == "1")
                {
                    AddTask(taskList);
                    return;
                }
                else return;
            }

            taskList.Add(taskToAdd);

            System.Console.WriteLine("\nYour task succesfully added.");
            System.Console.Write("Would you like to add another task (Y/N): ");
            menuNavigation = Console.ReadLine().ToUpper();
            if (menuNavigation == "Y")
            {
                AddTask(taskList);
                return;
            }
            else return;
        }
    }
}