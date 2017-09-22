using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ContosoFileSystem
{
    class ChangeDir
    {
        public static int ChangeDirectory(string input)
        {
            int toReturn;
            Program object2 = new Program();
            string current = Directory.GetCurrentDirectory();
            string inp = input.Substring(3);
            if (Regex.Matches(inp, @"[a-zA-Z]").Count > 0)
            {
                try
                {
                    inp = inp.Trim();
                    Directory.SetCurrentDirectory(inp);
                    toReturn = 1;
                }
                catch
                {
                    Console.WriteLine("\t Input error.\n\t Type exit/logout to exit.");
                    toReturn = 1;
                }
            }
            else
            {
                string[] howManyTimes = inp.Split('/');
                for (int i = 0; i < howManyTimes.Length; i++)
                {
                    if (howManyTimes[i] == "..")
                    {
                        current = object2.GetParent(current);
                        Directory.SetCurrentDirectory(current);
                    }
                    else
                        break;
                }
                toReturn = 1;
            }


            return toReturn;
        }
        
    }
}
