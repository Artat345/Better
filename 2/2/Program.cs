using System;
using System.IO;

public class FileWriter
{
    public static void WriteToFile(string filePath, string content)
    {
        try
        {
            // Записываем содержимое в файл
            File.WriteAllText(filePath, content);
            Console.WriteLine("Данные успешно записаны в файл.");
        }
        catch (ArgumentNullException)
        {
            // Обработка случая, когда путь или содержимое равны null
            Console.WriteLine("Путь или содержимое не могут быть null.");
        }
        catch (PathTooLongException)
        {
            // Обработка случая, когда путь слишком длинный
            Console.WriteLine("Путь к файлу слишком длинный.");
        }
        catch (DirectoryNotFoundException)
        {
            // Обработка случая, когда директория не найдена
            Console.WriteLine("Директория, в которой должен быть создан файл, не найдена.");
        }
        catch (IOException ex)
        {
            // Обработка других ошибок ввода-вывода
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Обработка любых других исключений
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к файлу:");
        string filePath = Console.ReadLine();

        Console.WriteLine("Введите текст для записи в файл:");
        string content = Console.ReadLine();

        WriteToFile(filePath, content);
    }
}