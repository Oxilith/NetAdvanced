namespace PartOne.Exercises;

/// <summary>
/// Klasa pomocnicza
/// </summary>
/// <param name="raceName"></param>
/// <param name="age"></param>
public class Animal(string raceName, int age)
{
    public string RaceName { get; } = raceName;
    public int Age { get; } = age;
}

/// <summary>
/// Klasa statyczna do operaji na kolekcjach
/// Implementacja metod anonimowych do operacji na kolekcjach, takich jak filtrowanie lub agregacja danych.
/// </summary>
public static class Statics
{
    public static IEnumerable<Animal> Dogs =
    [
        new Animal("Bulldog", 7),
        new Animal("Poodle", 2),
        new Animal("Bulldog", 1),
        new Animal("Poodle", 9),
        new Animal("Bulldog", 3),
        new Animal("Poodle", 4),
        new Animal("Bulldog", 5),
        new Animal("Poodle", 2),
        new Animal("Bulldog", 1),
        new Animal("Poodle", 7)
    ];

    public static IEnumerable<Animal> Cats =
    [
        new Animal("Siamese", 15),
        new Animal("Persian", 5),
        new Animal("Siamese", 12),
        new Animal("Persian", 7),
        new Animal("Siamese", 9),
        new Animal("Persian", 1),
        new Animal("Siamese", 6),
        new Animal("Persian", 4),
        new Animal("Siamese", 8),
        new Animal("Persian", 11),
    ];

    public static IEnumerable<Animal> Animals = Dogs.Concat(Cats);

    /// <summary>
    /// Metoda anonimowa do filtrowania danych.
    /// Filtruje dane by dostać tylko koty rasy Siamese.
    /// </summary>
    /// <param name="data">Dane wejściowe</param>
    /// <returns>IEnumerable of Animals</returns>
    public static IEnumerable<Animal> Filter(IEnumerable<Animal> data)
    {
        return [];
    }

    /// <summary>
    /// Metoda anonimowa do agregacji danych.
    /// Agreguje wszystkie zwierzeta aby dostac średni wiek dla kazdej rasy zwierząt.
    /// </summary>
    /// <param name="data">Dane wejściowe.</param>
    /// <returns>IList of Animals</returns>
    public static IList<Animal> Aggregate(IEnumerable<Animal> data)
    {
        return [];
    }

    /// <summary>
    /// Metoda rozszerzająca
    /// Filtruje zwierzeta by dostac psy Bullldogi i koty Persians i aggreguje by dostac pierwiastek sumy lat.
    /// </summary>
    /// <param name="data">Dane wejściowe.</param>
    /// <returns>IDictionary<string, double></returns>
    public static IDictionary<string, double> BulldogsAndPersians(IEnumerable<Animal> data)
    {
        return new Dictionary<string, double>();
    }
}