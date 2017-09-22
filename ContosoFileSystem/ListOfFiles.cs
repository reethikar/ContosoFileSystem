using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContosoFileSystem
{
    class ListOfFiles
    {
        public static void PrintFiles(string dirPath)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            Directory.SetCurrentDirectory(dirPath);
            FileInfo[] fi = di.GetFiles();
            if (fi.Length > 0)
            {
                Console.WriteLine("The following files exists in the current directory:");
                foreach (FileInfo fiTemp in fi)
                    Console.WriteLine("{0}\t<FILE>\t{1}",File.GetCreationTime(fiTemp.Name),fiTemp.Name);
            }
            else
            {
                Console.WriteLine("No files inside {0}.",dirPath);
            }
        }
        public static int PrintDirs(string dirPath)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            Directory.SetCurrentDirectory(dirPath);
            // Create an array representing the files in the current directory.
            //FileInfo[] fi = di.GetFiles();
            DirectoryInfo[] dirs = di.GetDirectories();

            if (dirs.Length > 0)
            {
                Console.WriteLine("The following directories exist in the current directory:");
                foreach (DirectoryInfo dirTemp in dirs)
                    Console.WriteLine("{0}\t <DIR>\t {1}", Directory.GetCreationTime(dirTemp.Name), dirTemp.Name);
            }
            else
            {
                Console.WriteLine("No directories inside {0}.", dirPath);
            }
            return 1;
        }

    }

}
