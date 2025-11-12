using System.Collections.Concurrent;

namespace ParallelReadFiles
{
    internal static class ReadFilesHelper
    {
        const string searchPattern = "*.txt";

        /// <summary>
        /// Получить количество пробелов в файле
        /// </summary>
        /// <param name="directoryPath">Путь до папки с файлами</param>
        /// <returns>Список путей к файлам и количество пробелов в них</returns>
        internal async static Task<ConcurrentDictionary<string, int>> GetWhiteSpacesInFilesFromDirectoryAsync(string directoryPath, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(directoryPath);

            if (!Directory.Exists(directoryPath)) {
                Console.WriteLine("Папка не существует.");
                throw new DirectoryNotFoundException(directoryPath);
            }

            var result = new ConcurrentDictionary<string, int>();

            var files = Directory.GetFiles(directoryPath, searchPattern);

            if (files.Length > 0)
            {
                Console.WriteLine($"В папке найдено {files.Length} файлов.");

                var tasks = new List<Task<KeyValuePair<string, int>>>();

                foreach (var file in files)
                {
                    tasks.Add(ReadWhiteSpacesFromFileAsync(file, cancellationToken));
                }

                while (tasks.Count > 0 || cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var completedTask = await Task.WhenAny(tasks);

                        if (!completedTask.IsFaulted && result.TryAdd(completedTask.Result.Key, completedTask.Result.Value))
                        {
                            Console.WriteLine($"Получены результаты подсчёта пробелов в файле {completedTask.Result.Key}. Количество: {completedTask.Result.Value}");
                        }
                        else
                        {
                            Console.WriteLine($"Результаты подсчёта пробелов в файле {completedTask.Result.Key} не получены");
                        }

                        tasks.Remove(completedTask);
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                }

                return result;
            }
            else
            {
                Console.WriteLine("Файлы по заданному пути не найдены.");
                return result;
            }
        }

        internal async static Task<KeyValuePair<string, int>> ReadWhiteSpacesFromFileAsync(string filePath, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var spaceCount = 0;
                using (var reader = new StreamReader(filePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        spaceCount += line.Count(c => c == ' ');
                    }
                }
                return new KeyValuePair<string, int> (filePath, spaceCount);
            }, cancellationToken);
        }
    }
}
