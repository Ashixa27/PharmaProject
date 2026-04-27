public interface IPricingRuleEngine
{
    decimal CalculatePrice(Medicine medicine, Patient patient);
}