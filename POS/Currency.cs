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
    
    public partial class Currency
    {
        public Currency()
        {
            this.ExchangeRateForTransactions = new HashSet<ExchangeRateForTransaction>();
            this.Transactions = new HashSet<Transaction>();
        }
    
        public int Id { get; set; }
        public string Country { get; set; }
        public string Symbol { get; set; }
        public string CurrencyCode { get; set; }
        public Nullable<int> LatestExchangeRate { get; set; }
    
        public virtual ICollection<ExchangeRateForTransaction> ExchangeRateForTransactions { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}