//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS.APP_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
            this.ProductSubCategories = new HashSet<ProductSubCategory>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductSubCategory> ProductSubCategories { get; set; }
    }
}
