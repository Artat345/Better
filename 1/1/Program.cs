using System;
using System.IO;

public class FileChecker
{
    public static bool DoesFileExist(string path)
    {
        try
        {
            // Проверяем, существует ли файл
            return File.Exists(path);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Путь не может быть null.");
            return false;
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Путь слишком длинный.");
            return false;
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Директория не найдена.");
            return false;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
            return false;
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к файлу:");
        string filePath = Console.ReadLine();

        bool exists = DoesFileExist(filePath);
        if (exists)
        {
            Console.WriteLine("Файл существует.");
        }
        else
        {
            Console.WriteLine("Файл не существует.");
        }
    }
}