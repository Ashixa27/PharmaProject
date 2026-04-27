public class PharmacyService
{
    private readonly IMedicineRepository _repo;
    private readonly IMedicineFactory _factory;
    private readonly IPricingRuleEngine _engine;

    public PharmacyService(
        IMedicineRepository repo,
        IMedicineFactory factory,
        IPricingRuleEngine engine)
    {
        _repo = repo;
        _factory = factory;
        _engine = engine;
    }

    public decimal GetFinalPrice(string medicineName, Patient patient)
    {
        var dto = _repo.GetByName(medicineName);
        var medicine = _factory.Create(dto);

        return _engine.CalculatePrice(medicine, patient);
    }

    public List<MedicineDto> GetAllMedicines()
    {
        return _repo.GetAll();
    }
}