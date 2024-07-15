//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.DeleteLogs = new HashSet<DeleteLog>();
            this.ProductPriceChanges = new HashSet<ProductPriceChange>();
            this.ProductQuantityChanges = new HashSet<ProductQuantityChange>();
            this.PurchaseDeleteLogs = new HashSet<PurchaseDeleteLog>();
            this.Transactions = new HashSet<Transaction>();
            this.UsePrePaidDebts = new HashSet<UsePrePaidDebt>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> UserRoleId { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
    
        public virtual ICollection<DeleteLog> DeleteLogs { get; set; }
        public virtual ICollection<ProductPriceChange> ProductPriceChanges { get; set; }
        public virtual ICollection<ProductQuantityChange> ProductQuantityChanges { get; set; }
        public virtual ICollection<PurchaseDeleteLog> PurchaseDeleteLogs { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<UsePrePaidDebt> UsePrePaidDebts { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
