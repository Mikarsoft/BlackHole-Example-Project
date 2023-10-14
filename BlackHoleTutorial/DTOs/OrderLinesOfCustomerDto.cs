using BlackHole.Entities;

namespace BlackHoleTutorial.DTOs
{
    //A Dto that is used to Join the OrderLines with the Order and the Customer tables
    public class OrderLinesOfCustomerDto : BlackHoleDto<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string QRCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Priceeeees { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int DiscountPercentage { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
    }
}
