using BlackHole.Core;
using BlackHoleTutorial.DTOs;
using BlackHoleTutorial.EshopEntities;
using BlackHoleTutorial.EshopInterfaces;
using BlackHoleTutorial.GenericObjects;
using Microsoft.AspNetCore.Mvc;

namespace BlackHoleTutorial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EshopController : ControllerBase
    {
        //Local Services of this Project
        private readonly IEshopService _eshopService;

        //Services that are coming from BlackHole
        private readonly IBHDataProvider<Customer, Guid> _customerService;
        private readonly IBHDataProvider<OrderLine, int> _orderLineService;
        private readonly IBHDataProvider<Discount,int> _discountService;
        private readonly IBHDataProvider<Orders, string> _orderService;
        private readonly IBHViewStorage _viewStorage;
        private readonly IBHConnection _connection;

        //Constructor of this Controller
        public EshopController(IEshopService eshopService, IBHDataProvider<Customer,Guid> customerService,IBHConnection connection,
            IBHDataProvider<OrderLine, int> orderLineService, IBHViewStorage viewStorage, IBHDataProvider<Discount, int> discountService, IBHDataProvider<Orders, string> orderService)
        {
            _eshopService = eshopService;
            _customerService = customerService;
            _orderLineService = orderLineService;
            _viewStorage = viewStorage;
            _discountService = discountService;
            _orderService = orderService;
            _connection = connection;
        }

        //Endpoint to insert a Customer
        [HttpPost]
        public ActionResult<Guid> InsertCustomer()
        {
            return _eshopService.InsertCustomer();
        }

        //Endpoint to select a Customer by Id
        [HttpGet]
        public ActionResult<Customer?> GetCustomerById(Guid id)
        {
            return _eshopService.GetCustomerById(id);
        }

        //Endpoint to select a Customer by First Name
        [HttpGet]
        [Route("byFirstName")]
        public async Task<ActionResult<Customer?>> GetCustomerByName(string FirstName)
        {
            return await _customerService.GetEntryAsyncWhere(x => x.FirstName == FirstName);
        }

        //Endpoint to select specific columns of the Customer table searching by the Last Name
        [HttpGet]
        [Route("EmailbyName")]
        public ActionResult<CustomerDto?> GetCustomerEmailByName(string LastName)
        {
            return _customerService.GetEntryWhere<CustomerDto>(x => x.LastName == LastName);
        }

        //Endpoint to update specific columns of the Customer table using DTO and searching by Last Name
        [HttpPost]
        [Route("updateLocation")]
        public ActionResult<bool> UpdateCustomersLocation(string LastName, CustomerUpdateLocation customerNewInfo)
        {
            return _customerService.UpdateEntriesWhere(x => x.LastName == LastName, customerNewInfo);
        }

        //Endpoint to generate and insert an Order for a specific Customer
        [HttpPost]
        [Route("insertOrder")]
        public ActionResult<List<int>> InsertOrderForCustomer(Guid customerId)
        {
            return _eshopService.InsertOrderForCustomer(customerId);
        }

        //Endpoint to Create a join between the OrderLines, the Orders, the Customer and the Discount tables
        //Watch the video tutorial on YouTube for better understanding the join sequence
        [HttpGet]
        [Route("customersOrderLine")]
        public ActionResult<List<OrderLinesOfCustomerDto>> GetOrderLinesOfCustomer(Guid customerId)
        {
            return _orderLineService.InnerJoin<Orders, string, OrderLinesOfCustomerDto>(x => x.OrderId, x => x.Id)
                .CastColumnOfFirstAs(x => x.Price, x => x.Priceeeees).Then()
                .InnerJoinOn<OrderLine, Product, int, OrderLinesOfCustomerDto>(x => x.ProductId, x => x.ProductId).And(x => x.ProductCode, x => x.ProductCode)
                .Then()
                .InnerJoinOn<Orders, Customer, Guid, OrderLinesOfCustomerDto>(x => x.CustomerId, x => x.Id).WhereSecond(x => x.Id == customerId)
                //.Then().InnerJoinOn<Customer, Discount, string, OrderLinesOfCustomerDto>(x => x.FirstName, x => x.FirstName).And(x => x.LastName, x => x.LastName)
                .Then().ExecuteQuery();
        }

        //Endpoint to store as View, a join of the OrderLines, the Orders and the Customer tables
        //Watch the video tutorial on YouTube for better understanding the join sequence
        [HttpPost]
        [Route("storeCustomerOrderLineView")]
        public ActionResult<int> StoreOrderLineView(Guid customerId)
        {
            return _orderLineService.InnerJoin<Orders, string, OrderLinesOfCustomerDto>(x => x.OrderId, x => x.Id)
            .CastColumnOfFirstAs(x => x.Price, x => x.Priceeeees).Then()
            .InnerJoinOn<Orders, Customer, Guid, OrderLinesOfCustomerDto>(x => x.CustomerId, x => x.Id).WhereSecond(x => x.Id == customerId)
            .Then().StoreAsView();
        }

        //Endpoint to get the saved stored view by the specified DTO type
        [HttpGet]
        [Route("getStoredView")]
        public ActionResult<List<OrderLinesOfCustomerDto>> GetStoredViewOfCustomer()
        {
            return _viewStorage.ExecuteView<OrderLinesOfCustomerDto>();
        }

        //Endpoint to generate and insert an Order for a specific Customer using a transaction
        [HttpPost]
        [Route("insertOrderWithTransaction")]
        public ActionResult<List<int>> InsertOrderWithTransaction(Guid customerId)
        {
            return _eshopService.InsertOrderForCustomerTransaction(customerId);
        }

        //Endpoint to select all Customers using custom sql command
        [HttpGet]
        [Route("connectionTest")]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            var result = _connection.Query<Customer>(@"Select * from eshop.""Customer""");

            return result;
        }
    }
}
