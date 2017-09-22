using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoFileSystem
{
    class HelpClass
    {
            public static int PrintHelp(string forHelp)
            {
                if (forHelp.ToUpper() == "CD")
                {
                    Console.WriteLine("Displays the name of or changes the current directory. \n" + 
                        "CD [drive:][path]" + "\n" +
                        "CD[..(/..)*]" + "\n" +
                        "..Specifies that you want to change to the parent directory.\n");
                }
                else if (forHelp.ToUpper() == "MD")
                {
                    Console.WriteLine("Creates a directory." + "\n" +
                        "MD[drive:]path" + "\n" +
                        "This command creates a directory and returns success message with directory creation time.");
                }

                else if (forHelp.ToUpper() == "DIR")
                {
                    Console.WriteLine("Displays a list directories in a directory." + "\n" +
                        "DIR[drive:][path][filename]");

                }

                else if (forHelp.ToUpper() == "DEL")
                {
                    Console.WriteLine("Deletes one or more directories." + "\n" +
                        "DEL[drive:][PATH] or DEL [DIRECTORY]\n" +
                        "Deletes one or more directories." + "\n" +
                        "If a directory is specified, all files and directories within the directory " + "\n" +
                        "will be deleted. \n If a full path is provided, the directory is deleted if it exists.");
                }
                else if (forHelp.ToUpper() == "HELP")
                {
                    Console.WriteLine("Provides help information for Windows commands." + "\n" +
                        "HELP[command]" + "\n" +
                        "command - displays help information on that command.");
                }
                else
                {
                    Console.WriteLine("\t No help entry for : {0}. Check input and try again. \n\t Type exit/logout to exit.", forHelp);
                }
            return 1;
            }
     
    }
}
