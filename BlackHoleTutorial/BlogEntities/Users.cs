using BlackHole.Entities;

namespace BlackHoleTutorial.BlogEntities
{
    public class Users :BlackHoleEntity<int>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
