using System;
using System.Text.RegularExpressions;

public class PhoneNumberValidator
{
    // Регулярное выражение для проверки валидного телефонного номера
    private static readonly string PhoneNumberPattern = @"^(\+?\d{1,3}[- ]?)?\(?\d{1,4}?\)?[- ]?\d{1,4}[- ]?\d{1,4}[- ]?\d{1,9}$";

    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            return false; // Пустая строка не является валидным номером
        }

        // Проверяем соответствие строки регулярному выражению
        return Regex.IsMatch(phoneNumber, PhoneNumberPattern);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите номер телефона для проверки:");
        string input = Console.ReadLine();

        if (IsValidPhoneNumber(input))
        {
            Console.WriteLine("Номер телефона валиден.");
        }
        else
        {
            Console.WriteLine("Номер телефона не валиден.");
        }
    }
}