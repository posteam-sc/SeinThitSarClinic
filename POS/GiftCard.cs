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
    
    public partial class GiftCard
    {
        public GiftCard()
        {
            this.Transactions = new HashSet<Transaction>();
        }
    
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public Nullable<long> Amount { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
