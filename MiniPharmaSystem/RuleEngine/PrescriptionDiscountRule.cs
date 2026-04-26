public class PrescriptionDiscountRule : IPricingRule
{
    public decimal Apply(decimal currentPrice, Medicine medicine, Patient patient)
    {
        if (!patient.HasPrescription)
            return currentPrice;

        return medicine.PrescriptionDiscount > 0
            ? currentPrice - (currentPrice * medicine.PrescriptionDiscount)
            : currentPrice;
    }
}