using BlackHole.Entities;

namespace TestingBlackHole.Entities.StringEntities
{
    public class UserTypeS : BlackHoleEntity<string>
    {
        public string UserTypeName { get; set; } = string.Empty;

        [ForeignKey(typeof(AuthCookieS), false)]
        public string AuthorizationCookieId { get; set; } = string.Empty;

        public string Permissions { get; set; } = string.Empty;
    }
}
