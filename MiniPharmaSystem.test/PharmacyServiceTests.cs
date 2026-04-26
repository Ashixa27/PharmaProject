using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class PharmacyServiceTests
{
    private PharmacyService _service = null!;

    [SetUp]
    public void Setup()
    {
        var repo = new JsonMedicineRepository("Data/medicines.json");

        var engine = new PricingRuleEngine(new List<IPricingRule>
        {
            new PrescriptionRequiredRule(),
            new AgeDiscountRule(),
            new PrescriptionDiscountRule()
        });

        _service = new PharmacyService(
            repo,
            new MedicineFactory(),
            engine);
    }

    [Test]
    public void Throws_When_NoPrescription_ForPrescriptionDrug()
    {
        Assert.Throws<InvalidOperationException>(() =>
            _service.GetFinalPrice("Augmentin",
                new Patient { Age = 30, HasPrescription = false }));
    }

    [Test]
    public void Applies_AgeDiscount_ForSenior()
    {
        var price = _service.GetFinalPrice("Parasinus",
            new Patient { Age = 70, HasPrescription = false });

        Assert.AreEqual(12.60m, price);
    }

    [Test]
    public void Does_Not_Apply_Discount_Without_Prescription()
    {
        var price = _service.GetFinalPrice(
            "Coldrex",
            new Patient
            {
                Age = 30,
                HasPrescription = false
            });

        Assert.That(price, Is.EqualTo(20m));
    }
}