using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace ToDoList
{
    static public class ProgramLogic
    {
        public static void ShowTaskList(Dictionary<int, string> taskList)
        {
            if (taskList.Count == 0)
            {
                System.Console.WriteLine("Your task list is empty.");
                return;
            }

            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Hese's your task list:");

            foreach (var task in taskList)
            {
                Console.WriteLine(task.Key + " - " + task.Value);
            }

            System.Console.WriteLine("----------------------");
        }

        public static void RemoveTask(Dictionary<int, string> taskList)
        {
            ShowTaskList(taskList);

            System.Console.WriteLine("Input task number to delete.");
            if (int.TryParse(Console.ReadLine(), out int key) && taskList.ContainsKey(key))
            {
                taskList.Remove(key);
                System.Console.WriteLine($"Task #{key} was succesfully removed.");
                System.Console.Write("Would you like to add another task (Y/N): ");

                if (Console.ReadLine().ToUpper() == "Y")
                {
                    RemoveTask(taskList);
                    return;
                }
                else return;
            }
            else
            {
                do
                {
                    System.Console.WriteLine("Wrong input.\n1 - try again.\n0 - main menu.");
                    if (Console.ReadLine() == "1")
                    {
                        RemoveTask(taskList);
                        return;
                    }
                    else
                    {
                        break;
                    }
                } while (Console.ReadLine() != "1" || Console.ReadLine() != "0");
            }
        }

        public static void AddTask(Dictionary<int, string> taskList)
        {
            string menuNavigation = "";
            bool isTrying = true;

            do
            {
                System.Console.WriteLine("Please type in the task:");
                string taskToAdd = Console.ReadLine();
                if (taskToAdd == "")
                {
                    System.Console.WriteLine("Task can not be empty.\n1 - try again.\n0 - main menu.");
                    menuNavigation = Console.ReadLine();
                    if (menuNavigation == "1")
                    {
                        AddTask(taskList);
                        return;
                    }
                    else break;
                }

                taskList.Add(taskList.Count + 1, taskToAdd);

                System.Console.WriteLine("Your task succesfully added.");
                System.Console.Write("Would you like to add another task (Y/N): ");
                menuNavigation = Console.ReadLine().ToUpper();
                if (menuNavigation == "Y")
                {
                    AddTask(taskList);
                    return;
                }
                else break;
            } while (isTrying);

            Console.Clear();
            return;
        }
    }
}