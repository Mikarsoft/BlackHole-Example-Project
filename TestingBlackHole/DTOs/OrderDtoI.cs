using BlackHole.Entities;

namespace TestingBlackHole.DTOs
{
    public class OrderDtoI: BlackHoleDto<int>
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public string ProductCategory { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public double ProductPrice { get; set; }

        public bool Delivered { get; set; }

        public DateTime IssueDate { get; set; }

        public string BonusP { get; set; } = "";
    }
}
