using BlackHole.Entities;

namespace TestingBlackHole.Entities.IntegerEntities
{
    public class UserTypeI : BlackHoleEntity<int>
    {
        public string UserTypeName { get; set; } = string.Empty;

        [ForeignKey(typeof(AuthCookieI), false)]
        public int AuthorizationCookieId { get; set; }

        public string Permissions { get; set; } = string.Empty;
    }
}
