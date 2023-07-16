using BlackHole.Entities;

namespace BlackHoleTutorial.EshopEntities
{
    //The Order Main Entity. This properties will become columns on the Order table in the database
    // Watch the tutorial video to learn what each attribute does.
    [UseActivator]
    public class Orders : BlackHoleEntity<string>
    {
        [ForeignKey(typeof(Customer),false)]
        public Guid CustomerId { get; set; }

        [NotNullable]
        public DateTime OrderDate { get; set; }

        public DateTime? OrderDeliveryDate { get; set; }

        public bool IsDelivered { get; set; }

        public decimal TotalPrice { get; set; }

        public int TotalProducts { get; set; }

        [VarCharSize(1000)]
        public string QRCode { get; set; } = string.Empty;
    }
}
