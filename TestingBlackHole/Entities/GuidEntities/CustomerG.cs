using BlackHole.Entities;

namespace TestingBlackHole.Entities.GuidEntities
{
    [UseActivator]
    public class CustomerG : BlackHoleEntity<Guid>
    {
        [VarCharSize(50)]
        public string FirstName { get; set; } = string.Empty;

        [VarCharSize(50)]
        public string LastName { get; set; } = string.Empty;

        [NotNullable]
        public string Email { get; set; } = string.Empty;

        [ForeignKey(typeof(UserTypeG), false)]
        public Guid UserTypeId { get; set; }

        public Guid ApiId { get; set; }
    }
}
