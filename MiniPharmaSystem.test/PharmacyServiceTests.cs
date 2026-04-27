using System;
using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class PharmacyServiceTests
{
    private IMedicineRepository _repo = null!;
    private IMedicineFactory _factory = null!;
    private IPricingRuleEngine _engine = null!;
    private PharmacyService _service = null!;

    [SetUp]
    public void Setup()
    {
        _repo = Substitute.For<IMedicineRepository>();
        _factory = Substitute.For<IMedicineFactory>();
        _engine = Substitute.For<IPricingRuleEngine>();
        _service = new PharmacyService(_repo, _factory, _engine);
    }

    [Test]
    public void AgeDiscountRule_AppliesCorrectDiscounts()
    {
        var rule = new AgeDiscountRule();
        var med = new Medicine {Name = "Test", Type = "OTC", BasePrice = 100m};

        Assert.AreEqual(50m, rule.Apply(100m, med, new Patient {Age = 10}));
        Assert.AreEqual(100m, rule.Apply(100m, med, new Patient {Age = 30}));
        Assert.AreEqual(70m, rule.Apply(100m, med, new Patient {Age = 70}));
    }

    [Test]
    public void PrescriptionRequiredRule_Throws_WhenMissingPrescription()
    {
        var rule = new PrescriptionRequiredRule();
        var med = new Medicine {Name = "Test", Type = "prescription", BasePrice = 45m};
        var patient = new Patient {Age = 30, HasPrescription = false};

        Assert.Throws<InvalidOperationException>(() => rule.Apply(45m, med, patient));
    }
}