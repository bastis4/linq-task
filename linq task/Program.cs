
using System.Linq;
using static LinqPractice;
///Реализовать методы ForEachEven (для каждого четного), ForEachOdd (для каждого нечетного) и PrintToConsole
public static class LinqPractice
{
    public delegate void DisplayMessage<T>(List<T> numbers);

    private static Dictionary<string, int> wordsToNumbers = new Dictionary<string, int>
        {{"zero",0},{"one",1},{"two",2},{"three",3},{"four",4},
        {"five",5},{"six",6},{"seven",7},{"eight",8},{"nine",9},
        {"ten",10},{"eleven",11},{"twelve",12},{"thirteen",13},
        {"fourteen",14},{"fifteen",15},{"sixteen",16},
        {"seventeen",17},{"eighteen",18},{"nineteen",19},{"twenty",20}};

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
        var evenNumberDigits = (from x in numbers where x % 2 == 0 select x).ToList();
        printNumberDigits(evenNumberDigits);

    }

    public static void ForEachOdd(this string[] numbers, DisplayMessage<string> printNumberWords)
    {
        var evenNumberWords = wordsToNumbers
            .Where(x => numbers.Contains(x.Key) && x.Value % 2 != 0)
            .ToDictionary(t => t.Value, t => t.Key).Values
            .ToList();
        
        /*var evenNumberWords = (((from x in wordsToNumbers
                                 join y in numbers on x.Key equals y
                                 select (y, x.Value)).Where(x => x.Value % 2 != 0)).ToDictionary(y => y.Value, x => x.y)).Values.ToList();*/
        
        printNumberWords(evenNumberWords);
    }
}
