using ParallelReadFiles;
using System.Diagnostics;

var projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\files\"));

var sw = new Stopwatch();

sw.Start();
Console.WriteLine($"Start read files from {projectDirectory}");

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
    Console.WriteLine($"Result: {sw.ElapsedMilliseconds} ms");
}
