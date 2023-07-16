using BlackHole.Entities;

namespace BlackHoleTutorial.EshopEntities
{
    //The Discount Main Entity. This properties will become columns on the Discount table in the database
    // Watch the tutorial video to learn what each attribute does.

    public class Discount : BlackHoleEntity<int>
    {
        [VarCharSize(50)]
        public string FirstName { get; set; } = string.Empty;

        [VarCharSize(50)]
        public string LastName { get; set; } = string.Empty;

        public int DiscountPercentage { get; set; }
    }
}
