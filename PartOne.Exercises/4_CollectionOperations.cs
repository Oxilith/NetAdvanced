namespace PartOne.Exercises;


/// <summary>
/// Wyjaśnij różnicę między IList, IEnumerable i IQueryable.
/// Kiedy filtrowanie jest faktycznie wykonywane (deferred vs immediate execution).
/// Jak wykonywane są operacje filtrowania.
/// Jakie są implikacje wydajnościowe.
/// </summary>
public static class CollectionOperations
{
    public static void ProcessWithIList(IList<int> collection)
    {
        var filtered = collection.Where(x => x > 5).ToList();
        Console.WriteLine("IList Result:");
        foreach (var item in filtered)
        {
            Console.WriteLine(item);
        }
    }

    public static void ProcessWithIEnumerable(IEnumerable<int> collection)
    {
        var filtered = collection.Where(x => x > 5);
        Console.WriteLine("IEnumerable Result:");
        foreach (var item in filtered)
        {
            Console.WriteLine(item);
        }
    }

    public static void ProcessWithIQueryable(IQueryable<int> collection)
    {
        var filtered = collection.Where(x => x > 5);
        Console.WriteLine("IQueryable Result:");
        foreach (var item in filtered)
        {
            Console.WriteLine(item);
        }
    }

    public static void Usage()
    {
        var collection = new List<int> { 1, 2, 3, 6, 7, 8, 9 };
        var enumerable = collection.AsEnumerable();
        var queryable = collection.AsQueryable();
        ProcessWithIList(collection);
        ProcessWithIEnumerable(enumerable);
        ProcessWithIQueryable(queryable);
    }
}