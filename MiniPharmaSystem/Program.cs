class Program
{
    static void Main()
    {
        var service = BuildService();
        var handler = new ConsoleMenuHandler(service);
        handler.Run();
    }

    static PharmacyService BuildService()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Data", "medicines.json");
        var repo = new JsonMedicineRepository(path);
        var engine = new PricingRuleEngine(new List<IPricingRule>
        {
            new PrescriptionRequiredRule(),
            new AgeDiscountRule(),
            new PrescriptionDiscountRule()
        });
        return new PharmacyService(repo, new MedicineFactory(), engine);
    }
}