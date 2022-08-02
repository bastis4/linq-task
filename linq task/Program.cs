
using System.Linq;
using static LinqPractice;
///Реализовать методы ForEachEven (для каждого четного), ForEachOdd (для каждого нечетного) и PrintToConsole
public static class LinqPractice
{
    public delegate void DisplayMessage<T>(List<T> numbers);

    public static void Main()
    {
        var arr1 = new int[] { 1, 2, 3, 4 };
        var arr2 = new string[] { "one", "two", "three", "four" };

        DisplayMessage<int> printNumberDigits;
        printNumberDigits = PrintToConsole;

        DisplayMessage<string> printNumberWords;
        printNumberWords = PrintToConsole;

        arr1.ForEachEven(PrintToConsole); // Должно вывести на консоль 2, 4
        arr2.ForEachOdd(PrintToConsole); // Должно вывести на консоль one, three
    }
    public static void PrintToConsole<T>(this List<T> numbers)
    {
        numbers.ForEach(x => Console.WriteLine(x));
    }
    public static void ForEachEven(this int[] numbers, DisplayMessage<int> printNumberDigits)
    {
        var evenNumberDigits = numbers.Where(x => x % 2 == 0).ToList();
        printNumberDigits(evenNumberDigits);
    }
    public static void ForEachOdd(this string[] numbers, DisplayMessage<string> printNumberWords)
    {
        /*var evenNumberWords = numbers
            .Select((v, i) => new { Index = i, Value = v })
            .Where(p => (p.Index + 1) % 2 != 
        0)
            .Select(p => p.Value).ToList();*/
        
        var evenNumberWords = Enumerable.Range(0, numbers.Length)
                 .Where(i => (i + 1) % 2 != 0)
                 .Select(i => numbers[i])
                 .ToList();
        printNumberWords(evenNumberWords);
    }
}
