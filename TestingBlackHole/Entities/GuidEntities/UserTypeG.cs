using BlackHole.Entities;

namespace TestingBlackHole.Entities.GuidEntities
{
    public class UserTypeG : BlackHoleEntity<Guid>
    {
        public string UserTypeName { get; set; } = string.Empty;

        [ForeignKey(typeof(AuthCookieG), false)]
        public Guid AuthorizationCookieId { get; set; }

        public string Permissions { get; set; } = string.Empty;
    }
}
