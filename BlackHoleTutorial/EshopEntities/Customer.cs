using BlackHole.Entities;

namespace BlackHoleTutorial.EshopEntities
{
    //The Customer Main Entity. This properties will become columns on the Customer table in the database
    // Watch the tutorial video to learn what each attribute does.

    public class Customer : BlackHoleEntity<Guid>
    {
        [VarCharSize(50)]
        public string FirstName { get; set; } = string.Empty;

        [VarCharSize(50)]
        public string LastName { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        [VarCharSize(500)]
        public string PhoneNumber { get; set; } = string.Empty;

        [VarCharSize(100)]
        public string Email { get; set; } = string.Empty;

        public string Nationality { get; set; } = string.Empty;
    }
}
