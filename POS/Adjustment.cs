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
    
    public partial class Adjustment
    {
        public int Id { get; set; }
        public string ResponsibleName { get; set; }
        public string Reason { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> DeletedUserId { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> AdjustmentDateTime { get; set; }
        public Nullable<long> ProductId { get; set; }
        public Nullable<int> AdjustmentQty { get; set; }
        public int AdjustmentTypeId { get; set; }
    }
}
