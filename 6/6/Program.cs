using System;
using System.IO;

public class FileMerger
{
    public static void MergeFiles(string directoryPath, string outputFilePath)
    {
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            // Получаем все текстовые файлы в указанной директории
            string[] filePaths = Directory.GetFiles(directoryPath, "*.txt");

            foreach (string filePath in filePaths)
            {
                try
                {
                    // Читаем содержимое файла и записываем в выходной файл
                    string content = File.ReadAllText(filePath);
                    writer.WriteLine(content);
                    Console.WriteLine($"Содержимое файла {filePath} добавлено в {outputFilePath}.");
                }
                catch (IOException ex)
                {
                    // Обработка ошибок ввода-вывода
                    Console.WriteLine($"Ошибка ввода-вывода при обработке файла {filePath}: {ex.Message}. Пропускаем.");
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к директории с текстовыми файлами:");
        string directoryPath = Console.ReadLine();

        Console.WriteLine("Введите путь к выходному файлу:");
        string outputFilePath = Console.ReadLine();

        MergeFiles(directoryPath, outputFilePath);
    }
}