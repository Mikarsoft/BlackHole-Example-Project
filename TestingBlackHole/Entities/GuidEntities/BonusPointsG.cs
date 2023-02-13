using BlackHole.Entities;

namespace TestingBlackHole.Entities.GuidEntities
{
    public class BonusPointsG : BlackHoleEntity<Guid>
    {
        public decimal Points { get; set; }
        public string OfferName { get; set; } = string.Empty;
    }
}
