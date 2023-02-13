using BlackHole.Attributes.ColumnAttributes;
using BlackHole.Attributes.EntityAttributes;
using BlackHole.Entities;

namespace TestingBlackHole.Entities.StringEntities
{
    [UseActivator]
    public class CustomerS : BlackHoleEntity<string>
    {
        [VarCharSize(50)]
        public string FirstName { get; set; } = string.Empty;

        [VarCharSize(50)]
        public string LastName { get; set; } = string.Empty;

        [NotNullable]
        public string Email { get; set; } = string.Empty;

        [ForeignKey(typeof(UserTypeS), false)]
        public string UserTypeId { get; set; } = string.Empty;

        public Guid ApiId { get; set; }
    }
}
