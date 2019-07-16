namespace TechAndTools.Data.Models
{
    using System;
    using System.Collections.Generic;
    using TechAndTools.Data.Models.Contracts;

    public class Product : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductCategoryId { get; set; }
        public virtual Category ProductCategory { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual Description Description { get;set;}

        public string DocumentationUrl { get; set; }

        public int Warranty { get; set; }

        public decimal Price { get; set; }

        public int QuantityInStock { get; set; }

        public int SalesCount { get; set; }

        public bool IsOutOfStock { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
