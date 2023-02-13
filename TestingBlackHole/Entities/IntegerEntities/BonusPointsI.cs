using BlackHole.Entities;

namespace TestingBlackHole.Entities.IntegerEntities
{
    public class BonusPointsI : BlackHoleEntity<int>
    {
        public decimal Points { get; set; }
        public string OfferName { get; set; } = string.Empty;
    }
}
