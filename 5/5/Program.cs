using System;
using System.IO;

public class BackupCreator
{
    public static void CreateBackup(string filePath)
    {
        try
        {
            // Проверяем, существует ли файл
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден. Резервная копия не может быть создана.");
                return;
            }

            // Получаем имя файла и его расширение
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string fileExtension = Path.GetExtension(filePath);
            string directory = Path.GetDirectoryName(filePath);

            // Формируем новое имя файла с текущей датой и временем
            string backupFileName = $"{fileName}_{DateTime.Now:yyyyMMdd_HHmmss}{fileExtension}";
            string backupFilePath = Path.Combine(directory, backupFileName);

            // Копируем файл
            File.Copy(filePath, backupFilePath);
            Console.WriteLine($"Резервная копия создана: {backupFilePath}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к файлу для резервного копирования:");
        string filePath = Console.ReadLine();

        CreateBackup(filePath);
    }
}