namespace PartOne.Exercises;

#region Adapter

public interface ITarget
{
    void Request();
}

public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Specific request called from Adaptee.");
    }
}

public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void Request()
    {
        _adaptee.SpecificRequest();
    }
}

#endregion

#region Decorator

public interface IComponent
{
    void Operation();
}

public class ConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("Concrete Component Operation.");
    }
}

public class Decorator : IComponent
{
    private readonly IComponent _component;

    public Decorator(IComponent component)
    {
        _component = component;
    }

    public void Operation()
    {
        _component.Operation();
        Console.WriteLine("Additional functionality added by Decorator.");
    }
}
#endregion

#region Facade

public class ComplexSubsystemA
{
    public void OperationA()
    {
        Console.WriteLine("Operation A from ComplexSubsystemA.");
    }
}

public class ComplexSubsystemB
{
    public void OperationB()
    {
        Console.WriteLine("Operation B from ComplexSubsystemB.");
    }
}

public class ComplexSubsystemC
{
    public void OperationC()
    {
        Console.WriteLine("Operation C from ComplexSubsystemC.");
    }
}

public class Facade
{
    private readonly ComplexSubsystemA _subsystemA;
    private readonly ComplexSubsystemB _subsystemB;
    private readonly ComplexSubsystemC _subsystemC;

    public Facade(ComplexSubsystemA subsystemA, ComplexSubsystemB subsystemB, ComplexSubsystemC subsystemC)
    {
        _subsystemA = subsystemA;
        _subsystemB = subsystemB;
        _subsystemC = subsystemC;
    }

    public void SimplifiedOperation()
    {
        Console.WriteLine("Simplified Operation using Facade:");
        _subsystemA.OperationA();
        _subsystemB.OperationB();
        _subsystemC.OperationC();
    }
}

#endregion

/// <summary>
/// Wzorzec Adapter: Wykorzystano klasę `Adapter`, która integruje `Adaptee` z `ITarget`. Dodaj kolejne metody do `Adaptee` oraz zaktualizuj `Adapter`, aby obsługiwał nowe metody.
/// Wzorzec Dekorator: Stworzono `Decorator`, który dodaje dodatkową funkcjonalność do `ConcreteComponent`. Utwórz kolejne dekoratory, które dodają różne rodzaje funkcjonalności i ich skomponowanie.
/// Wzorzec Fasada: Zastosowano `Facade` do uproszczenia interfejsu `ComplexSubsystemA`, `ComplexSubsystemB` i `ComplexSubsystemC`. Dodaj nowe operacje do fasady, aby jeszcze bardziej uprościć interakcję z systemem.
/// </summary>
public class AdapterAndDecorator
{
    /// <summary>
    ///1. Jakie są główne korzyści ze stosowania wzorca Adapter?
    ///2. Jakie są potencjalne wady użycia wzorca Adapter?
    ///3. Dlaczego warto stosować wzorzec Dekorator zamiast dziedziczenia?
    ///4. Jakie inne funkcjonalności można by dodać za pomocą wzorca Dekorator?
    ///5. Jakie są zalety stosowania wzorca Fasada?
    ///6. W jakich przypadkach użycie wzorca Fasada może być nieodpowiednie?
    /// </summary>
    public static void Main()
    {
        // Wzorzec Adapter
        Console.WriteLine("Adapter Pattern:");
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);
        target.Request();

        // Wzorzec Dekorator
        Console.WriteLine("\nDecorator Pattern:");
        IComponent component = new ConcreteComponent();
        IComponent decoratedComponent = new Decorator(component);
        decoratedComponent.Operation();

        // Wzorzec Fasada
        Console.WriteLine("\nFacade Pattern:");
        ComplexSubsystemA subsystemA = new ComplexSubsystemA();
        ComplexSubsystemB subsystemB = new ComplexSubsystemB();
        ComplexSubsystemC subsystemC = new ComplexSubsystemC();
        Facade facade = new Facade(subsystemA, subsystemB, subsystemC);
        facade.SimplifiedOperation();
    }
}