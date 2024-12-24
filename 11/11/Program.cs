using System;
using System.IO;

public class FileSplitter
{
    public static void SplitFile(string inputFilePath, long splitSize)
    {
        try
        {
            // Проверяем, существует ли файл
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"Файл не найден: {inputFilePath}");
                return;
            }

            // Получаем размер исходного файла
            long fileSize = new FileInfo(inputFilePath).Length;

            // Проверяем, достаточно ли размера для разбивки
            if (fileSize <= splitSize)
            {
                Console.WriteLine("Размер файла меньше или равен указанному размеру. Разбиение не требуется.");
                return;
            }

            // Открываем исходный файл для чтения
            using (FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                // Создаем первый выходной файл
                using (FileStream outputFileStream1 = new FileStream(inputFilePath + ".part1", FileMode.Create, FileAccess.Write))
                {
                    // Копируем данные в первый файл
                    byte[] buffer = new byte[4096];
                    long bytesRead = 0;

                    while (bytesRead < splitSize)
                    {
                        int read = inputFileStream.Read(buffer, 0, buffer.Length);
                        if (read == 0) break; // Достигнут конец файла
                        outputFileStream1.Write(buffer, 0, read);
                        bytesRead += read;
                    }
                }

                // Создаем второй выходной файл
                using (FileStream outputFileStream2 = new FileStream(inputFilePath + ".part2", FileMode.Create, FileAccess.Write))
                {
                    // Копируем оставшиеся данные во второй файл
                    inputFileStream.CopyTo(outputFileStream2);
                }
            }

            Console.WriteLine($"Файл успешно разбит на: {inputFilePath}.part1 и {inputFilePath}.part2");
        }
        catch (Exception ex)
        {
            // Обработка ошибок
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к исходному файлу:");
        string inputFilePath = Console.ReadLine();

        Console.WriteLine("Введите размер для разбивки (в байтах):");
        if (long.TryParse(Console.ReadLine(), out long splitSize))
        {
            SplitFile(inputFilePath, splitSize);
        }
        else
        {
            Console.WriteLine("Некорректный размер.");
        }
    }
}