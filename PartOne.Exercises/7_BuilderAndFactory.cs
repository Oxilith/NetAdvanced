using System;

namespace PartOne.Exercises;

public class VehicleBuilder
{
    private string _engine;
    private string _wheels;
    private string _frame;

    public VehicleBuilder SetEngine(string engine)
    {
        _engine = engine;
        return this;
    }

    public VehicleBuilder SetWheels(string wheels)
    {
        _wheels = wheels;
        return this;
    }

    public VehicleBuilder SetFrame(string frame)
    {
        _frame = frame;
        return this;
    }

    public Vehicle Build()
    {
        return new Vehicle(_engine, _wheels, _frame);
    }
}

public class Vehicle
{
    public string Engine { get; }
    public string Wheels { get; }
    public string Frame { get; }

    public Vehicle(string engine, string wheels, string frame)
    {
        Engine = engine;
        Wheels = wheels;
        Frame = frame;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Vehicle with Engine: {Engine}, Wheels: {Wheels}, Frame: {Frame}");
    }
}

public interface IVehicleFactory
{
    IVehicle CreateCar();
    IVehicle CreateMotorcycle();
}

public interface IVehicle
{
    void DisplayInfo();
}

public class Car : IVehicle
{
    public void DisplayInfo()
    {
        Console.WriteLine("Car: A four-wheeled vehicle.");
    }
}

public class Motorcycle : IVehicle
{
    public void DisplayInfo()
    {
        Console.WriteLine("Motorcycle: A two-wheeled vehicle.");
    }
}

public class ModernVehicleFactory : IVehicleFactory
{
    public IVehicle CreateCar()
    {
        return new Car();
    }

    public IVehicle CreateMotorcycle()
    {
        return new Motorcycle();
    }
}

/// <summary>
/// Napisz klase wykorzystującą wzorzec budowniczego oraz fabryki abstrakcyjnej:
/// Wzorzec Budowniczy: Wykorzystano `VehicleBuilder` do budowy obiektów `Vehicle` o złożonej strukturze. Uczestnik może spróbować rozszerzyć klasę `VehicleBuilder` o dodatkowe cechy, takie jak `Color`, `Transmission` itp.
/// Wzorzec Fabryka Abstrakcyjna: Stworzono `IVehicleFactory` do tworzenia rodzin powiązanych obiektów - `Car` oraz `Motorcycle`. Zadaniem uczestnika jest utworzenie nowej fabryki, np. `ClassicVehicleFactory`, która tworzy pojazdy o klasycznym stylu
/// </summary>
public class ClassicVehicleFactory{}

public class BuilderAndFactory
{
    /// <summary>
    /// 1. Jakie są różnice między wzorcem Budowniczy a wzorcem Fabryka Abstrakcyjna? Kiedy warto użyć jednego wzorca zamiast drugiego?
    /// 2. Jakie korzyści daje zastosowanie wzorca Budowniczy? Jak można rozwinąć ten wzorzec, aby lepiej wspierał rozszerzalność, np. dodanie nowych cech do pojazdu?
    /// 3. Jakie są zalety stosowania wzorca Fabryka Abstrakcyjna w porównaniu do tworzenia obiektów bezpośrednio za pomocą operatora `new`? Jak ten wzorzec pomaga w utrzymaniu kodu?
    /// 4. Jakie inne rodzaje fabryk można by zaimplementować, aby rozszerzyć funkcjonalność tej aplikacji? Jak wzorzec Fabryka Abstrakcyjna wspiera możliwość dodawania nowych typów pojazdów?
    /// 5. Czy klasa `VehicleBuilder` powinna mieć walidację dla parametrów (np. `engine`)? Jakie mogą być konsekwencje jej braku w przypadku tworzenia bardziej złożonych obiektów?
    /// 6. Czy klasa `Vehicle` jest odpowiednio zamknięta na modyfikacje, ale otwarta na rozszerzenia (zgodnie z zasadą Open/Closed)? Jakie zmiany można wprowadzić, aby lepiej wspierać tę zasadę?
    /// 7. Jakie są zalety stosowania interfejsów w kontekście wzorca Fabryka Abstrakcyjna? Jakie są inne korzyści związane z użyciem interfejsów w C#?
    /// </summary>
    public static void Main()
    {
        // Użycie wzorca Budowniczy
        var builder = new VehicleBuilder();
        var vehicle = builder.SetEngine("V8").SetWheels("Alloy Wheels").SetFrame("SUV Frame").Build();
        vehicle.ShowDetails();

        // Użycie wzorca Fabryka Abstrakcyjna
        IVehicleFactory factory = new ModernVehicleFactory();
        var car = factory.CreateCar();
        var motorcycle = factory.CreateMotorcycle();

        Console.WriteLine("\nFactory Products:");
        car.DisplayInfo();
        motorcycle.DisplayInfo();
    }
}
