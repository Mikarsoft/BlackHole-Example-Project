using TestingBlackHole.DTOs;
using TestingBlackHole.Entities.GuidEntities;
using TestingBlackHole.Entities.IntegerEntities;
using TestingBlackHole.Entities.StringEntities;

namespace TestingBlackHole.Interfaces
{
    public interface ITestService
    {
        IList<int> InsertAuthCookies(List<AuthCookieI> cookies);

        IList<int> InsertUserTypes(List<UserTypeI> userTypes);

        Task<int> InsertCustomer(CustomerI customer);

        IList<int> InsertCustomers(List<CustomerI> customers);

        Task<IList<OrderI>> GetOrdersOfCustomerId(int Id);

        Task<IList<int>> InsertOrder(OrderI order, List<OrderLineI> orderLines);

        Task<IList<int>> InsertBonusLines(List<BonusPointsI> bonus);

        Task<int> InsertBonus(BonusPointsI bonus);

        Task<bool> DeleteCustomersFromIdToId(int from, int to);

        Task<IList<CustomerI>> GetAllCustomersAsync();

        UserTypeI? GetUserTypeById(int Id);

        IList<CustomerI> GetCustomersOfUserType(int userTypeId);

        Task<bool> DeleteUserTypeById(int Id);

        Task<List<int>> GetCustomerIds();

        Task<List<int>> InsertManyBonus(List<BonusPointsI> bonus);

        Task<IList<OrderDtoI>> JoinProductsToCustomers();


        //Guid Id Tests
        IList<Guid> InsertAuthCookies(List<AuthCookieG> cookies);

        IList<Guid> InsertUserTypes(List<UserTypeG> userTypes);

        Task<Guid> InsertCustomer(CustomerG customer);

        IList<Guid> InsertCustomers(List<CustomerG> customers);

        Task<IList<OrderG>> GetOrdersOfCustomerId(Guid Id);

        Task<IList<Guid>> InsertOrder(OrderG order, List<OrderLineG> orderLines);

        Task<IList<Guid>> InsertBonusLines(List<BonusPointsG> bonus);

        Task<Guid> InsertBonus(BonusPointsG bonus);

        Task<IList<CustomerG>> GetAllCustomersAsyncG();

        UserTypeG? GetUserTypeById(Guid Id);

        IList<CustomerG> GetCustomersOfUserType(Guid userTypeId);

        Task<bool> DeleteUserTypeById(Guid Id);

        Task<List<Guid>> GetCustomerIdsG();

        Task<List<Guid>> InsertManyBonus(List<BonusPointsG> bonus);

        Task<IList<OrderDtoG>> JoinProductsToCustomersG();



        // String Id Tests

        IList<string?> InsertAuthCookies(List<AuthCookieS> cookies);

        IList<string?> InsertUserTypes(List<UserTypeS> userTypes);

        Task<string?> InsertCustomer(CustomerS customer);

        IList<string?> InsertCustomers(List<CustomerS> customers);

        Task<IList<OrderS>> GetOrdersOfCustomerId(string Id);

        Task<IList<string?>> InsertOrder(OrderS order, List<OrderLineS> orderLines);

        Task<IList<string?>> InsertBonusLines(List<BonusPointsS> bonus);

        Task<string?> InsertBonus(BonusPointsS bonus);

        Task<IList<CustomerS>> GetAllCustomersAsyncS();

        UserTypeS? GetUserTypeById(string Id);

        IList<CustomerS> GetCustomersOfUserType(string userTypeId);

        Task<bool> DeleteUserTypeById(string Id);

        Task<List<string>> GetCustomerIdsS();

        Task<List<string?>> InsertManyBonus(List<BonusPointsS> bonus);

        Task<IList<OrderDtoS>> JoinProductsToCustomersS();
    }
}
