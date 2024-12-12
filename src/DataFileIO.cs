using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ToDoList.scripts
{
    public class DataFileIO
    {

        static public List<string> ReadData(List<string> taskList)
        {
            // Read all data stored on the file
            StreamReader reader = new StreamReader(Path.GetFullPath(@"TaskList.txt"));
            try
            {
                string tempList = reader.ReadLine();

                while (tempList != null)
                {
                    taskList.Add(tempList);
                    tempList = reader.ReadLine();
                }
            }
            catch (IOException ex)
            {
                System.Console.WriteLine($"Error. Input-Output attempt failed.Exception message: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                System.Console.WriteLine($"Error. Unauthorized Access Exception. Error message: {ex.Message}");
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
            FileStream fileStream = new FileStream(Path.GetFullPath(@"TaskList.txt"), FileMode.Open);
            try
            {
                fileStream.SetLength(0);
            }
            catch (IOException ex)
            {
                System.Console.WriteLine($"Error. Input-Output attempt failed.Exception message: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                System.Console.WriteLine($"Error. Unauthorized Access Exception. Error message: {ex.Message}");
            }
            finally
            {
                fileStream.Close();
            }

            // Write new data on the file
            StreamWriter writer = new StreamWriter(Path.GetFullPath(@"TaskList.txt"));
            try
            {
                foreach (var task in taskList)
                {
                    writer.WriteLine(task);
                }
            }
            catch (IOException ex)
            {
                System.Console.WriteLine($"Error. Input-Output attempt failed.Exception message: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                System.Console.WriteLine($"Error. Unauthorized Access Exception. Error message: {ex.Message}");
            }
            finally
            {
                writer.Close();
            }
        }
    }
}