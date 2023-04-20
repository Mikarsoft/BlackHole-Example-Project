using BlackHole.Entities;

namespace TestingBlackHole.Entities.StringEntities
{
    public class OrderS : BlackHoleEntity<string>
    {
        [NotNullable]
        public DateTime IssueDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public bool Delivered { get; set; }

        [ForeignKey(typeof(CustomerS), false)]
        public string CustomerId { get; set; } = string.Empty;
    }
}
