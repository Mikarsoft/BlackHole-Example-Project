using BlackHole.Entities;

namespace TestingBlackHole.Entities.StringEntities
{
    public class BonusPointsS : BlackHoleEntity<string>
    {
        public decimal Points { get; set; }
        public string OfferName { get; set; } = string.Empty;
    }
}
