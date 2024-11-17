using System.Collections;
using PartOne.Exercises;

namespace PartOne.Tests;

public class StaticsTest
{
    [SetUp]
    public void Setup()
    {
        FilterData = Statics.Filter;
        AggregateData = Statics.Aggregate;
        OperationData = Statics.BulldogsAndPersians;
    }

    [Test]
    public void Filter_ShouldReturnOnlySiameseCats()
    {
        var result = FilterData.Invoke(Statics.Animals).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result.Count, Is.EqualTo(5));
            Assert.IsTrue(result.All(x => x.RaceName == "Siamese"));
        });
    }

    [Test]
    public void Aggregate_ShouldReturnAverageAgeForEachRace()
    {
        IList<Animal> result = AggregateData.Invoke(Statics.Animals);

        Assert.Multiple(() =>
        {
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result.Single(x => x.RaceName == "Siamese").Age, Is.EqualTo(10));
            Assert.That(result.Single(x => x.RaceName == "Persian").Age, Is.EqualTo(5));
            Assert.That(result.Single(x => x.RaceName == "Bulldog").Age, Is.EqualTo(3));
            Assert.That(result.Single(x => x.RaceName == "Poodle").Age, Is.EqualTo(4));
        });
    }

    [Test]
    public void BulldogsAndPersians_ShouldReturnCorrectValues()
    {
        IDictionary<string, double> result = OperationData.Invoke(Statics.Animals);


        Assert.Multiple(() =>
        {
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.IsTrue(result.ContainsKey("Bulldog"));
            Assert.IsTrue(result.ContainsKey("Persian"));
            Assert.AreEqual(4.123d, result["Bulldog"], 0.001);
            Assert.AreEqual(5.291d, result["Persian"], 0.001);
        });
    }

    #region Helpers

    private OperationDelegate OperationData { get; set; }
    private AggregateDelegate AggregateData { get; set; }
    private FilterDelegate FilterData { get; set; }

    private delegate IEnumerable<Animal> FilterDelegate(IEnumerable<Animal> animals);

    private delegate IList<Animal> AggregateDelegate(IEnumerable<Animal> animals);

    private delegate IDictionary<string, double> OperationDelegate(IEnumerable<Animal> animals);

    #endregion
}