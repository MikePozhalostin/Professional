using ParallelReadFiles;
using System.Diagnostics;

var projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\files\"));

var sw = new Stopwatch();

sw.Start();
Console.WriteLine($"Start read files from directory {projectDirectory}");

try
{
    await ReadFilesHelper.GetWhiteSpacesInFilesFromDirectoryAsync(projectDirectory, CancellationToken.None);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    sw.Stop();
    Console.WriteLine($"Result read files in directory: {sw.ElapsedMilliseconds} ms");
}


sw.Start();
Console.WriteLine($"Start read files");

try
{
    var taskOne = ReadFilesHelper.ReadWhiteSpacesFromFileAsync(projectDirectory + @"\fileOne.txt", CancellationToken.None);
    var taskTwo = ReadFilesHelper.ReadWhiteSpacesFromFileAsync(projectDirectory + @"\fileTwo.txt", CancellationToken.None);
    var taskThree = ReadFilesHelper.ReadWhiteSpacesFromFileAsync(projectDirectory + @"\fileThree.txt", CancellationToken.None);

    await Task.WhenAll(taskOne, taskTwo, taskThree);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    sw.Stop();
    Console.WriteLine($"Result read files: {sw.ElapsedMilliseconds} ms");
}
