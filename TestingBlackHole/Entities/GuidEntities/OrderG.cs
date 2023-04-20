using BlackHole.Entities;

namespace TestingBlackHole.Entities.GuidEntities
{
    public class OrderG : BlackHoleEntity<Guid>
    {
        [NotNullable]
        public DateTime IssueDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public bool Delivered { get; set; }

        [ForeignKey(typeof(CustomerG), false)]
        public Guid CustomerId { get; set; }
    }
}
