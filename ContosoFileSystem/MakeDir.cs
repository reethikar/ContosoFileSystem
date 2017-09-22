using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContosoFileSystem
{
    class MakeDir
    {
        public static void MakeDirectory(string send)
        {
            string currDir = Directory.GetCurrentDirectory();
            send = send.Trim();
            string[] dirArray;
            if (send[0] != '"')
            {
                try
                {
                    if (!send.Contains(" "))
                    {
                        throw new Exception();
                    }
                    dirArray = send.Split(' ');
                    foreach (string directory in dirArray)
                    {
                        string dirPath = @currDir + "\\" + directory;
                        DirectoryInfo di = Directory.CreateDirectory(dirPath);
                        Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(dirPath));
                    }
                }
                catch
                {
                    string directory = send;
                    string dirPath = @currDir + "\\" + directory;
                    DirectoryInfo di = Directory.CreateDirectory(dirPath);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(dirPath));
                }
            }
            else
            {
                int l = send.Length;
                if (send[l - 1] == '"')
                {
                    string[] stripped = send.Split('"');
                    string directory = stripped[1];
                    string dirPath = @currDir + "\\" + directory;
                    DirectoryInfo di = Directory.CreateDirectory(dirPath);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(dirPath));
                }
                else
                {
                    Console.WriteLine("\t Input Error. Try again.\n\t Type \"help md\" for help on syntax.\n\t Type exit/logout to exit.");
                }
            }

        }

    }
}
