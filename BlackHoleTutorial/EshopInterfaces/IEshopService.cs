using BlackHoleTutorial.EshopEntities;

namespace BlackHoleTutorial.EshopInterfaces
{
    //An interface for EshopService
    public interface IEshopService
    {
        //Generate and Insert a Customer and return the Id
        Guid InsertCustomer();

        //Get the Customer Information Using the Id
        Customer? GetCustomerById(Guid customerId);

        //Generate and insert order for a specific customer
        List<int> InsertOrderForCustomer(Guid customerId);

        //Generate and insert order with a Transaction
        List<int> InsertOrderForCustomerTransaction(Guid customerId);
    }
}
