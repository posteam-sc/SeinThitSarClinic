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
    
    public partial class ProductReportBySCIdAndCIdAndBId_Result
    {
        public long Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Segment_Name { get; set; }
        public string SubSegment_Name { get; set; }
        public string Brand_Name { get; set; }
        public Nullable<int> Qty { get; set; }
        public int PurchasePrice { get; set; }
        public Nullable<bool> IsDiscontinue { get; set; }
        public Nullable<bool> IsConsignment { get; set; }
        public string PhotoPath { get; set; }
    }
}