using System;

/*
 * Реализация и анализ производительности программы для сравнения файлов
 * под операционной системой Linux
 *
 */

namespace compareFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMainMenu();

            var menuEntry = Console.ReadLine();

            Console.Clear();

            switch (menuEntry)
            {
                case "1":
                    // Показать все файлы в текущей директории
                    Pages.CompareFiles();
                    break;
                case "2":
                    // Показать все файлы в указанной директории
                    Pages.CompareFiles();
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

        /// <summary>
        /// Вывод главного меню
        /// </summary>
        private static void PrintMainMenu()
        {
            Console.WriteLine($"compareFiles - главное меню");
            Console.WriteLine("Выберите пункт меню:");
            Console.WriteLine("1. Побитовое сравнение 2-х файлов по содержимому.");
            Console.WriteLine("2. Путь к да");
            Console.WriteLine("3. Ни ху кто я?)");
            Console.WriteLine("exit. Выход");
            Console.Write("\n> ");
        }
    }
}