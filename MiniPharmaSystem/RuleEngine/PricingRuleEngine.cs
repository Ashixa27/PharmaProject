public class PricingRuleEngine
{
    private readonly List<IPricingRule> _rules;

    public PricingRuleEngine(List<IPricingRule> rules)
    {
        _rules = rules;
    }

    public decimal CalculatePrice(Medicine medicine, Patient patient)
    {
        decimal price = medicine.BasePrice;

        foreach (var rule in _rules)
        {
            price = rule.Apply(price, medicine, patient);
        }

        return price;
    }
}