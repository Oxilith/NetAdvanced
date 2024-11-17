using PartOne.Exercises;

namespace PartOne.Tests;

public class NullableTests
{
    [SetUp]
    public void Setup()
    {
        Nullables = new Nullables();
    }

    private Nullables Nullables { get; set; }
    
    [Test]
    public void Sum_ShouldThrowException_WhenMessageIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => Nullables.Sum(1, "2", null));
    }

    [Test]
    public void Sum_ShouldReturnSum_WhenValuesAreNotNull()
    {
        int result = Nullables.Sum(1, "2", "message");
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void Sum_ShouldUseDefaultValue_WhenValueIsNull()
    {
        int result = Nullables.Sum(null, "2", "message");
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Sum_ShouldUseDefaultIntValue_WhenRefValueIsNull()
    {
        int result = Nullables.Sum(1, null, "message");
        Assert.That(result, Is.EqualTo(1));
    }
}