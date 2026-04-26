public class PrescriptionRequiredRule : IPricingRule
{
    public decimal Apply(decimal currentPrice, Medicine medicine, Patient patient)
    {
        if (medicine.Type == "prescription" && !patient.HasPrescription)
            throw new InvalidOperationException("Prescription required!");

        return currentPrice;
    }
}