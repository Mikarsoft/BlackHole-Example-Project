using BlackHole.Attributes.ColumnAttributes;
using BlackHole.Entities;

namespace TestingBlackHole.Entities.StringEntities
{
    public class OrderLineS : BlackHoleEntity<string>
    {
        [ForeignKey(typeof(OrderS), false)]
        public string OrderId { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public string ProductCategory { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public double ProductPrice { get; set; }

        public float Vat { get; set; }


        [ForeignKey(typeof(BonusPointsS))]
        public string BonusPointsId { get; set; } = string.Empty;
    }
}
