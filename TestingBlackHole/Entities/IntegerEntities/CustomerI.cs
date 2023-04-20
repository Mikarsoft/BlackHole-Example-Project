
using BlackHole.Entities;

namespace TestingBlackHole.Entities.IntegerEntities
{
    [UseActivator]
    public class CustomerI : BlackHoleEntity<int>
    {
        [VarCharSize(50)]
        public string FirstName { get; set; } = string.Empty;

        [VarCharSize(50)]
        public string LastName { get; set; } = string.Empty;

        [NotNullable]
        public string Email { get; set; } = string.Empty;

        [ForeignKey(typeof(UserTypeI), false)]
        public int UserTypeId { get; set; }

        public Guid ApiId { get; set; }
    }
}
