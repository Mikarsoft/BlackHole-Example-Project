using BlackHole.Entities;

namespace TestingBlackHole.Entities.IntegerEntities
{
    public class AuthCookieI : BlackHoleEntity<int>
    {
        [NotNullable]
        public string RoleName { get; set; } = string.Empty;
        [NotNullable]
        public string TokenHash { get; set; } = string.Empty;
        [NotNullable]
        public int RoleIndex { get; set; }
    }
}
