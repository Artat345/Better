using System;
using System.Text.RegularExpressions;

public class DateValidator
{
    // Регулярное выражение для проверки валидной даты в формате "dd.MM.yyyy"
    private static readonly string DatePattern = @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}$";

    public static bool IsValidDate(string dateString)
    {
        if (string.IsNullOrWhiteSpace(dateString))
        {
            return false; // Пустая строка не является валидной датой
        }

        // Проверяем соответствие строки регулярному выражению
        if (Regex.IsMatch(dateString, DatePattern))
        {
            try
            {
                // Пытаемся преобразовать строку в объект DateTime
                DateTime date = DateTime.ParseExact(dateString, "dd.MM.yyyy", null);
                return true;
            }
            catch (FormatException)
            {
                // Если преобразование не удалось, значит дата некорректна
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите дату для проверки (в формате dd.MM.yyyy):");
        string input = Console.ReadLine();

        if (IsValidDate(input))
        {
            Console.WriteLine("Дата валидна.");
        }
        else
        {
            Console.WriteLine("Дата не валидна.");
        }
    }
}