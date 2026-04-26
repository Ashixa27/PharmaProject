public class MedicineFactory : IMedicineFactory
{
    public Medicine Create(MedicineDto dto)
    {
        return new Medicine
        {
            Name = dto.Name,
            Type = dto.Type,
            BasePrice = dto.BasePrice,
            PrescriptionDiscount = dto.PrescriptionDiscount
        };
    }
}