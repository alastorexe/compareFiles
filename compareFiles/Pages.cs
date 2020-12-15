using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace compareFiles
{
    public static class Pages
    {
        public static void CompareFiles()
        {
            Dictionary<string, string> paramsFindFiles = new Dictionary<string, string>();

            while (true)
            {
                PrintMenuChoiseFile();

                string menuEntry = Console.ReadLine();

                Console.Clear();

                switch (menuEntry)
                {
                    case "1":
                        // Ввести путь к файлам
                        Pages.EnterFile();
                        break;
                    case "2":
                        // Создать 2 файла
                        Pages.CreateFile();
                        break;
                    case "exit":
                        // просто выходим
                        return;
                    default:
                        // Если ввели что-то кривое
                        Console.WriteLine("Неверный ввод");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }
        }


        public static void PrintMenuChoiseFile()
        {
            Console.WriteLine($"Pages - выбор файлов");
            Console.WriteLine("Выберите пункт меню:");
            Console.WriteLine("1. Выбрать 2 файла из системы");
            Console.WriteLine("2. Создать 2 файла");
            Console.WriteLine("exit. Выход");
            Console.Write("\n> ");
        }

        public static void EnterFile()
        {
            Dictionary<string, string> pathToFiles = new Dictionary<string, string>();
            for (int i = 1; i <= 2; i++)
            {
                string path = "";
                while (!File.Exists(path))
                {
                    Console.WriteLine("Введите путь к  файлу " + i + ": ");

                    path = Console.ReadLine();
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("Такого файла не существует. Попробуйте ещё раз.");
                    }
                    else
                    {
                        pathToFiles.Add("file" + i, path);
                    }

                    Console.WriteLine();
                }
            }

            Pages.FileCompare(pathToFiles);
        }

        public static void CreateFile()
        {
            Dictionary<string, string> pathToFiles = new Dictionary<string, string>();
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine("Введите содержимое файла " + i + ": ");
                string contentFile = Console.ReadLine();
                string fileName = "file" + i + ".txt";
                string path = Path.Combine(Environment.CurrentDirectory, fileName);
                try
                {
                    // Create the file, or overwrite if the file exists.
                    using (FileStream fs = File.Create(path))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(contentFile ?? "file");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                if (File.Exists(path))
                {
                    pathToFiles.Add("file" + i, path);
                }

                Console.WriteLine();
            }

            Pages.FileCompare(pathToFiles);
        }

        private static void FileCompare(Dictionary<string, string> pathToFiles)
        {
            if (Helper.FileCompare(pathToFiles))
            {
                Console.WriteLine("Файлы одинаковые");
            }
            else
            {
                Console.WriteLine("Файлы НЕ одинаковые");
            }
        }

    }
}