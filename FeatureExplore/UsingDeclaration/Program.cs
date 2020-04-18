using System;
using System.IO;

namespace UsingDeclaration
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "SomePath";
            Example1.UsingStatement(path);
            Example1.UsingDeclaration(path);

            Example2.UsingStatement(path);
            Example2.UsingDeclaration(path);
        }

        static int UsingStatement(string filePath)
        {
            var lineCount = 0;
            var line = string.Empty;
            using (var fileReader = File.OpenText(filePath))
            {
                while ((line = fileReader.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                    lineCount++;
                }
            }
            return lineCount;
        }


        static int UsingDeclaration(string filePath)
        {
            var lineCount = 0;
            var line = string.Empty;
            using var fileReader = File.OpenText(filePath);

            while ((line = fileReader.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                lineCount++;
            }
            return lineCount;
        }
    }

    public static class Example1
    {
        public static string UsingStatement(string filePath)
        {
            using (var fileReader = File.OpenText(filePath))
            {
                return fileReader.ReadToEnd();
            }
        }


        public static string UsingDeclaration(string filePath)
        {
            using var fileReader = File.OpenText(filePath);
            return fileReader.ReadToEnd();
        }
    }

    public static class Example2
    {
        public static int UsingStatement(string filePath)
        {
            var lineCount = 0;
            var lineRead = string.Empty;
            using (var fileReader = File.OpenText(filePath))
            {
                while ((lineRead = fileReader.ReadLine()) != null)
                {
                    lineCount++;
                }
            }
            return lineCount;
        }


        public static int UsingDeclaration(string filePath)
        {
            var lineCount = 0;
            var lineRead = string.Empty;
            using var fileReader = File.OpenText(filePath);

            while ((lineRead = fileReader.ReadLine()) != null)
            {
                lineCount++;
            }
            return lineCount;
        }
    }
}
