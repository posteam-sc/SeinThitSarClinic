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
    
    public partial class MainPurchase
    {
        public MainPurchase()
        {
            this.PurchaseDeleteLogs = new HashSet<PurchaseDeleteLog>();
            this.PurchaseDetails = new HashSet<PurchaseDetail>();
        }
    
        public int Id { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string VoucherNo { get; set; }
        public Nullable<long> TotalAmount { get; set; }
        public Nullable<long> Cash { get; set; }
        public Nullable<long> OldCreditAmount { get; set; }
        public Nullable<long> SettlementAmount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> DiscountAmount { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<bool> IsCompletedInvoice { get; set; }
        public Nullable<bool> IsCompletedPaid { get; set; }
        public Nullable<bool> IsPurchase { get; set; }
    
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<PurchaseDeleteLog> PurchaseDeleteLogs { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
