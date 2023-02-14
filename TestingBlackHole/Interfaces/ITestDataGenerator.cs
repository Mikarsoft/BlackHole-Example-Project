using TestingBlackHole.Entities.GuidEntities;
using TestingBlackHole.Entities.IntegerEntities;
using TestingBlackHole.Entities.StringEntities;

namespace TestingBlackHole.Interfaces
{
    public interface ITestDataGenerator
    {
        List<CustomerG> GenerateCustomersG(int number, List<Guid> userTypes);
        List<CustomerS> GenerateCustomersS(int number, List<string> userTypes);
        List<CustomerI> GenerateCustomersI(int number, List<int> userTypes);

        List<UserTypeS> GenerateUserTypesS(int number, List<string> authCookies);
        List<UserTypeG> GenerateUserTypesG(int number, List<Guid> authCookies);
        List<UserTypeI> GenerateUserTypesI(int number, List<int> authCookies);

        List<OrderI> GenerateOrdersI(int number, List<int> customers);
        List<OrderG> GenerateOrdersG(int number, List<Guid> customers);
        List<OrderS> GenerateOrdersS(int number, List<string> customers);

        List<BonusPointsI> GetBonusPointsI(int number);
        List<BonusPointsG> GetBonusPointsG(int number);
        List<BonusPointsS> GetBonusPointsS(int number);

        List<OrderLineI> GenerateOrderLinesI(string company, List<int> bonuses);
        List<OrderLineG> GenerateOrderLinesG(string company, List<Guid> bonuses);
        List<OrderLineS> GenerateOrderLinesS(string company, List<string> bonuses);

        List<AuthCookieI> GenerateCookieI(int number);
        List<AuthCookieG> GenerateCookieG(int number);
        List<AuthCookieS> GenerateCookieS(int number);
    }
}
