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
    
    public partial class StockTransaction
    {
        public int StockTranId { get; set; }
        public string TranDate { get; set; }
        public long ProductId { get; set; }
        public Nullable<int> Opening { get; set; }
        public Nullable<int> Purchase { get; set; }
        public Nullable<int> Refund { get; set; }
        public Nullable<int> Sale { get; set; }
        public Nullable<int> Consignment { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Nullable<int> AdjustmentStockIn { get; set; }
        public Nullable<int> AdjustmentStockOut { get; set; }
        public Nullable<int> ConversionStockIn { get; set; }
        public Nullable<int> ConversionStockOut { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
