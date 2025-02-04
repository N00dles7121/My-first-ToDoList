using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace ToDoList
{
    public static class ProgramLogic
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

        public static void RemoveTask(List<string> taskList)
        {
            ShowTaskList(taskList);

            // Request user inputs
            System.Console.Write("Input task number to delete.");

            // Check if user input is valid option
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= taskList.Count)
            {

                // Remove task at specified index and ask for repeated removal
                taskList.RemoveAt(taskNumber - 1);
                System.Console.WriteLine($"\nTask #{taskNumber} was succesfully removed.");
                System.Console.Write("Would you like to remove another task (Y/N): ");

                // Call method again and stop previous after completion or return to main menu
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    RemoveTask(taskList);
                    return;
                }
                else return;
            }

            // Ask if user wants to input another option or return to main menu
            System.Console.WriteLine("\nWrong input.\n1 - try again.\n0 - main menu.");
            if (Console.ReadLine() == "1")
            {
                RemoveTask(taskList);
                return;
            }
            else return;
        }

        public static void AddTask(List<string> taskList)
        {
            string menuNavigation = "";

            // Request user input
            System.Console.WriteLine("Please type in the task:");
            string taskToAdd = Console.ReadLine();

            // Check for valid input and add task to the list or ask another valid input
            if (taskToAdd == "" || taskList.Contains(taskToAdd))
            {
                System.Console.WriteLine("\nTask can not be empty or this task already exists.\n1 - try again.\n0 - main menu.");
                menuNavigation = Console.ReadLine();

                // Call method again and stop previous after completion or return to main menu
                if (menuNavigation == "1")
                {
                    AddTask(taskList);
                    return;
                }
                else return;
            }

            // Add task to the list if input is valid
            taskList.Add(taskToAdd);
            System.Console.WriteLine("\nYour task succesfully added.");

            // Ask for repeated operation or return to main menu
            System.Console.Write("Would you like to add another task (Y/N): ");
            menuNavigation = Console.ReadLine().ToUpper();

            if (menuNavigation == "Y")
            {
                AddTask(taskList);
                return;
            }
            else return;
        }

        public static void EditTask(List<string> taskList)
        {
            string menuNavigation = "";
            ShowTaskList(taskList);

            System.Console.Write("Input task number to edit: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= taskList.Count)
            {
                // Remove task at specified index and ask for repeated removal
                System.Console.WriteLine($"\nType in new task body: ");
                string newBody = Console.ReadLine();

                if (newBody == "" || taskList.Contains(newBody))
                {
                    System.Console.WriteLine("\nTask can not be empty or this task already exists.\n1 - try again.\n0 - main menu.");
                    menuNavigation = Console.ReadLine();

                    if (menuNavigation == "1")
                    {
                        EditTask(taskList);
                        return;
                    }
                    else return;
                }

                taskList[taskNumber - 1] = newBody;
                System.Console.Write("Would you like to edit another task (Y/N): ");

                // Call method again and stop previous after completion or return to main menu
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    EditTask(taskList);
                    return;
                }
                else return;
            }
        }
    }
}