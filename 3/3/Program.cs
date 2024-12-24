using System;
using System.IO;

public class FileMover
{
    public static void MoveFiles(string sourceDirectory, string destinationDirectory, string fileExtension)
    {
        try
        {
            // Проверяем, существует ли исходная директория
            if (!Directory.Exists(sourceDirectory))
            {
                Console.WriteLine("Исходная директория не найдена.");
                return;
            }

            // Создаем целевую директорию, если она не существует
            Directory.CreateDirectory(destinationDirectory);

            // Получаем все файлы с указанным расширением
            string[] files = Directory.GetFiles(sourceDirectory, $"*{fileExtension}");

            // Перемещаем каждый файл в целевую директорию
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationDirectory, fileName);
                File.Move(file, destFile);
                Console.WriteLine($"Файл {fileName} перемещен в {destinationDirectory}.");
            }

            if (files.Length == 0)
            {
                Console.WriteLine("Файлы с указанным расширением не найдены.");
            }
        }
        catch (IOException ex)
        {
            // Обработка ошибок ввода-вывода
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
        catch (UnauthorizedAccessException)
        {
            // Обработка ошибок доступа
            Console.WriteLine("Ошибка доступа: у вас нет прав на доступ к одной из директорий.");
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к исходной директории:");
        string sourceDirectory = Console.ReadLine();

        Console.WriteLine("Введите путь к целевой директории:");
        string destinationDirectory = Console.ReadLine();

        Console.WriteLine("Введите расширение файлов (например, .txt):");
        string fileExtension = Console.ReadLine();

        MoveFiles(sourceDirectory, destinationDirectory, fileExtension);
    }
}