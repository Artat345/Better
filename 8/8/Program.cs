using System;
using System.IO;

public class EmptyFileDeleter
{
    public static void DeleteEmptyFiles(string directoryPath)
    {
        try
        {
            // Получаем все файлы в указанной директории
            string[] filePaths = Directory.GetFiles(directoryPath);

            // Перебираем все файлы и удаляем пустые
            foreach (string filePath in filePaths)
            {
                if (new FileInfo(filePath).Length == 0)
                {
                    try
                    {
                        // Пытаемся удалить файл
                        File.Delete(filePath);
                        Console.WriteLine($"Пустой файл удален: {filePath}");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Обработка ошибки доступа
                        Console.WriteLine($"Ошибка доступа к файлу: {filePath}. Пропускаем.");
                    }
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            // Обработка ошибки доступа к директории
            Console.WriteLine($"Ошибка доступа к директории: {directoryPath}. Пропускаем.");
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к директории:");
        string directoryPath = Console.ReadLine();

        DeleteEmptyFiles(directoryPath);
    }
}