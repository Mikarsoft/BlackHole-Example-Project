using BlackHole.Entities;
using BlackHoleTutorial.GenericObjects;

namespace BlackHoleTutorial.EshopEntities
{
    public class Product : BHOpenEntity<Product>
    {
        [NotNullable]
        public int ProductId { get; set; }
        [NotNullable]
        public string ProductCode { get; set; } = string.Empty;


        [Unique(1)]
        [NotNullable]
        public string ProductName { get; set; } = string.Empty;
        [Unique(1)]
        [NotNullable]
        public string ProductNameFR { get; set; } = string.Empty;


        [Unique]
        [NotNullable]
        public string ProductDescription { get; set; } = string.Empty;
        [Unique]
        [NotNullable]
        public string ProductCategory { get; set; } = string.Empty;


        public EntitySettings<Product> EntityOptions(EntityOptionsBuilder<Product> builder)
        {
            return builder.SetPrimaryKey(x=>x.ProductId, true).CompositeKey(x=> x.ProductCode, new StringValueGenerator())
                .AutoGenerate(x=>x.ProductDescription, new StringValueGenerator());
        }
    }
}
