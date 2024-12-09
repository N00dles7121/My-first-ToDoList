using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ToDoList.scripts
{
    public class DataFileIO
    {
        static public List<string> ReadData(List<string> taskList)
        {
            // Read all data stored on the file
            StreamReader reader = new StreamReader(@"C:\Users\Альберт\Desktop\ToDoList\TaskList.txt");
            try
            {
                string tempList = reader.ReadLine();

                while (tempList != null)
                {
                    taskList.Add(tempList);
                    tempList = reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured. Unable to read file.");
                throw new ApplicationException("Exception: ", ex);
            }
            finally
            {
                reader.Close();
            }

            return taskList;
        }

        static public void WriteData(List<string> taskList)
        {

            // Flush all data stored on the file
            FileStream fileStream = new FileStream(@"C:\Users\Альберт\Desktop\ToDoList\TaskList.txt", FileMode.Open);
            try
            {
                fileStream.SetLength(0);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured. Unable to flush file.");
                throw new ApplicationException("Exception: ", ex);
            }
            finally
            {
                fileStream.Close();
            }

            // Write new data on the file
            StreamWriter writer = new StreamWriter(@"C:\Users\Альберт\Desktop\ToDoList\TaskList.txt");
            try
            {
                foreach (var task in taskList)
                {
                    writer.WriteLine(task);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured. Unable to write on file.");
                throw new ApplicationException("Exception: ", ex);
            }
            finally
            {
                writer.Close();
            }
        }
    }
}