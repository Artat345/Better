using System;
using System.IO;
using System.IO.Compression;

public class FileCompressor
{
    public static void CompressFile(string inputFilePath, string outputFilePath)
    {
        try
        {
            // Открываем входной файл для чтения
            using (FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                // Создаем выходной файл для записи сжатых данных
                using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                {
                    // Создаем GZipStream для сжатия данных
                    using (GZipStream compressionStream = new GZipStream(outputFileStream, CompressionMode.Compress))
                    {
                        // Копируем данные из входного файла в GZipStream
                        inputFileStream.CopyTo(compressionStream);
                    }
                }
            }
            Console.WriteLine($"Файл успешно сжат и сохранен как: {outputFilePath}");
        }
        catch (Exception ex)
        {
            // Обработка ошибок
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к входному файлу:");
        string inputFilePath = Console.ReadLine();

        Console.WriteLine("Введите путь к выходному файлу (сжатый):");
        string outputFilePath = Console.ReadLine();

        CompressFile(inputFilePath, outputFilePath);
    }
}