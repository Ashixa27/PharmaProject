public interface IMedicineRepository
{
    List<MedicineDto> GetAll();
    MedicineDto GetByName(string name);
}