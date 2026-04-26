public interface IPricingRule
{
    decimal Apply(decimal currentPrice, Medicine medicine, Patient patient);
}