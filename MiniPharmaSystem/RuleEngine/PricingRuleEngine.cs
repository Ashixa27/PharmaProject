public class PricingRuleEngine : IPricingRuleEngine
{
    private readonly IReadOnlyList<IPricingRule> _rules;

    public PricingRuleEngine(IReadOnlyList<IPricingRule> rules)
    {
        _rules = rules ?? throw new ArgumentNullException(nameof(rules));
    }

    public decimal CalculatePrice(Medicine medicine, Patient patient)
    {
        if (medicine == null)
            throw new ArgumentNullException(nameof(medicine));
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        decimal price = medicine.BasePrice;

        foreach (var rule in _rules)
        {
            price = rule.Apply(price, medicine, patient);
        }

        return price;
    }
}