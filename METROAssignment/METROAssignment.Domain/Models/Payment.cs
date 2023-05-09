namespace METROAssignment.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int? Amount { get; set; }
        public bool? IsProcessed { get; set; }
    }
}
