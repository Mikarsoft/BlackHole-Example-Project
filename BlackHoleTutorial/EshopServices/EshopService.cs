using BlackHoleTutorial.EshopInterfaces;
using BlackHole.Services;
using BlackHole.Core;
using BlackHoleTutorial.EshopEntities;

namespace BlackHoleTutorial.EshopServices
{
    //A Local Service of this project that is automatically gets registered in IServiceCollection by using BlackHole.Services
    public class EshopService : BlackHoleScoped, IEshopService
    {
        //Services that are coming from BlackHole
        private readonly IBHDataProvider<Customer, Guid> _customerService;
        private readonly IBHDataProvider<Orders, string> _orderService;
        private readonly IBHDataProvider<OrderLine, int> _orderLineService;
        private readonly IBHOpenDataProvider<Product> _productService;

        //Constructor of this Service
        public EshopService(IBHDataProvider<Customer,Guid> customerService, IBHDataProvider<Orders, string> orderService,
            IBHDataProvider<OrderLine, int> orderLineService, IBHOpenDataProvider<Product> productService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _orderLineService = orderLineService;
            _productService = productService;
        }

        public Customer? GetCustomerById(Guid customerId)
        {
            return _customerService.GetEntryById(customerId);
        }

        //Generates and Inserts a Customer
        public Guid InsertCustomer()
        {
            Customer customer = CustomerGenerator();
            return _customerService.InsertEntry(customer);
        }

        //Insert an Order for a specific Customer
        public List<int> InsertOrderForCustomer(Guid customerId)
        {
            List<int> orderLineIds = new List<int>();
            Orders order = OrderGenerator(customerId);
            string? orderId = _orderService.InsertEntry(order);

            if (!string.IsNullOrEmpty(orderId))
            {
                List<OrderLine> orderLines = OrderLineGenerator(order.TotalProducts, orderId);
                orderLineIds = _orderLineService.InsertEntries(orderLines);
            }

            return orderLineIds;
        }

        //Insert an Order for the Customer using a transaction
        public List<int> InsertOrderForCustomerTransaction(Guid customerId)
        {
            List<int> orderLineIds = new List<int>();

            using(BHTransaction transaction = new BHTransaction())
            {
                Orders order = OrderGenerator(customerId);
                string? orderId = _orderService.InsertEntry(order, transaction);

                if (!string.IsNullOrEmpty(orderId))
                {
                    List<OrderLine> orderLines = OrderLineGenerator(order.TotalProducts, orderId);
                    orderLineIds = _orderLineService.InsertEntries(orderLines, transaction);
                    OrderLine errorOrderLine = ErrorOrderLineGenerator();
                    //Uncomment the following line if you want to make the transaction fail.
                    //orderLineIds.Add(_orderLineService.InsertEntry(errorOrderLine, transaction));
                }
            }

            return orderLineIds;
        }

        //Generates a customer
        private Customer CustomerGenerator()
        {
            return new Customer
            {
                FirstName = "George",
                LastName ="Marcison",
                ZipCode = "12345678",
                City ="London",
                Street ="Landguard",
                Email = "archolekasm@gmail.com",
                PhoneNumber ="1234567899"
            };
        }

        //Generates Order
        private Orders OrderGenerator(Guid customerId)
        {
            return new Orders
            {
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                QRCode = "dsuifisdbfiusbdvuidsbubsdfsdfiugdsiufuisdg",
                TotalPrice = 10.5m,
                TotalProducts = 5,
            };
        }

        //Generates a list of OrderLines
        private List<OrderLine> OrderLineGenerator(int totalProducts, string orderId)
        {
            List<OrderLine> orderLines = new List<OrderLine>();

            for(int i=0; i < totalProducts; i++)
            {
                Product Aproduct = ProductGenerator(i);

                _productService.InsertEntry(Aproduct);

                orderLines.Add(new OrderLine
                {
                    ProductName ="Skyrim",
                    Price = 2.5m,
                    Quantity = 2,
                    OrderId= orderId,
                    ProductId = Aproduct.ProductId,
                    ProductCode = Aproduct.ProductCode
                });
            }

            return orderLines;
        }

        private Product ProductGenerator(int productNumber)
        {
            return new Product
            {
                ProductCategory = productNumber.ToString(),
                ProductName = $"EnglishName{productNumber}",
                ProductNameFR = $"FrenchName{productNumber}"
            };
        }

        //Generate an OrderLine with a non existing Foreing Key of the Order
        private OrderLine ErrorOrderLineGenerator()
        {
            return new OrderLine
            {
                ProductName = "Skyrim",
                Price = 2.5m,
                Quantity = 2,
                OrderId = "hdfshihfisdhsdifhsdifhdfhdi"
            };
        }
    }
}
