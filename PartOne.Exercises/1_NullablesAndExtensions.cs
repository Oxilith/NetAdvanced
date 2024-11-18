namespace PartOne.Exercises;

/// <summary>
/// Swtwórz klasę Nullables która pokazuje różnice w użyciu wartości Nullable oraz parametrów opcjonalnych.
/// </summary>
public class Nullables
{
    /// <summary>
    /// Metoda, która wykorzystuje operator ?? do obsługi wartości domyślnych.
    /// </summary>
    public void MethodWithCoalescingOperator()
    {
    }

    /// <summary>
    /// Metoda, która wykorzystuje  modyfikator ? do pracy z typami referencyjnymi.
    /// </summary>
    public void MethodWithQuestionMark()
    {
    }

    /// <summary>
    /// Metoda która używa modyfikator ! do pracy z typami referencyjnymi.
    /// </summary>
    public void MethodWithExclamationMark()
    {
    }

    /// <summary>
    /// Metoda, która rzuca wyjątek, jeśli wartość jest nullem.
    /// </summary>
    public void MethodWithException()
    {
    }

    /// <summary>
    /// Metoda która zwraca wartość domyślną dla typu referencyjnego i wartościowego.
    /// </summary>
    public void MethodWithDefaultValue()
    {
    }
    
    /// <summary>
    /// Metoda, która przyjmuje wartość opcjonalną typu wartościowego (int) i refValue i message typu referencyjnego(string).
    /// Sprawda czy wartosc message jest nullem i rzuca wyjątek jesli tak, jesli nie to wysyła ją na konsole.
    /// Sprawda czy wartosc value jest nullem i używa wartości domyślnej jeśli tak.
    /// Sprawda czy wartosc refValue jest nullem i używa wartości domyślnej dla typu Int jeśli tak.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="refValue"></param>
    /// <param name="message"></param>
    /// <returns>Sumę value i refValue</returns>
    public int Sum(int? value, string? refValue, string? message)
    {
        return 0;
    }
}

//Napisz klassę Extensions, która zawiera metody rozszerzające dla typów int, string, List<int> oraz Dictionary<string, int>