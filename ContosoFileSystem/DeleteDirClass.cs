using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ContosoFileSystem
{
    class DeleteDirClass
    {
        static void CheckAndDelete(string check)
        {
            Program obj = new Program();
            string curr = Directory.GetCurrentDirectory();
            if (check == curr)
            {
                string current = obj.GetParent(curr);
                Directory.SetCurrentDirectory(current);
            }

            if (Directory.Exists(check))
            {
                Directory.Delete(check);
                Console.WriteLine("{0} was successfully deleted.",check);
            }
            else
            {
                Console.WriteLine("Directory {0} does not exist. Check help menu for more details. Type \"help del\".",check);
            }
        }
        public static int DeleteDirectory(string input)
        {
            if (input.Contains(":"))
            {
                CheckAndDelete(input);
            }
            else
            {
                string currDir = Directory.GetCurrentDirectory();
                string toCheck = currDir + "\\" + input;
                CheckAndDelete(toCheck); 
            }
            return 1;
        }

       
    }
}
