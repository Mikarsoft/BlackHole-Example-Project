using BlackHole.Entities;

namespace TestingBlackHole.Entities.GuidEntities
{
    public class OrderLineG : BlackHoleEntity<Guid>
    {
        [ForeignKey(typeof(OrderG), false)]
        public Guid OrderId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public string ProductCategory { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public double ProductPrice { get; set; }

        public float Vat { get; set; }


        [ForeignKey(typeof(BonusPointsG))]
        public Guid BonusPointsId { get; set; }
    }
}
