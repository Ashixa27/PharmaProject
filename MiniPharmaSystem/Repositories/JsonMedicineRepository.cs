using System.Text.Json;

public class JsonMedicineRepository : IMedicineRepository
{
    private readonly List<MedicineDto> _medicines;

    public JsonMedicineRepository(string filePath)
{
    if (!File.Exists(filePath))
        throw new FileNotFoundException($"JSON not found: {filePath}");

    var json = File.ReadAllText(filePath);

    var data = JsonSerializer.Deserialize<List<MedicineDto>>(json);

    if (data is null || data.Count == 0)
        throw new Exception("Invalid or empty medicines JSON file");

    _medicines = data;
}

public List<MedicineDto> GetAll()
{
    return _medicines.ToList();
}

   public MedicineDto GetByName(string name)
{
    if (_medicines is null)
        throw new Exception("Medicines list not initialized");

    if (string.IsNullOrWhiteSpace(name))
        throw new ArgumentException("Name is empty");

    name = name.Trim();

    var med = _medicines.FirstOrDefault(x =>
        !string.IsNullOrWhiteSpace(x.Name) &&
        x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    if (med is null)
        throw new Exception(
            $"Medicine '{name}' not found. Available: {string.Join(", ", _medicines.Select(m => m.Name))}");

    return med;
}
}