public class AgeDiscountRule : IPricingRule
{
    public decimal Apply(decimal currentPrice, Medicine medicine, Patient patient)
    {
        if (patient.Age < 18)
            return currentPrice * 0.5m;

        if (patient.Age >= 65)
            return currentPrice * 0.7m;

        return currentPrice;
    }
}