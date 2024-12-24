using System;
using System.IO;

public class FileChangeWatcher
{
    private string _filePath;
    private string _backupDirectory;

    public FileChangeWatcher(string filePath, string backupDirectory)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("Путь к файлу не может быть пустым.", nameof(filePath));

        if (string.IsNullOrWhiteSpace(backupDirectory))
            throw new ArgumentException("Путь к каталогу резервных копий не может быть пустым.", nameof(backupDirectory));

        _filePath = filePath;
        _backupDirectory = backupDirectory;

        // Создаем каталог для резервных копий, если он не существует
        Directory.CreateDirectory(_backupDirectory);
    }

    public void StartWatching()
    {
        using (FileSystemWatcher watcher = new FileSystemWatcher())
        {
            watcher.Path = Path.GetDirectoryName(_filePath);
            watcher.Filter = Path.GetFileName(_filePath);
            watcher.NotifyFilter = NotifyFilters.LastWrite;

            // Подписываемся на событие изменения файла
            watcher.Changed += OnChanged;

            // Начинаем мониторинг
            watcher.EnableRaisingEvents = true;

            Console.WriteLine($"Начато отслеживание изменений в файле: {_filePath}");
            Console.WriteLine("Нажмите 'q' для выхода.");

            // Ожидаем ввода пользователя для завершения работы
            while (Console.Read() != 'q') ;
        }
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        try
        {
            // Ждем, чтобы убедиться, что файл не занят
            System.Threading.Thread.Sleep(1000);

            // Создаем имя резервной копии
            string backupFileName = Path.Combine(_backupDirectory, $"{Path.GetFileNameWithoutExtension(_filePath)}_backup_{DateTime.Now:yyyyMMdd_HHmmss}{Path.GetExtension(_filePath)}");

            // Копируем файл
            File.Copy(_filePath, backupFileName, true);
            Console.WriteLine($"Создана резервная копия: {backupFileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании резервной копии: {ex.Message}");
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к файлу для отслеживания:");
        string filePath = Console.ReadLine();

        Console.WriteLine("Введите путь к каталогу для сохранения резервных копий:");
        string backupDirectory = Console.ReadLine();

        try
        {
            FileChangeWatcher watcher = new FileChangeWatcher(filePath, backupDirectory);
            watcher.StartWatching();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}