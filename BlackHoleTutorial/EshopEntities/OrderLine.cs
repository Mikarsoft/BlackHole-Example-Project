using BlackHole.Entities;

namespace BlackHoleTutorial.EshopEntities
{
    //The OrderLine Main Entity. This properties will become columns on the OrderLine table in the database
    // Watch the tutorial video to learn what each attribute does.

    public class OrderLine : BlackHoleEntity<int>
    {
        [ForeignKey(typeof(Orders),false)]
        public string OrderId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //Composite Foreigh Keys that point to Composite Primary Key
        [ForeignKey(typeof(Product), "ProductId")]
        public int ProductId { get; set; }

        [ForeignKey(typeof(Product), "ProductCode")]
        [VarCharSize]
        public string ProductCode { get; set; } = string.Empty;
    }
}
