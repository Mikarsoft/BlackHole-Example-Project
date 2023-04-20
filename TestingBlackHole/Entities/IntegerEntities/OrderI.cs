using BlackHole.Entities;

namespace TestingBlackHole.Entities.IntegerEntities
{
    public class OrderI : BlackHoleEntity<int>
    {
        [NotNullable]
        public DateTime IssueDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public bool Delivered { get; set; }

        [ForeignKey(typeof(CustomerI), false)]
        public int CustomerId { get; set; }
    }
}
