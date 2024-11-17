namespace PartOne.Exercises;
    
// 1. Czym różni się użycie metod w stylu obiektowym od stylu funkcyjnego?
// 2. Dlaczego w metodach obiektowych używamy `.ToList()` po każdej operacji LINQ?
// 3. Jakie są zalety i wady utrzymywania stanu w obiekcie w kontekście wielowątkowości?
// 4. W jaki sposób można przetestować metody obiektowe a w jaki sposób funkcyjne?
// 5. Co oznacza deferred execution w kontekście metod LINQ, takich jak `.Where()`?
// 6. Jaką korzyść przynosi użycie `SumNumbers()` po zastosowaniu `MultiplyByTwo()`?
public class NumberFilter(List<int> numbers)
{
    public List<int> GetNumbersGreaterThanFive()
    {
        return numbers.Where(n => n > 5).ToList();
    }

    public List<int> GetEvenNumbers()
    {
        return numbers.Where(n => n % 2 == 0).ToList();
    }

    public List<int> MultiplyByTwo()
    {
        return numbers.Select(n => n * 2).ToList();
    }

    public int SumNumbers()
    {
        return numbers.Sum();
    }

    public List<int> SortDescending()
    {
        return numbers.OrderByDescending(n => n).ToList();
    }

    public void Usage()
    {
        var numbers = new List<int> { 1, 2, 3, 6, 7, 8, 9 };
        var numberFilter = new NumberFilter(numbers);

        var greaterThanFive = numberFilter.GetNumbersGreaterThanFive();
        var evenNumbers = numberFilter.GetEvenNumbers();
        var multipliedByTwo = numberFilter.MultiplyByTwo();
        var sortedDescending = numberFilter.SortDescending();
    }
}

public static class FunctionalNumberFilter
{
    public static IEnumerable<int> FilterGreaterThanFive(this IEnumerable<int> numbers)
    {
        return numbers.Where(n => n > 5);
    }

    public static IEnumerable<int> GetEvenNumbers(this IEnumerable<int> numbers)
    {
        return numbers.Where(n => n % 2 == 0);
    }

    public static IEnumerable<int> MultiplyByTwo(this IEnumerable<int> numbers)
    {
        return numbers.Select(n => n * 2);
    }

    public static int SumNumbers(this IEnumerable<int> numbers)
    {
        return numbers.Sum();
    }

    public static IEnumerable<int> SortDescending(IEnumerable<int> numbers)
    {
        return numbers.OrderByDescending(n => n);
    }

    public static void Usage()
    {
        var numbers = new List<int> { 1, 2, 3, 6, 7, 8, 9 };
        var greaterThanFive = FunctionalNumberFilter.FilterGreaterThanFive(numbers).ToList();
        var evenNumbers = numbers.GetEvenNumbers().ToList();
        var multipliedByTwo = numbers.MultiplyByTwo().ToList();
        var sortedDescending = FunctionalNumberFilter.SortDescending(numbers).ToList();

        var sumMultipliedValues = numbers.MultiplyByTwo().SumNumbers();

        Console.WriteLine("Numbers greater than five: " + string.Join(", ", greaterThanFive));
        Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));
        Console.WriteLine("Numbers multiplied by two: " + string.Join(", ", multipliedByTwo));
        Console.WriteLine("Sum of numbers: " + sumMultipliedValues);
        Console.WriteLine("Numbers sorted descending: " + string.Join(", ", sortedDescending));
    }
}