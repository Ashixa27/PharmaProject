class Program
{
    static void Main()
    {
        var service = BuildService();

        while (true)
{
    Console.WriteLine("\n=== PHARMACY SYSTEM ===");
    Console.WriteLine("1. Calculate medicine price");
    Console.WriteLine("2. List medicines");
    Console.WriteLine("0. Exit");
    Console.Write("Choose option: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
        {
            Console.Write("Medicine: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) break;

            Console.Write("Age: ");
            if (!int.TryParse(Console.ReadLine(), out var age)) break;

            Console.Write("Has prescription (true/false): ");
            if (!bool.TryParse(Console.ReadLine(), out var hasPrescription)) break;

            var patient = new Patient
            {
                Age = age,
                HasPrescription = hasPrescription
            };

            try
            {
                var price = service.GetFinalPrice(name, patient);
                Console.WriteLine($"Final price: {price}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            break;
        }

        case "2":
{
    Console.WriteLine("\nAvailable medicines:");

    var medicines = service.GetAllMedicines();

    foreach (var m in medicines)
    {
        Console.WriteLine($"- {m.Name}");
    }

    break;
}

        case "0":
            return;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
}
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