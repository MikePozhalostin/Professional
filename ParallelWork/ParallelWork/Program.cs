// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

const int FirstSize = 100000;
const int SecondSize = 1000000;
const int ThirdSize = 10000000;

// 100000
Console.WriteLine($"Cores: {Environment.ProcessorCount}, OS: {Environment.OSVersion}");
var sw = new Stopwatch();

Console.WriteLine($"Size: {FirstSize}");
sw.Start();
var sum = CalculateSequential(0, FirstSize);
sw.Stop();
Console.WriteLine($"Sequential Sum: {sum}, time: {sw.ElapsedMilliseconds}ms");

sw.Start();
sum = CalculateSumWithThreads(0, FirstSize);
sw.Stop();
Console.WriteLine($"Threads Sum: {sum}, time: {sw.ElapsedMilliseconds}ms");

sw.Start();
sum = CalculateSumPLINQ(0, FirstSize);
sw.Stop();
Console.WriteLine($"PLINQ Sum: {sum}, time: {sw.ElapsedMilliseconds}ms\n");

// 1000000
Console.WriteLine($"Size: {SecondSize}");
sw.Start();
sum = CalculateSequential(0, SecondSize);
sw.Stop();
Console.WriteLine($"Sequential Sum: {sum}, time: {sw.ElapsedMilliseconds}ms");

sw.Start();
sum = CalculateSumWithThreads(0, SecondSize);
sw.Stop();
Console.WriteLine($"Threads Sum: {sum}, time: {sw.ElapsedMilliseconds}ms");

sw.Start();
sum = CalculateSumPLINQ(0, SecondSize);
sw.Stop();
Console.WriteLine($"PLINQ Sum: {sum}, time: {sw.ElapsedMilliseconds}ms\n");

// 10000000
Console.WriteLine($"Size: {ThirdSize}");
sw.Start();
sum = CalculateSequential(0, ThirdSize);
sw.Stop();
Console.WriteLine($"Sequential Sum: {sum}, time: {sw.ElapsedMilliseconds}ms");

sw.Start();
sum = CalculateSumWithThreads(0, ThirdSize);
sw.Stop();
Console.WriteLine($"Threads Sum: {sum}, time: {sw.ElapsedMilliseconds}ms");

sw.Start();
sum = CalculateSumPLINQ(0, ThirdSize);
sw.Stop();
Console.WriteLine($"PLINQ Sum: {sum}, time: {sw.ElapsedMilliseconds}ms");


static long CalculateSequential(int n, int m)
{
    long sum = 0;
    for (var num = n; num <= m; num++)
    {
        sum += num;
    }
    return sum;
}

static long CalculateSumWithThreads(int n, int m)
{
    //Разделим диапазон[N, M] на K непересекающихся поддиапазонов(K = количество логических ядер CPU).
    int cores = Environment.ProcessorCount;
    long chunkSize = (m - n + 1L) / cores;
    var threads = new List<Thread>(cores);
    long total = 0;
    object lockObj = new();

    //Для каждого поддиапазона создадим отдельный поток, который вычислит сумму чисел в своей части.
    for (int i = 0; i < cores; i++)
    {
        int start = (int)(n + i * chunkSize);
        int end = (i == cores - 1) ? m : (int)(start + chunkSize - 1);

        Thread t = new(() =>
        {
            long localSum = 0;
            for (int num = start; num <= end; num++)
                   localSum += num;

            lock (lockObj) { total += localSum; }
        });

        threads.Add(t);
        t.Start();
    }

    //Синхронизируем потоки и объединим результаты.
    foreach (Thread t in threads) t.Join();
    return total;
}

static long CalculateSumPLINQ(int n, int m)
{
    return Enumerable.Range(n, m - n + 1)
        .AsParallel()
        .WithDegreeOfParallelism(Environment.ProcessorCount)
        .Sum(x => (long)x);
}