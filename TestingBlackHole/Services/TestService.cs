using BlackHole.Entities;
using BlackHole.Interfaces;
using TestingBlackHole.DTOs;
using TestingBlackHole.Entities.GuidEntities;
using TestingBlackHole.Entities.IntegerEntities;
using TestingBlackHole.Entities.StringEntities;
using TestingBlackHole.Interfaces;

namespace TestingBlackHole.Services
{
    public class TestService : BlackHoleScoped , ITestService
    {
        private readonly IBHDataProvider<CustomerG, Guid> _customerServiceG;
        private readonly IBHDataProvider<CustomerI, int> _customerServiceI;
        private readonly IBHDataProvider<CustomerS, string> _customerServiceS;

        private readonly IBHDataProvider<AuthCookieG, Guid> _authCookieServiceG;
        private readonly IBHDataProvider<AuthCookieI, int> _authCookieServiceI;
        private readonly IBHDataProvider<AuthCookieS, string> _authCookieServiceS;

        private readonly IBHDataProvider<UserTypeG, Guid> _userTypeServiceG;
        private readonly IBHDataProvider<UserTypeI, int> _userTypeServiceI;
        private readonly IBHDataProvider<UserTypeS, string> _userTypeServiceS;

        private readonly IBHDataProvider<OrderG, Guid> _orderServiceG;
        private readonly IBHDataProvider<OrderI, int> _orderServiceI;
        private readonly IBHDataProvider<OrderS, string> _orderServiceS;

        private readonly IBHDataProvider<OrderLineG, Guid> _orderLineServiceG;
        private readonly IBHDataProvider<OrderLineI, int> _orderLineServiceI;
        private readonly IBHDataProvider<OrderLineS, string> _orderLineServiceS;

        private readonly IBHDataProvider<BonusPointsG, Guid> _bonusServiceG;
        private readonly IBHDataProvider<BonusPointsI, int> _bonusServiceI;
        private readonly IBHDataProvider<BonusPointsS, string> _bonusServiceS;

        //All DataProviders Inserted in a single service for this Example. For Better Performance I suggest you use only the providers you need per service.
        public TestService(IBHDataProvider<CustomerG, Guid> customerServiceG,IBHDataProvider<CustomerI, int> customerServiceI,
            IBHDataProvider<CustomerS, string> customerServiceS,IBHDataProvider<AuthCookieG, Guid> authCookieServiceG,IBHDataProvider<AuthCookieI, int> authCookieServiceI,
            IBHDataProvider<AuthCookieS, string> authCookieServiceS,IBHDataProvider<UserTypeG, Guid> userTypeServiceG,IBHDataProvider<UserTypeI, int> userTypeServiceI,
            IBHDataProvider<UserTypeS, string> userTypeServiceS,IBHDataProvider<OrderG, Guid> orderServiceG,IBHDataProvider<OrderI, int> orderServiceI,
            IBHDataProvider<OrderS, string> orderServiceS,IBHDataProvider<OrderLineG, Guid> orderLineServiceG,IBHDataProvider<OrderLineI, int> orderLineServiceI,
            IBHDataProvider<OrderLineS, string> orderLineServiceS,IBHDataProvider<BonusPointsG, Guid> bonusServiceG,IBHDataProvider<BonusPointsI, int> bonusServiceI,
            IBHDataProvider<BonusPointsS, string> bonusServiceS)
        {
            _authCookieServiceG = authCookieServiceG;_authCookieServiceI = authCookieServiceI;_authCookieServiceS = authCookieServiceS;
            _userTypeServiceG = userTypeServiceG;_userTypeServiceI = userTypeServiceI;_userTypeServiceS = userTypeServiceS;
            _customerServiceG = customerServiceG;_customerServiceI = customerServiceI;_customerServiceS = customerServiceS;
            _orderLineServiceG = orderLineServiceG;_orderLineServiceI = orderLineServiceI;_orderLineServiceS = orderLineServiceS;
            _orderServiceG=orderServiceG;_orderServiceI=orderServiceI;_orderServiceS=orderServiceS;
            _bonusServiceG=bonusServiceG;_bonusServiceI=bonusServiceI;_bonusServiceS=bonusServiceS;
        }

        // Integer Id Test
        public IList<int> InsertAuthCookies(List<AuthCookieI> cookies)
        {
            return _authCookieServiceI.InsertEntries(cookies);
        }

        public IList<int> InsertUserTypes(List<UserTypeI> userTypes)
        {
            return _userTypeServiceI.InsertEntries(userTypes);
        }

        public async Task<int> InsertCustomer(CustomerI customer)
        {
            return await _customerServiceI.InsertEntryAsync(customer);
        }

        public async Task<bool> DeleteCustomersFromIdToId(int from, int to)
        {
           return await _customerServiceI.DeleteEntriesWhere(x => x.Id < to && x.Id > from);
        }

        public async Task<IList<CustomerI>> GetAllCustomersAsync()
        {
            return await _customerServiceI.GetAllEntriesAsync();
        }

        public IList<int> InsertCustomers(List<CustomerI> customers)
        {
            return _customerServiceI.InsertEntries(customers);
        }

        public async Task<int> InsertBonus(BonusPointsI bonus)
        {
            return await _bonusServiceI.InsertEntryAsync(bonus);
        }

        public async Task<List<int>> InsertManyBonus(List<BonusPointsI> bonus)
        {
            return await _bonusServiceI.InsertEntriesAsync(bonus);
        }

        public UserTypeI? GetUserTypeById(int Id)
        {
            return _userTypeServiceI.GetEntryById(Id);
        }

        public async Task<bool> DeleteUserTypeById(int Id)
        {
            return await _userTypeServiceI.DeleteEntryById(Id);
        }

        public async Task<IList<int>> InsertBonusLines(List<BonusPointsI> bonus)
        {
            return await _bonusServiceI.InsertEntriesAsync(bonus);
        }

        public async Task<IList<int>> InsertOrder(OrderI order, List<OrderLineI> orderLines)
        {
            int OrderId = await _orderServiceI.InsertEntryAsync(order);

            foreach (OrderLineI line in orderLines)
            {
                line.OrderId = OrderId;
            }

            return await _orderLineServiceI.InsertEntriesAsync(orderLines);
        }

        public IList<CustomerI> GetCustomersOfUserType(int userTypeId)
        {
            return _customerServiceI.GetEntriesWhere(x => x.UserTypeId == userTypeId);
        }

        public async Task<IList<OrderI>> GetOrdersOfCustomerId(int Id)
        {
            return await _orderServiceI.GetEntriesAsyncWhere(x => x.CustomerId == Id);
        }

        public async Task<List<int>> GetCustomerIds()
        {
            return await _customerServiceI.GetIdsWhereAsync(x => x.Id != 0);
        }

        public async Task<IList<OrderDtoI>> JoinProductsToCustomers()
        {
            return await _orderLineServiceI.InnerJoin<OrderI, int, OrderDtoI>(x => x.OrderId, x => x.Id)
                .Then().InnerJoinOn<OrderI, CustomerI, int, OrderDtoI>(x => x.CustomerId, z => z.Id)
                .WhereSecond(x => x.UserTypeId != 2).Then()
                .InnerJoinOn<OrderLineI, BonusPointsI, int, OrderDtoI>(x => x.BonusPointsId, x => x.Id)
                .CastColumnOfSecondAs(x => x.Points, x => x.BonusP).CastColumnOfSecondAs(x => x.Id, x => x.Id)
                .Then()
                .ExecuteQueryAsync();
        }


        //Guid Id Tests
        public IList<Guid> InsertAuthCookies(List<AuthCookieG> cookies)
        {
            return _authCookieServiceG.InsertEntries(cookies);
        }

        public IList<Guid> InsertUserTypes(List<UserTypeG> userTypes)
        {
            return _userTypeServiceG.InsertEntries(userTypes);
        }

        public async Task<Guid> InsertCustomer(CustomerG customer)
        {
            return await _customerServiceG.InsertEntryAsync(customer);
        }

        public async Task<IList<CustomerG>> GetAllCustomersAsyncG()
        {
            return await _customerServiceG.GetAllEntriesAsync();
        }

        public IList<Guid> InsertCustomers(List<CustomerG> customers)
        {
            return _customerServiceG.InsertEntries(customers);
        }

        public async Task<Guid> InsertBonus(BonusPointsG bonus)
        {
            return await _bonusServiceG.InsertEntryAsync(bonus);
        }

        public async Task<List<Guid>> InsertManyBonus(List<BonusPointsG> bonus)
        {
            return await _bonusServiceG.InsertEntriesAsync(bonus);
        }

        public UserTypeG? GetUserTypeById(Guid Id)
        {
            return _userTypeServiceG.GetEntryById(Id);
        }

        public async Task<bool> DeleteUserTypeById(Guid Id)
        {
            return await _userTypeServiceG.DeleteEntryById(Id);
        }

        public async Task<IList<Guid>> InsertBonusLines(List<BonusPointsG> bonus)
        {
            return await _bonusServiceG.InsertEntriesAsync(bonus);
        }

        public async Task<IList<Guid>> InsertOrder(OrderG order, List<OrderLineG> orderLines)
        {
            Guid OrderId = await _orderServiceG.InsertEntryAsync(order);

            foreach (OrderLineG line in orderLines)
            {
                line.OrderId = OrderId;
            }

            return await _orderLineServiceG.InsertEntriesAsync(orderLines);
        }

        public IList<CustomerG> GetCustomersOfUserType(Guid userTypeId)
        {
            return _customerServiceG.GetEntriesWhere(x => x.UserTypeId == userTypeId);
        }

        public async Task<IList<OrderG>> GetOrdersOfCustomerId(Guid Id)
        {
            return await _orderServiceG.GetEntriesAsyncWhere(x => x.CustomerId == Id);
        }

        public async Task<List<Guid>> GetCustomerIdsG()
        {
            return await _customerServiceG.GetIdsWhereAsync(x => x.Id != Guid.Empty);
        }

        public async Task<IList<OrderDtoG>> JoinProductsToCustomersG()
        {
            return await _orderLineServiceG.InnerJoin<OrderG, Guid, OrderDtoG>(x => x.OrderId, x => x.Id)
                .Then().InnerJoinOn<OrderG, CustomerG, Guid, OrderDtoG>(x => x.CustomerId, z => z.Id)
                .WhereSecond(x => x.UserTypeId != Guid.Empty).Then()
                .InnerJoinOn<OrderLineG, BonusPointsG, Guid, OrderDtoG>(x => x.BonusPointsId, x => x.Id)
                .CastColumnOfSecondAs(x => x.Points, x => x.BonusP).CastColumnOfSecondAs(x => x.Id, x => x.Id)
                .Then()
                .ExecuteQueryAsync();
        }

        //String Id Tests
        public IList<string?> InsertAuthCookies(List<AuthCookieS> cookies)
        {
            return _authCookieServiceS.InsertEntries(cookies);
        }

        public IList<string?> InsertUserTypes(List<UserTypeS> userTypes)
        {
            return _userTypeServiceS.InsertEntries(userTypes);
        }

        public async Task<string?> InsertCustomer(CustomerS customer)
        {
            return await _customerServiceS.InsertEntryAsync(customer);
        }

        public async Task<IList<CustomerS>> GetAllCustomersAsyncS()
        {
            return await _customerServiceS.GetAllEntriesAsync();
        }

        public IList<string?> InsertCustomers(List<CustomerS> customers)
        {
            return _customerServiceS.InsertEntries(customers);
        }

        public async Task<string?> InsertBonus(BonusPointsS bonus)
        {
            return await _bonusServiceS.InsertEntryAsync(bonus);
        }

        public async Task<List<string?>> InsertManyBonus(List<BonusPointsS> bonus)
        {
            return await _bonusServiceS.InsertEntriesAsync(bonus);
        }

        public UserTypeS? GetUserTypeById(string Id)
        {
            return _userTypeServiceS.GetEntryById(Id);
        }

        public async Task<bool> DeleteUserTypeById(string Id)
        {
            return await _userTypeServiceS.DeleteEntryById(Id);
        }

        public async Task<IList<string?>> InsertBonusLines(List<BonusPointsS> bonus)
        {
            return await _bonusServiceS.InsertEntriesAsync(bonus);
        }

        public async Task<IList<string?>> InsertOrder(OrderS order, List<OrderLineS> orderLines)
        {
            string? OrderId = await _orderServiceS.InsertEntryAsync(order);

            foreach (OrderLineS line in orderLines)
            {
                line.OrderId = OrderId;
            }

            return await _orderLineServiceS.InsertEntriesAsync(orderLines);
        }

        public IList<CustomerS> GetCustomersOfUserType(string userTypeId)
        {
            return _customerServiceS.GetEntriesWhere(x => x.UserTypeId == userTypeId);
        }

        public async Task<IList<OrderS>> GetOrdersOfCustomerId(string Id)
        {
            return await _orderServiceS.GetEntriesAsyncWhere(x => x.CustomerId == Id);
        }

        public async Task<List<string?>> GetCustomerIdsS()
        {
            return await _customerServiceS.GetIdsWhereAsync(x => x.Id != string.Empty);
        }

        public async Task<IList<OrderDtoS>> JoinProductsToCustomersS()
        {
            return await _orderLineServiceS.InnerJoin<OrderS, string, OrderDtoS>(x => x.OrderId, x => x.Id)
                .Then().InnerJoinOn<OrderS, CustomerS, string, OrderDtoS>(x => x.CustomerId, z => z.Id).Then()
                .InnerJoinOn<OrderLineS, BonusPointsS, string, OrderDtoS>(x => x.BonusPointsId, x => x.Id)
                .CastColumnOfSecondAs(x => x.Points, x => x.BonusP).CastColumnOfSecondAs(x => x.Id, x => x.Id)
                .Then()
                .ExecuteQueryAsync();
        }
    }
}
