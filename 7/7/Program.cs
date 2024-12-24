using System;
using System.IO;

public class FileEncryptor
{
    public static void EncryptFile(string inputFilePath, string outputFilePath)
    {
        try
        {
            // Читаем содержимое входного файла
            string content = File.ReadAllText(inputFilePath);
            string encryptedContent = Encrypt(content);

            // Сохраняем зашифрованное содержимое в выходной файл
            File.WriteAllText(outputFilePath, encryptedContent);
            Console.WriteLine($"Файл успешно зашифрован и сохранен как: {outputFilePath}");
        }
        catch (IOException ex)
        {
            // Обработка ошибок ввода-вывода
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
    }

    private static string Encrypt(string text)
    {
        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];
            // Шифруем только буквы
            if (char.IsLetter(letter))
            {
                // Заменяем букву на следующую в алфавите
                letter = (char)(letter + 1);
                // Если буква 'Z' или 'z', возвращаем к 'A' или 'a'
                if (letter == 'Z' + 1) letter = 'A';
                if (letter == 'z' + 1) letter = 'a';
            }
            buffer[i] = letter;
        }
        return new string(buffer);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к входному файлу:");
        string inputFilePath = Console.ReadLine();

        Console.WriteLine("Введите путь к выходному файлу:");
        string outputFilePath = Console.ReadLine();

        EncryptFile(inputFilePath, outputFilePath);
    }
}