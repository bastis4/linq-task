using linq_task;
///Реализовать методы ForEachEven (для каждого четного), ForEachOdd (для каждого нечетного) и PrintToConsole
public class LinqPractice
{
    public static void Main()
    {
        var arr1 = new List<int> { 1, 2, 3, 4 };
        var arr2 = new string[] { "one", "two", "three", "four" };

        arr1.ForEachEven(PrintToConsole); // Должно вывести на консоль 2, 4
        arr2.ForEachOdd(PrintToConsole); // Должно вывести на консоль one, three
    }

    public static void PrintToConsole<T>(T x)
    {
        Console.WriteLine(x);
    }
}
