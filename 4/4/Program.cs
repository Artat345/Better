using System;
using System.IO;

public class WordCounter
{
    public static int CountWordsInFile(string filePath)
    {
        try
        {
            // Читаем содержимое файла
            string content = File.ReadAllText(filePath);
            // Разделяем текст на слова и считаем их количество
            string[] words = content.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден. Пожалуйста, проверьте путь к файлу.");
            return 0;
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Ошибка доступа: у вас нет прав на чтение этого файла.");
            return 0;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
            return 0;
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к текстовому файлу:");
        string filePath = Console.ReadLine();

        int wordCount = CountWordsInFile(filePath);
        if (wordCount > 0)
        {
            Console.WriteLine($"Количество слов в файле: {wordCount}");
        }
    }
}