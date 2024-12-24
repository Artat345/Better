using System;
using System.IO;

public class FileCopier
{
    public static void CopyFileWithReplacements(string inputFilePath, string outputFilePath, string oldWord, string newWord)
    {
        try
        {
            // Читаем содержимое входного файла
            string content = File.ReadAllText(inputFilePath);

            // Заменяем старое слово на новое
            string updatedContent = content.Replace(oldWord, newWord);

            // Сохраняем обновленное содержимое в выходной файл
            File.WriteAllText(outputFilePath, updatedContent);
            Console.WriteLine($"Файл успешно скопирован с заменой '{oldWord}' на '{newWord}' в: {outputFilePath}");
        }
        catch (Exception ex)
        {
            // Обработка всех возможных ошибок
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к входному файлу:");
        string inputFilePath = Console.ReadLine();

        Console.WriteLine("Введите путь к выходному файлу:");
        string outputFilePath = Console.ReadLine();

        Console.WriteLine("Введите слово для замены:");
        string oldWord = Console.ReadLine();

        Console.WriteLine("Введите новое слово:");
        string newWord = Console.ReadLine();

        CopyFileWithReplacements(inputFilePath, outputFilePath, oldWord, newWord);
    }
}