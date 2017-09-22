using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ContosoFileSystem
{
   
    class Program
    {
        public string GetParent(string path)
        {
            string toReturn;
            try
            {
                DirectoryInfo directoryInfo =
                    Directory.GetParent(path);

                //Console.WriteLine("This is the directory :");
                //Console.WriteLine(directoryInfo.FullName);
                toReturn = directoryInfo.FullName;

            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Path is a null reference.");
                toReturn = null;
                
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Path is an empty string, " +
                    "contains only white spaces, or " +
                    "contains invalid characters.");
                toReturn = null;
            }
            return toReturn;
        }
        static int TakeInput ()
        {
            Program object1 = new Program();
            int toReturn;
            string firstTwo ,firstThree, isHelp = null; 
            string input = Console.ReadLine();
            try
            {
                firstThree = input.Substring(0, 3).Trim();
                firstTwo = input.Substring(0, 2).Trim();
                if (input.Length > 4)
                    isHelp = input.Substring(0, 4).Trim();
            }
            catch
            {
                Console.WriteLine("\tInput Error.");
                firstTwo = null;
                isHelp = null;
                firstThree = null;
                toReturn = 1;
            }
            try
            {
                if ((firstTwo.ToUpper()) == "MD")
                {
                    string send = input.Substring(3);
                    MakeDir.MakeDirectory(send);
                    toReturn = 1;
                }
                else if ((firstTwo.ToUpper()) == "CD")
                {
                    toReturn = ChangeDir.ChangeDirectory(input);
                }
                else if ((input == "logout") || (input == "exit"))
                {
                    toReturn = 0;
                }
                else if ((isHelp != null) && (isHelp.ToUpper() == "HELP"))
                {
                    string word = input.Substring(5);
                    HelpClass.PrintHelp(word);
                    toReturn = 1;
                }
                else if (firstThree.ToUpper() == "DIR")
                {
                    string path;
                    try
                    {
                        path = input.Substring(4);
                        path = path.Trim();
                    }
                    catch
                    {
                        path = Directory.GetCurrentDirectory();
                    }
                    ListOfFiles.PrintFiles(path);
                    toReturn = 1;
                }
                else if ((firstThree.ToUpper()) == "DEL")
                {
                    string send = input.Substring(4).Trim();
                    DeleteDirClass.DeleteDirectory(send);
                    toReturn = 1;
                }
                else
                {
                    Console.WriteLine("\tInput Error.\n\tType exit/logout to exit.");
                    toReturn = 1;
                }
            }
            catch
            {
                Console.WriteLine("\tTry again or try help menu. \n\tType exit/logout to exit.");
                toReturn = 1;
            }
            return toReturn;
        }
      
        static void Main(string[] args)
        {
            int returned = 1;
            int firstTime = 1;
            while (returned != 0)
            {

                string dirPath = @"Z:\\";
                
                string dir = Directory.GetCurrentDirectory();
                if ((Directory.Exists(dirPath)) && (firstTime == 1))
                {
                    try
                    {
                        //Set the current directory.
                        Directory.SetCurrentDirectory(dirPath);
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        Console.WriteLine("The specified directory does not exist. {0}", e);
                    }

                   
                }
                else if (!(Directory.Exists(dirPath)) && (firstTime == 1))
                {
                    DirectoryInfo di = Directory.CreateDirectory(dirPath);
                    Directory.SetCurrentDirectory(dirPath);

                }
                firstTime = 0;
                
                string toPrint = "Z:\\>";
                toPrint = Directory.GetCurrentDirectory();
                Console.Write("{0}>",toPrint);
                returned = TakeInput();
            }
        }
    }
}
