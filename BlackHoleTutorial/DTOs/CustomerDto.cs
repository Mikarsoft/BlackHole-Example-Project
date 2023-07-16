using BlackHole.Entities;

namespace BlackHoleTutorial.DTOs
{
    //A Dto for some columns of the Customer
    public class CustomerDto : BlackHoleDto<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
