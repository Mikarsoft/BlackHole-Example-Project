using BlackHole.Entities;

namespace TestingBlackHole.Entities.GuidEntities
{
    public class AuthCookieG : BlackHoleEntity<Guid>
    {
        [NotNullable]
        public string RoleName { get; set; } = string.Empty;
        [NotNullable]
        public string TokenHash { get; set; } = string.Empty;
        [NotNullable]
        public int RoleIndex { get; set; }
    }
}
