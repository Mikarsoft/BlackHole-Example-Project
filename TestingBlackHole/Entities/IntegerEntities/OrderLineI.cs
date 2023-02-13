using BlackHole.Attributes.ColumnAttributes;
using BlackHole.Entities;

namespace TestingBlackHole.Entities.IntegerEntities
{
    public class OrderLineI : BlackHoleEntity<int>
    {
        [ForeignKey(typeof(OrderI), false)]
        public int OrderId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public string ProductCategory { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public double ProductPrice { get; set; }

        public float Vat { get; set; }


        [ForeignKey(typeof(BonusPointsI))]
        public int BonusPointsId { get; set; }
    }
}
