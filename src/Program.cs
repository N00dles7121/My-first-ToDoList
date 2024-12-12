using System;
using System.Text;
using System.IO;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using ToDoList.scripts;


namespace ToDoList
{
    class Program
    {
        static void Main()
        {
            List<string> taskList = new List<string>();
            bool isOnline = true;

            DataFileIO.ReadData(taskList);

            System.Console.WriteLine("Hello to my to do list.\n----------------------------");

            do
            {

                System.Console.WriteLine("\nMain Menu\n----------------------------\n");
                System.Console.WriteLine("Please select one of the optoins bellow: ");
                System.Console.WriteLine("1 - See all tasks.");
                System.Console.WriteLine("2 - Add new task to the list.");
                System.Console.WriteLine("3 - Edit existing task.");
                System.Console.WriteLine("4 - Remove task from the list.");
                System.Console.WriteLine("0 - Save and exit.");

                char.TryParse(Console.ReadLine(), out char input);

                switch (input)
                {
                    case '1':
                        Console.Clear();
                        ProgramLogic.ShowTaskList(taskList);
                        System.Console.WriteLine("Press any key to return to main menu.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '2':
                        Console.Clear();
                        ProgramLogic.AddTask(taskList);
                        Console.Clear();
                        break;
                    case '3':
                        Console.Clear();
                        ProgramLogic.EditTask(taskList);
                        Console.Clear();
                        break;
                    case '4':
                        Console.Clear();
                        ProgramLogic.RemoveTask(taskList);
                        Console.Clear();
                        break;
                    case '0':
                        isOnline = false;
                        break;
                    default:
                        System.Console.WriteLine("Wrong input. Try again.");
                        break;
                }
            } while (isOnline);

            System.Console.WriteLine("\nThanks for visiting. Press any key to exit.");
            DataFileIO.WriteData(taskList);
            Console.ReadKey();
        }
    }
}
