public class ConsoleMenuHandler
{
    private readonly PharmacyService _service;

    public ConsoleMenuHandler(PharmacyService service)
    {
        _service = service;
    }

    public void Run()
    {
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
                    CalculatePrice();
                    break;
                case "2":
                    ListMedicines();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    private void CalculatePrice()
    {
        Console.Write("Medicine: ");
        var name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) return;

        Console.Write("Age: ");
        if (!int.TryParse(Console.ReadLine(), out var age)) return;

        Console.Write("Has prescription (true/false): ");
        if (!bool.TryParse(Console.ReadLine(), out var hasPrescription)) return;

        var patient = new Patient { Age = age, HasPrescription = hasPrescription };

        try
        {
            var price = _service.GetFinalPrice(name, patient);
            Console.WriteLine($"Final price: {price}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void ListMedicines()
    {
        Console.WriteLine("\nAvailable medicines:");
        var medicines = _service.GetAllMedicines();
        foreach (var m in medicines)
        {
            Console.WriteLine($"- {m.Name}");
        }
    }
}