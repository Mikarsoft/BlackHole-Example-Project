using BlackHole.Attributes.ColumnAttributes;
using BlackHole.Entities;

namespace TestingBlackHole.Entities.StringEntities
{
    public class AuthCookieS : BlackHoleEntity<string>
    {
        [NotNullable]
        public string RoleName { get; set; } = string.Empty;
        [NotNullable]
        public string TokenHash { get; set; } = string.Empty;
        [NotNullable]
        public int RoleIndex { get; set; }
    }
}
