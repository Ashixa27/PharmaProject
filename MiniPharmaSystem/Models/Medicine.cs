public class Medicine
{
    public required string Name { get; set; }
    public required string Type { get; set; }
    public decimal BasePrice { get; set; }
    public decimal PrescriptionDiscount { get; set; }
}