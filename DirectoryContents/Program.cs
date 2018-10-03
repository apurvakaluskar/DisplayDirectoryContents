using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryContents
{
    class Program
    {
        static void Main(string[] args)
        {
            // string directoryPath = "E:\Test";  gives error that the string cannot contain an escape sequence. 
            // an escape sequence is a string of 1 or more characters starting with a backslash \
            // the c# parser considers \T as an escape sequence and hence throws that error
            // when @ is mentioned before the string, it tells the parser to read the string verbatim, i.e. the escape characters are also a part of the string and do not hold any special  meaning.
            // eg: string directoryPath = (@)"CRLF: \r\nPost CRLF"; Console.WriteLine(directoryPath);            

            //string directoryPath = @"E:\Test";
            Console.ReadLine();
        }

        public string[] ListFilesWithinDirectory(string directoryPath)
        {
            return Directory.GetFiles(RemoveInvalidCharFromDirPath(directoryPath));
            // return Directory.GetFiles(RemoveInvalidCharFromDirPath(directoryPath), "*", SearchOption.TopDirectoryOnly);

            //string[] filePaths = null;
            //try
            //{
            //    filePaths = Directory.GetFiles(RemoveInvalidCharFromDirPath(directoryPath));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.GetType() + ": " + e.Message);
            //}
            //return filePaths;
        }

        public string RemoveInvalidCharFromDirPath(string directoryPath)
        {
            char[] invalidChars = Path.GetInvalidPathChars();
            foreach (var character in invalidChars)
            {
                if (directoryPath.Contains(character))
                    directoryPath = directoryPath.Remove(directoryPath.IndexOf(character), 1);
            }
            return directoryPath;
        }

        public string[] GetAllContentsInTopDir(string directoryPath)
        {
            return Directory.GetFileSystemEntries(RemoveInvalidCharFromDirPath(directoryPath));
        }

        public string[] GetPatternMatchingFilesInDir(string directoryPath, string pattern)
        {
            return Directory.GetFiles(RemoveInvalidCharFromDirPath(directoryPath), pattern);
        }

        public string[] GetAllContentsInDir(string directoryPath, string pattern)
        {
            return Directory.GetFiles(RemoveInvalidCharFromDirPath(directoryPath), pattern, SearchOption.AllDirectories);
        }

    }
}
