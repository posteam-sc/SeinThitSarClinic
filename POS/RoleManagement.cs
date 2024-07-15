﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class RoleManagement : Form
    {
        #region Events

        public RoleManagement()
        {
            InitializeComponent();
        }

        private void RoleManagement_Load(object sender, EventArgs e)
        {

            #region Load Data for Super Casher Role
            RoleManagementController controller = new RoleManagementController();
            //Super Casher Id
            controller.Load(2);

            //Setting
            chkSettingSC.Checked = controller.Setting.Add;

            //Consignor
            chkAddConsignorSC.Checked = controller.Consignor.Add;
            chkEditConsignorSC.Checked = controller.Consignor.EditOrDelete;

            //Measurement Unit
            chkAddMeasurementUnitSC.Checked = controller.MeasurementUnit.Add;
            chkEditMeasurementUnitSC.Checked = controller.MeasurementUnit.EditOrDelete;

            //Currency Exhcange
            chkAddCurrencyExchangeSC.Checked = controller.CurrencyExchange.Add;
          

            //Tax Rate
            chkAddTaxRateSC.Checked = controller.TaxRate.Add;
            chkEditTaxRateSC.Checked = controller.TaxRate.EditOrDelete;

            //City
            chkAddCitySC.Checked = controller.City.Add;
            chkEditCitySC.Checked = controller.City.EditOrDelete;

            //Product
            chkViewProductSC.Checked = controller.Product.View;
            chkEditProductSC.Checked = controller.Product.EditOrDelete;
            chkAddProductSC.Checked = controller.Product.Add;

            //Brand
            chkViewBrandSC.Checked = controller.Brand.View;
            chkEditBrandSC.Checked = controller.Brand.EditOrDelete;
            chkAddBrandSC.Checked = controller.Brand.Add;

            //Adjustment
            chkViewAdjustmentSC.Checked = controller.Adjustment.View;
            chkEditDeleteAdjustmentSC.Checked = controller.Adjustment.EditOrDelete;
            chkAddNewAdjustmentSC.Checked = controller.Adjustment.Add;

            //Stock Unit Conversion
            chkViewUConversionSC.Checked = controller.UnitConversion.View;
            chkAddUConversionSC.Checked = controller.UnitConversion.Add;

            //Stock Unit Conversion
            chkViewUConversionSC.Checked = controller.UnitConversion.View;
            chkAddUConversionSC.Checked = controller.UnitConversion.Add;



            //Giftcard
            chkViewGiftcardSC.Checked = controller.GiftCard.View;
            chkAddGiftCardSC.Checked = controller.GiftCard.Add;
            chkDeleteGiftCardSC.Checked = controller.GiftCard.EditOrDelete;

            //Customer
            chkViewCustomerSC.Checked = controller.Customer.View;
            chkEditCustomerSC.Checked = controller.Customer.EditOrDelete;
            chkAddCustomerSC.Checked = controller.Customer.Add;
            chk_customerViewDetail_SC.Checked = controller.Customer.ViewDetail;
            chkOutstandingCusListSC.Checked = controller.OutstandingCustomer.View;
            chkOutstandingCusDetailSC.Checked = controller.OutstandingCustomer.ViewDetail;
           

            //Category
            chkViewCategorySC.Checked = controller.Category.View;
            chkEditCategorySC.Checked = controller.Category.EditOrDelete;
            chkAddCategorySC.Checked = controller.Category.Add;

            //SubCategory
            chkViewSubCategorySC.Checked = controller.SubCategory.View;
            chkEditSubCategorySC.Checked = controller.SubCategory.EditOrDelete;
            chkAddSubCategorySC.Checked = controller.SubCategory.Add;

            //Counter            
            chkEditCounterSC.Checked = controller.Counter.EditOrDelete;
            chkAddCounterSC.Checked = controller.Counter.Add;

            //Supplier
            chkEditSupplierSC.Checked = controller.Supplier.EditOrDelete;
            chkAddSupplierSC.Checked = controller.Supplier.Add;
            chkViewSupplierSC.Checked = controller.Supplier.View;
            chk_ViewDetailVoucher_SC.Checked = controller.Supplier.ViewDetail;
            chkOutstandingSupListSC.Checked = controller.OutstandingSupplier.View;
            chkOutstandingSupDetailSC.Checked = controller.OutstandingSupplier.ViewDetail;

            //Consignment Settlement
            chkViewConsignmentSettlementSC.Checked = controller.ConsigmentSettlement.View;
            chkDeleteConsignmentSettlementSC.Checked = controller.ConsigmentSettlement.EditOrDelete;

            //Member Rule
            chkNewMemberCardSC.Checked = controller.MemberRule.Add;
            chkEditMemberCardSC.Checked = controller.MemberRule.EditOrDelete;


            //Purchasing
            chkPurchaseListSC.Checked = controller.PurchaseRole.View;
            chkPurchaseDetelte_SC.Checked = controller.PurchaseRole.EditOrDelete;
            chkPurchaseDetail_SC.Checked = controller.PurchaseRole.ViewDetail;
            chkAddPurchase_SC.Checked = controller.PurchaseRole.Add;
            chkDeleteLogPurSC.Checked = controller.PurchaseRole.DeleteLog;
            chkApprovedPurSC.Checked = controller.PurchaseRole.Approved;

            //Transaction 
            chkDeleteTransactionSC.Checked = controller.Transaction.EditOrDelete;
            chkDeleteAndCopyTransactionSC.Checked = controller.Transaction.DeleteAndCopy;


            //Credit Transaction 
            chkDeleteCreditTransactionSC.Checked = controller.CreditTransaction.EditOrDelete;
            chkDeleteAndCopyCreditTransactionSC.Checked = controller.CreditTransaction.DeleteAndCopy;


            //Transaction Detail
            chkDeleteTransactionDetailSC.Checked = controller.TransactionDetail.EditOrDelete;

            //Refund
            chkDeleteRefundSC.Checked = controller.Refund.EditOrDelete;

            // Reports
            chkDailySaleSummary_SC1.Checked = controller.DailySaleSummary.View;
            chkTransactionSC1.Checked = controller.TransactionReport.View;
            chkTransactionSummarySC1.Checked = controller.TransactionSummaryReport.View;
            chkTransactionDetail_SC1.Checked = controller.TransactionDetailReport.View;
           // chkDailyTotalTransaction_SC1.Checked = controller.DailyTotalTransactions.View;
            chkPurchasingSC1.Checked = controller.PurchaseReport.View;
            chkPurchasingDiscount_SC1.Checked = controller.PurchaseDiscount.View;
            chkItemSummary_SC1.Checked = controller.ItemSummaryReport.View;
            chkTopBestSellerSC1.Checked = controller.TopBestSellerReport.View;
            chkCustomerSale_SC1.Checked = controller.CustomerSales.View;
            chkOutStandingCustomer_SC1.Checked = controller.OutstandingCustomerReport.View;
            chkTaxSummary_SC1.Checked = controller.TaxSummaryReport.View;
            chkSalebreakdown_SC1.Checked = controller.SaleBreakdown.View;
            chkCustomerInformation_SC1.Checked = controller.CustomerInformation.View;
            chkProductReport_SC1.Checked = controller.ProductReport.View;
            chkReorderReport_C1.Checked = controller.ReorderPointReport.View;
            chkConsigment_SC1.Checked = controller.Consigment.View;
            chkGrossProfit_C1.Checked = controller.ProfitAndLoss.View;
            chkReportAdjustmentSC.Checked = controller.AdjustmentReport.View;

            chkReportSTSC1.Checked = controller.StockTransactionReport.View;
            chkReportAMRSC1.Checked = controller.AverageMonthlyReport.View;
            chkReportAdjustmentSC1.Checked = controller.AdjustmentReport.View;

            #endregion

            #region Load Data for Casher Role

            RoleManagementController controllerCasher = new RoleManagementController();

          

            //Super Casher Id
            controllerCasher.Load(3);

            //Setting
            chkSettingC.Checked = controllerCasher.Setting.Add;

            //Consignor
            chkAddConsignorC.Checked = controllerCasher.Consignor.Add;
            chkEditConsignorC.Checked = controllerCasher.Consignor.EditOrDelete;

            //Measurement Unit
            chkAddMeasurementUnitC.Checked = controllerCasher.MeasurementUnit.Add;
            chkEditMeasurementUnitC.Checked = controllerCasher.MeasurementUnit.EditOrDelete;

            //Currency Exhcange
            chkAddCurrencyExchangeC.Checked = controllerCasher.CurrencyExchange.Add;
          

            //Tax Rate
            chkAddTaxRateC.Checked = controllerCasher.TaxRate.Add;
            chkEditTaxRateC.Checked = controllerCasher.TaxRate.EditOrDelete;

            //City
            chkAddCityC.Checked = controllerCasher.City.Add;
            chkEditCityC.Checked = controllerCasher.City.EditOrDelete;

            //Product
            chkViewProductC.Checked = controllerCasher.Product.View;
            chkEditProductC.Checked = controllerCasher.Product.EditOrDelete;
            chkAddProductC.Checked = controllerCasher.Product.Add;

            //Brand
            chkViewBrandC.Checked = controllerCasher.Brand.View;
            chkEditBrandC.Checked = controllerCasher.Brand.EditOrDelete;
            chkAddBrandC.Checked = controllerCasher.Brand.Add;

            //Adjustment
            chkViewAdjustmentC.Checked = controllerCasher.Adjustment.View;
            chkEditDeleteAdjustmentC.Checked = controllerCasher.Adjustment.EditOrDelete;
            chkAddNewAdjustmentC.Checked = controllerCasher.Adjustment.Add;

            //Stock Unit Conversion
            chkViewUConversionC.Checked = controller.UnitConversion.View;
            chkAddUConversionC.Checked = controller.UnitConversion.Add;

            //Stock Unit Conversion
            chkViewUConversionC.Checked = controllerCasher.UnitConversion.View;
            chkAddUConversionC.Checked = controllerCasher.UnitConversion.Add;

            //Giftcard
            chkViewGiftcardC.Checked = controllerCasher.GiftCard.View;
            chkAddGiftcardC.Checked = controllerCasher.GiftCard.Add;
            chkDeleteGiftCardC.Checked = controllerCasher.GiftCard.EditOrDelete;

            //Customer
            chkViewCustomerC.Checked = controllerCasher.Customer.View;
            chkEditCustomerC.Checked = controllerCasher.Customer.EditOrDelete;
            chkAddCustomerC.Checked = controllerCasher.Customer.Add;
            chk_customerViewDetail_C.Checked = controllerCasher.Customer.ViewDetail;
            chkOutstandingCusListC.Checked = controllerCasher.OutstandingCustomer.View;
            chkOutstandingCusDetailC.Checked = controllerCasher.OutstandingCustomer.ViewDetail;

            //Category
            chkViewCategoryC.Checked = controllerCasher.Category.View;
            chkEditCategoryC.Checked = controllerCasher.Category.EditOrDelete;
            chkAddCategoryC.Checked = controllerCasher.Category.Add;

            //SubCategory
            chkViewSubCategoryC.Checked = controllerCasher.SubCategory.View;
            chkEditSubCategoryC.Checked = controllerCasher.SubCategory.EditOrDelete;
            chkAddSubCategoryC.Checked = controllerCasher.SubCategory.Add;

            //Counter            
            chkEditCounterC.Checked = controllerCasher.Counter.EditOrDelete;
            chkAddCounterC.Checked = controllerCasher.Counter.Add;

            //Supplier
            chkEditSupplierC.Checked = controllerCasher.Supplier.EditOrDelete;
            chkAddSupplierC.Checked = controllerCasher.Supplier.Add;
            chkViewSupplierC.Checked = controllerCasher.Supplier.View;
            chk_ViewDetailVoucher_C.Checked = controllerCasher.Supplier.ViewDetail;
            chkOutstandingSupListC.Checked = controllerCasher.OutstandingSupplier.View;
            chkOutstandingSupDetailC.Checked = controllerCasher.OutstandingSupplier.ViewDetail;

            //Consignor
            chkViewConsignmentSettlementC.Checked = controllerCasher.ConsigmentSettlement.View;
            chkDeleteConsignmentSettlementC.Checked = controllerCasher.ConsigmentSettlement.EditOrDelete;
            //Purchase

            chkPurchaseListC.Checked = controllerCasher.PurchaseRole.View;
            chkPurchaseDetelte_C.Checked = controllerCasher.PurchaseRole.EditOrDelete;
            chkPurcaseDetail_C.Checked = controllerCasher.PurchaseRole.ViewDetail;
            chkAddPurchase_C.Checked = controllerCasher.PurchaseRole.Add;
            chkDeleteLogPurC.Checked = controllerCasher.PurchaseRole.DeleteLog;
            chkApprovedPurC.Checked = controllerCasher.PurchaseRole.Approved;

            //Member Rule
            chkNewMemberCardC.Checked = controllerCasher.MemberRule.Add;
            chkEditMemberCardC.Checked = controllerCasher.MemberRule.EditOrDelete;

            //Transaction 
            chkDeleteTransactionC.Checked = controllerCasher.Transaction.EditOrDelete;
            chkDeleteAndCopyTransactionC.Checked = controllerCasher.Transaction.DeleteAndCopy;

            //Credit Transaction 
            chkDeleteCreditTransactionC.Checked = controllerCasher.CreditTransaction.EditOrDelete;
            chkDeleteAndCopyCreditTransactionC.Checked = controllerCasher.CreditTransaction.DeleteAndCopy;


            //Transaction Detail
            chkDeleteTransactionDetailC.Checked = controllerCasher.TransactionDetail.EditOrDelete;

            //Refund
            chkDeleteRefundC.Checked = controllerCasher.Refund.EditOrDelete;

            //Report
            chkDailySaleSummary_C1.Checked = controllerCasher.DailySaleSummary.View;
            chkTransactionC1.Checked = controllerCasher.TransactionReport.View;
            chkTransactionSummaryC1.Checked = controllerCasher.TransactionSummaryReport.View;
            chkTransactionDetail_C1.Checked = controllerCasher.TransactionDetailReport.View;
            //chkDailyTotalTransaction_C1.Checked = controllerCasher.DailyTotalTransactions.View;
            chkPurchasingC1.Checked = controllerCasher.PurchaseReport.View;
            chkPurchasingDiscount_C1.Checked = controllerCasher.PurchaseDiscount.View;
            chkItemSummary_C1.Checked = controllerCasher.ItemSummaryReport.View;
            chkTopBestSellerC1.Checked = controllerCasher.TopBestSellerReport.View;
            chkCustomerSale_C1.Checked = controllerCasher.CustomerSales.View;
            chkOutStandingCustomer_C1.Checked = controllerCasher.OutstandingCustomerReport.View;
            chkTaxSummary_C1.Checked = controllerCasher.TaxSummaryReport.View;
            chkSalebreakdown_C1.Checked = controllerCasher.SaleBreakdown.View;
            chkCustomerInformation_C1.Checked = controllerCasher.CustomerInformation.View;
            chkProductReport_C1.Checked = controllerCasher.ProductReport.View;
            chkReorderReport_SC1.Checked = controllerCasher.ReorderPointReport.View;
            chkConsigment_SC1.Checked = controllerCasher.Consigment.View;
            chkGrossProfit_SC1.Checked = controllerCasher.ProfitAndLoss.View;
            chkReportAdjustmentC1.Checked = controllerCasher.AdjustmentReport.View;

            chkReportSTC1.Checked = controllerCasher.StockTransactionReport.View;
            chkReportAMRC1.Checked = controllerCasher.AverageMonthlyReport.View;
            chkReportAdjustmentC1.Checked = controllerCasher.AdjustmentReport.View;
            #endregion

            IsAllCheckedOperation(2);
            IsAllCheckedOperation(3);
            IsAllCheckedReport(2);
            IsAllCheckedReport(3);

        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {
            #region Save for Super Casher Role

            RoleManagementController controller = new RoleManagementController();

            //Setting
            controller.Setting.Add = chkSettingSC.Checked;

            //Consignor
            controller.Consignor.EditOrDelete = chkEditConsignorSC.Checked;
            controller.Consignor.Add = chkAddConsignorSC.Checked;

            //Measurement Unit
            controller.MeasurementUnit.EditOrDelete = chkEditMeasurementUnitSC.Checked;
            controller.MeasurementUnit.Add = chkAddMeasurementUnitSC.Checked;

            //Currency Exhcange
            controller.CurrencyExchange.Add = chkAddCurrencyExchangeSC.Checked;

            //Tax Rate
            controller.TaxRate.EditOrDelete = chkEditTaxRateSC.Checked;
            controller.TaxRate.Add = chkAddTaxRateSC.Checked;

            //City
            controller.City.EditOrDelete = chkEditCitySC.Checked;
            controller.City.Add = chkAddCitySC.Checked;

            //Product
            controller.Product.View = chkViewProductSC.Checked;
            controller.Product.EditOrDelete = chkEditProductSC.Checked;
            controller.Product.Add = chkAddProductSC.Checked;

            //Brand
            controller.Brand.View = chkViewBrandSC.Checked;
            controller.Brand.EditOrDelete = chkEditBrandSC.Checked;
            controller.Brand.Add = chkAddBrandSC.Checked;

            //Giftcard
            controller.GiftCard.View = chkViewGiftcardSC.Checked;
            controller.GiftCard.Add = chkAddGiftCardSC.Checked;
            controller.GiftCard.EditOrDelete = chkDeleteGiftCardSC.Checked;

            //Customer
            controller.Customer.View = chkViewCustomerSC.Checked;
            controller.Customer.EditOrDelete = chkEditCustomerSC.Checked;
            controller.Customer.Add = chkAddCustomerSC.Checked;
            controller.OutstandingCustomer.View = chkOutstandingCusListSC.Checked;
            controller.OutstandingCustomer.ViewDetail = chkOutstandingCusDetailSC.Checked;

            //Category
            controller.Category.View = chkViewCategorySC.Checked;
            controller.Category.EditOrDelete = chkEditCategorySC.Checked;
            controller.Category.Add = chkAddCategorySC.Checked;

            //SubCategory
            controller.SubCategory.View = chkViewSubCategorySC.Checked;
            controller.SubCategory.EditOrDelete = chkEditSubCategorySC.Checked;
            controller.SubCategory.Add = chkAddSubCategorySC.Checked;

            //Counter            
            controller.Counter.EditOrDelete = chkEditCounterSC.Checked;
            controller.Counter.Add = chkAddCounterSC.Checked;

            //Supplier
            controller.Supplier.EditOrDelete = chkEditSupplierSC.Checked;
            controller.Supplier.Add = chkAddSupplierSC.Checked;
            controller.Supplier.View = chkViewSupplierSC.Checked;
            controller.Supplier.ViewDetail = chk_ViewDetailVoucher_SC.Checked;
            controller.OutstandingSupplier.View = chkOutstandingSupListSC.Checked;
            controller.OutstandingSupplier.ViewDetail = chkOutstandingSupDetailSC.Checked;

            //Consignment Settlement
            controller.ConsigmentSettlement.View = chkViewConsignmentSettlementSC.Checked;
            controller.ConsigmentSettlement.EditOrDelete = chkDeleteConsignmentSettlementSC.Checked;

            //Purchase
            controller.PurchaseRole.View = chkPurchaseListSC.Checked;
            controller.PurchaseRole.EditOrDelete = chkPurchaseDetelte_SC.Checked;
            controller.PurchaseRole.ViewDetail = chkPurchaseDetail_SC.Checked;
            controller.PurchaseRole.Add = chkAddPurchase_SC.Checked;
            controller.PurchaseRole.DeleteLog = chkDeleteLogPurSC.Checked;
            controller.PurchaseRole.Approved = chkApprovedPurSC.Checked;

            //Member Rule
            controller.MemberRule.Add = chkNewMemberCardSC.Checked;
            controller.MemberRule.EditOrDelete = chkEditMemberCardSC.Checked;

            //Adjustment
            controller.Adjustment.View = chkViewAdjustmentSC.Checked;
            controller.Adjustment.EditOrDelete = chkEditDeleteAdjustmentSC.Checked;
            controller.Adjustment.Add = chkAddNewAdjustmentSC.Checked;

            //Stock Unit Conversion
            controller.UnitConversion.View = chkViewUConversionSC.Checked;
            controller.UnitConversion.Add =chkAddUConversionSC.Checked;

            // Transaction
            controller.Transaction.EditOrDelete = chkDeleteTransactionSC.Checked;
            controller.Transaction.DeleteAndCopy = chkDeleteAndCopyTransactionSC.Checked;

            // Credit Transaction
            controller.CreditTransaction.EditOrDelete = chkDeleteCreditTransactionSC.Checked;
            controller.CreditTransaction.DeleteAndCopy = chkDeleteAndCopyCreditTransactionSC.Checked;

            // Transaction Detial
            controller.TransactionDetail.EditOrDelete = chkDeleteTransactionDetailSC.Checked;

            // Refund
            controller.Refund.EditOrDelete = chkDeleteRefundSC.Checked;

            // Reports
            controller.DailySaleSummary.View = chkDailySaleSummary_SC1.Checked;
            controller.TransactionReport.View = chkTransactionSC1.Checked;
            controller.TransactionSummaryReport.View = chkTransactionSummarySC1.Checked;
            controller.TransactionDetailReport.View = chkTransactionDetail_SC1.Checked;
           // controller.DailyTotalTransactions.View = chkDailyTotalTransaction_SC1.Checked;
            controller.PurchaseReport.View = chkPurchasingSC1.Checked;
            controller.PurchaseDiscount.View = chkPurchasingDiscount_SC1.Checked;
            controller.ItemSummaryReport.View = chkItemSummary_SC1.Checked;
            controller.TopBestSellerReport.View = chkTopBestSellerSC1.Checked;
            controller.CustomerSales.View = chkCustomerSale_SC1.Checked;
            controller.OutstandingCustomerReport.View = chkOutStandingCustomer_SC1.Checked;
            controller.TaxSummaryReport.View = chkTaxSummary_SC1.Checked;
            controller.SaleBreakdown.View = chkSalebreakdown_SC1.Checked;
            controller.CustomerInformation.View = chkCustomerInformation_SC1.Checked;
            controller.ProductReport.View = chkProductReport_SC1.Checked;
            controller.ReorderPointReport.View = chkReorderReport_SC1.Checked;
            controller.Consigment.View = chkConsigment_SC1.Checked;
            controller.ProfitAndLoss.View = chkGrossProfit_SC1.Checked;
            controller.AdjustmentReport.View = chkReportAdjustmentSC1.Checked;

            controller.StockTransactionReport.View = chkReportSTSC1.Checked;
            controller.AverageMonthlyReport.View = chkReportAMRSC1.Checked;



            //Super Casher Id
            controller.Save(2);

            #endregion

            #region Save for Casher Role

            RoleManagementController controllerCasher = new RoleManagementController();
            //Setting
            controllerCasher.Setting.Add = chkSettingC.Checked;

            //Consignor
            controllerCasher.Consignor.EditOrDelete = chkEditConsignorC.Checked;
            controllerCasher.Consignor.Add = chkAddConsignorC.Checked;

            //Measurement Unit
            controllerCasher.MeasurementUnit.EditOrDelete = chkEditMeasurementUnitC.Checked;
            controllerCasher.MeasurementUnit.Add = chkAddMeasurementUnitC.Checked;

            //Currency Exhcange
           
            controllerCasher.CurrencyExchange.Add = chkAddCurrencyExchangeC.Checked;

            //Tax Rate
            controllerCasher.TaxRate.EditOrDelete = chkEditTaxRateC.Checked;
            controllerCasher.TaxRate.Add = chkAddTaxRateC.Checked;

            //City
            controllerCasher.City.EditOrDelete = chkEditCityC.Checked;
            controllerCasher.City.Add = chkAddCityC.Checked;

            //Product
            controllerCasher.Product.View = chkViewProductC.Checked;
            controllerCasher.Product.EditOrDelete = chkEditProductC.Checked;
            controllerCasher.Product.Add = chkAddProductC.Checked;

            //Brand
            controllerCasher.Brand.View = chkViewBrandC.Checked;
            controllerCasher.Brand.EditOrDelete = chkEditBrandC.Checked;
            controllerCasher.Brand.Add = chkAddBrandC.Checked;

            //Giftcard
            controllerCasher.GiftCard.View = chkViewGiftcardC.Checked;
            controllerCasher.GiftCard.Add = chkAddGiftcardC.Checked;
            controllerCasher.GiftCard.EditOrDelete = chkDeleteGiftCardC.Checked;

            //Customer
            controllerCasher.Customer.View = chkViewCustomerC.Checked;
            controllerCasher.Customer.EditOrDelete = chkEditCustomerC.Checked;
            controllerCasher.Customer.Add = chkAddCustomerC.Checked;
            controllerCasher.Customer.ViewDetail = chk_customerViewDetail_C.Checked;
            controllerCasher.OutstandingCustomer.View = chkOutstandingCusListC.Checked;
            controllerCasher.OutstandingCustomer.ViewDetail = chkOutstandingCusDetailC.Checked;

            //Category
            controllerCasher.Category.View = chkViewCategoryC.Checked;
            controllerCasher.Category.EditOrDelete = chkEditCategoryC.Checked;
            controllerCasher.Category.Add = chkAddCategoryC.Checked;

            //SubCategory
            controllerCasher.SubCategory.View = chkViewSubCategoryC.Checked;
            controllerCasher.SubCategory.EditOrDelete = chkEditSubCategoryC.Checked;
            controllerCasher.SubCategory.Add = chkAddSubCategoryC.Checked;

            //Counter            
            controllerCasher.Counter.EditOrDelete = chkEditCounterC.Checked;
            controllerCasher.Counter.Add = chkAddCounterC.Checked;

            //Supplier
            controllerCasher.Supplier.EditOrDelete = chkEditSupplierC.Checked;
            controllerCasher.Supplier.Add = chkAddSupplierC.Checked;
            controllerCasher.Supplier.View = chkViewSupplierC.Checked;
            controllerCasher.Supplier.ViewDetail = chk_ViewDetailVoucher_C.Checked;
            controllerCasher.OutstandingSupplier.View = chkOutstandingSupListC.Checked;
            controllerCasher.OutstandingSupplier.ViewDetail = chkOutstandingSupDetailC.Checked;

            //ConsignmentSettlement
            controllerCasher.ConsigmentSettlement.View = chkViewConsignmentSettlementC.Checked;
            controllerCasher.ConsigmentSettlement.EditOrDelete = chkDeleteConsignmentSettlementC.Checked;

            //Purchase
            controllerCasher.PurchaseRole.View = chkPurchaseListC.Checked;
            controllerCasher.PurchaseRole.EditOrDelete = chkPurchaseDetelte_C.Checked;
            controllerCasher.PurchaseRole.ViewDetail = chkPurcaseDetail_C.Checked;
            controllerCasher.PurchaseRole.Add = chkAddPurchase_C.Checked;
            controllerCasher.PurchaseRole.DeleteLog = chkDeleteLogPurC.Checked;
            controllerCasher.PurchaseRole.Approved = chkApprovedPurC.Checked;

            //Member Rule
            controllerCasher.MemberRule.Add = chkNewMemberCardC.Checked;
            controllerCasher.MemberRule.EditOrDelete = chkEditMemberCardC.Checked;

            //Adjustment
            controllerCasher.Adjustment.View = chkViewAdjustmentC.Checked;
            controllerCasher.Adjustment.EditOrDelete = chkEditDeleteAdjustmentC.Checked;
            controllerCasher.Adjustment.Add = chkAddNewAdjustmentC.Checked;


            //Stock Unit Conversion
            controllerCasher.UnitConversion.View = chkViewUConversionC.Checked;
            controllerCasher.UnitConversion.Add = chkAddUConversionC.Checked;

            // Transaction
            controllerCasher.Transaction.EditOrDelete = chkDeleteTransactionC.Checked;
            controllerCasher.Transaction.DeleteAndCopy = chkDeleteAndCopyTransactionC.Checked;

            // Credit Transaction
            controllerCasher.CreditTransaction.EditOrDelete = chkDeleteCreditTransactionC.Checked;
            controllerCasher.CreditTransaction.DeleteAndCopy = chkDeleteAndCopyCreditTransactionC.Checked;

            // Transaction Detial
            controllerCasher.TransactionDetail.EditOrDelete = chkDeleteTransactionDetailC.Checked;

            // Refund
            controllerCasher.Refund.EditOrDelete = chkDeleteRefundC.Checked;

            //Reports
            controllerCasher.DailySaleSummary.View = chkDailySaleSummary_C1.Checked;
            controllerCasher.TransactionReport.View = chkTransactionC1.Checked;
            controllerCasher.TransactionSummaryReport.View = chkTransactionSummaryC1.Checked;
            controllerCasher.TransactionDetailReport.View = chkTransactionDetail_C1.Checked;
           // controllerCasher.DailyTotalTransactions.View = chkDailyTotalTransaction_C1.Checked;
            controllerCasher.PurchaseReport.View = chkPurchasingC1.Checked;
            controllerCasher.PurchaseDiscount.View = chkPurchasingDiscount_C1.Checked;
            controllerCasher.ItemSummaryReport.View = chkItemSummary_C1.Checked;
            controllerCasher.TopBestSellerReport.View = chkTopBestSellerC1.Checked;
            controllerCasher.CustomerSales.View = chkCustomerSale_C1.Checked;
            controllerCasher.OutstandingCustomerReport.View = chkOutStandingCustomer_C1.Checked;
            controllerCasher.TaxSummaryReport.View = chkTaxSummary_C1.Checked;
            controllerCasher.SaleBreakdown.View = chkSalebreakdown_C1.Checked;
            controllerCasher.CustomerInformation.View = chkCustomerInformation_C1.Checked;
            controllerCasher.ProductReport.View = chkProductReport_C1.Checked;
            controllerCasher.ReorderPointReport.View = chkReorderReport_C1.Checked;
            controllerCasher.Consigment.View = chkConsigment_C1.Checked;
            controllerCasher.ProfitAndLoss.View = chkGrossProfit_C1.Checked;
            controllerCasher.AdjustmentReport.View = chkReportAdjustmentC1.Checked;
            controllerCasher.StockTransactionReport.View = chkReportSTC1.Checked;
            controllerCasher.AverageMonthlyReport.View = chkReportAMRC1.Checked;

            //Casher Id
            controllerCasher.Save(3);

            #endregion

            MessageBox.Show("Saving Complete");
            this.Dispose();
        }

        private void chkSelectAllSC_Click(object sender, EventArgs e)
        {

            #region Setting
            chkSettingSC.Checked =
                       
            #endregion

            #region Consignor
                chkAddConsignorSC.Checked=
                chkEditConsignorSC.Checked=

            #endregion


            #region Measurement Unit
             chkAddMeasurementUnitSC.Checked =
                chkEditMeasurementUnitSC.Checked =

            #endregion

            #region Currency Exchange
            chkAddCurrencyExchangeSC.Checked =
               

            #endregion

            #region Tax Rate
            chkAddTaxRateSC.Checked =
                chkEditTaxRateSC.Checked =

            #endregion

            #region City
                chkAddCitySC.Checked =
                chkEditCitySC.Checked =

            #endregion

            #region Product
 chkViewProductSC.Checked =
            chkEditProductSC.Checked =
            chkAddProductSC.Checked =
            #endregion

            #region Brand
 chkViewBrandSC.Checked =
            chkEditBrandSC.Checked =
            chkAddBrandSC.Checked =
            #endregion

            #region Gift Card
 chkViewGiftcardSC.Checked =
            chkAddGiftCardSC.Checked =
            chkDeleteGiftCardSC.Checked =
            #endregion

            #region Customer
 chkViewCustomerSC.Checked =
            chkEditCustomerSC.Checked =
            chk_customerViewDetail_SC.Checked =
            chkAddCustomerSC.Checked =
            chkOutstandingCusListSC.Checked=
            chkOutstandingCusDetailSC.Checked=
            #endregion

            #region Main Category
 chkViewCategorySC.Checked =
            chkEditCategorySC.Checked =
            chkAddCategorySC.Checked =
            #endregion

            #region Sub Category
 chkViewSubCategorySC.Checked =
            chkEditSubCategorySC.Checked =
            chkAddSubCategorySC.Checked =
            #endregion

            #region Counter
 chkAddCounterSC.Checked =
            chkEditCounterSC.Checked =
            #endregion

            #region Supplier
 chkViewSupplierSC.Checked =
            chkEditSupplierSC.Checked =
            chk_ViewDetailVoucher_SC.Checked =
            chkAddSupplierSC.Checked =
            chkOutstandingSupListSC.Checked=
            chkOutstandingSupDetailSC.Checked=
            #endregion

            #region Consignment Settlement
            chkViewConsignmentSettlementSC.Checked =
            chkDeleteConsignmentSettlementSC.Checked=
            #endregion

            #region Purchasing
             chkPurchaseListSC.Checked =
            chkPurchaseDetelte_SC.Checked =
            chkPurchaseDetail_SC.Checked =
            chkAddPurchase_SC.Checked =
            chkDeleteLogPurSC.Checked=
            chkApprovedPurSC.Checked=
            #endregion

            #region Member Card Rule
 chkNewMemberCardSC.Checked =
            chkEditMemberCardSC.Checked =
            #endregion

            #region Adjustment
 chkViewAdjustmentSC.Checked =
            chkEditDeleteAdjustmentSC.Checked =
            chkAddNewAdjustmentSC.Checked =
            #endregion

            #region Transaction
 chkDeleteTransactionSC.Checked =
            chkDeleteAndCopyTransactionSC.Checked =
            #endregion

            #region Credit Transaction
 chkDeleteCreditTransactionSC.Checked =
            chkDeleteAndCopyCreditTransactionSC.Checked =
            #endregion

            #region Transaction Detail
 chkDeleteTransactionDetailSC.Checked =
            #endregion

            #region Refund
 chkDeleteRefundSC.Checked = chkSelectAllSC.Checked;
            #endregion

            #region UnitConversion
            chkViewUConversionSC.Checked = chkSelectAllSC.Checked;
            chkAddUConversionSC.Checked = chkSelectAllSC.Checked;
            #endregion

        }

        private void chkSelectAllC_Click(object sender, EventArgs e)
        {
            #region Setting
            chkSettingC.Checked =

            #endregion

            #region Consignor
                chkAddConsignorC.Checked =
                chkEditConsignorC.Checked =

            #endregion


            #region Measurement Unit
                chkAddMeasurementUnitC.Checked =
                chkEditMeasurementUnitC.Checked =

            #endregion

            #region Currency Exchange
                chkAddCurrencyExchangeC.Checked =
             
            #endregion

            #region Tax Rate
                chkAddTaxRateC.Checked =
                chkEditTaxRateC.Checked =

            #endregion

            #region City
                chkAddCityC.Checked =
                chkEditCityC.Checked =

            #endregion

            #region Product
            chkViewProductC.Checked =
            chkEditProductC.Checked =
            chkAddProductC.Checked =
            #endregion

            #region Brand
 chkViewBrandC.Checked =
            chkEditBrandC.Checked =
            chkAddBrandC.Checked =
            #endregion

            #region Gift Card
 chkViewGiftcardC.Checked =
            chkAddGiftcardC.Checked =
            chkDeleteGiftCardC.Checked =
            #endregion

            #region Customer
 chkViewCustomerC.Checked =
            chkEditCustomerC.Checked =
            chk_customerViewDetail_C.Checked =
            chkAddCustomerC.Checked =
            chkOutstandingCusListC.Checked=
            chkOutstandingCusDetailC.Checked=
            #endregion

            #region Main Category
 chkViewCategoryC.Checked =
            chkEditCategoryC.Checked =
            chkAddCategoryC.Checked =
            #endregion

            #region Sub Category
 chkViewSubCategoryC.Checked =
            chkEditSubCategoryC.Checked =
            chkAddSubCategoryC.Checked =
            #endregion

            #region Counter
 chkAddCounterC.Checked =
            chkEditCounterC.Checked =
            #endregion

            #region Supplier
 chkViewSupplierC.Checked =
            chkEditSupplierC.Checked =
            chk_ViewDetailVoucher_C.Checked =
            chkAddSupplierC.Checked =
            chkOutstandingSupListC.Checked=
            chkOutstandingSupDetailC.Checked=
            #endregion

            #region Consignment Settlement
            chkViewConsignmentSettlementC.Checked =
            chkDeleteConsignmentSettlementC.Checked =
            #endregion

            #region Purchasing
 chkPurchaseListC.Checked =
            chkPurchaseDetelte_C.Checked =
            chkPurcaseDetail_C.Checked =
            chkAddPurchase_C.Checked =
            chkDeleteLogPurC.Checked=
            chkApprovedPurC.Checked=
            #endregion

            #region Member Card Rule
 chkNewMemberCardC.Checked =
            chkEditMemberCardC.Checked =
            #endregion

            #region Adjustment
 chkViewAdjustmentC.Checked =
            chkEditDeleteAdjustmentC.Checked =
            chkAddNewAdjustmentC.Checked =
            #endregion

            #region Transaction
 chkDeleteTransactionC.Checked =
            chkDeleteAndCopyTransactionC.Checked =
            #endregion

            #region Credit Transaction
 chkDeleteCreditTransactionC.Checked =
            chkDeleteAndCopyCreditTransactionC.Checked =
            #endregion

            #region Transaction Detail
 chkDeleteTransactionDetailC.Checked =
            #endregion

            #region Refund
 chkDeleteRefundC.Checked = chkSelectAllC.Checked;
            #endregion

            #region UnitConversion
            chkViewUConversionC.Checked = chkSelectAllC.Checked;
            chkAddUConversionC.Checked = chkSelectAllC.Checked;
            #endregion
        }

        private void chkSelectAllReportSC_Click(object sender, EventArgs e)
        {
            // Reports
            chkDailySaleSummary_SC1.Checked =
            chkTransactionSC1.Checked =
            chkTransactionSummarySC1.Checked =
            chkTransactionDetail_SC1.Checked =
            //chkDailyTotalTransaction_SC1.Checked =
            chkPurchasingSC1.Checked =
            chkPurchasingDiscount_SC1.Checked =
            chkItemSummary_SC1.Checked =
            chkTopBestSellerSC1.Checked =
            chkCustomerSale_SC1.Checked =
            chkOutStandingCustomer_SC1.Checked =
            chkTaxSummary_SC1.Checked =
            chkSalebreakdown_SC1.Checked =
            chkCustomerInformation_SC1.Checked =
            chkProductReport_SC1.Checked =
            chkReorderReport_SC1.Checked =
            chkConsigment_SC1.Checked =
            chkGrossProfit_SC1.Checked =
            chkReportAdjustmentSC1.Checked =
            chkReportSTSC1.Checked =
            chkReportAMRSC1.Checked = chkSelectAllReportSC.Checked;  
        }

        private void chkSelectAllReportC_Click(object sender, EventArgs e)
        {
            // Reports
            chkDailySaleSummary_C1.Checked =
            chkTransactionC1.Checked =
            chkTransactionSummaryC1.Checked =
            chkTransactionDetail_C1.Checked =
            //chkDailyTotalTransaction_C1.Checked =
            chkPurchasingC1.Checked =
            chkPurchasingDiscount_C1.Checked =
            chkItemSummary_C1.Checked =
            chkTopBestSellerC1.Checked =
            chkCustomerSale_C1.Checked =
            chkOutStandingCustomer_C1.Checked =
            chkTaxSummary_C1.Checked =
            chkSalebreakdown_C1.Checked =
            chkCustomerInformation_C1.Checked =
            chkProductReport_C1.Checked =
            chkReorderReport_C1.Checked =
            chkConsigment_C1.Checked =
            chkGrossProfit_C1.Checked =
            chkReportAdjustmentC1.Checked =
            chkReportSTC1.Checked =
            chkReportAMRC1.Checked = chkSelectAllReportC.Checked;  
        }
        #endregion

        #region Functions
        #region Operation Pannel
        public void IsAllCheckedOperation(int RoleId)
        {
            RoleManagementController controller = new RoleManagementController();
            var RoleAllowanceList = controller.IsAllAllowedForOperation(RoleId);
            bool IsAllTrue = RoleAllowanceList.All(x => x == true);
            bool IsAtLeastOneCheck = RoleAllowanceList.Any(x => x == true);
            // SC
            if (RoleId == 2)
            {
                chkSelectAllSC.Checked = IsAllTrue;
                if (!IsAllTrue && IsAtLeastOneCheck)
                {
                    chkSelectAllSC.CheckState = CheckState.Indeterminate;
                }
            }
            // C
            else if (RoleId == 3)
            {
                chkSelectAllC.Checked = IsAllTrue;
                if (!IsAllTrue && IsAtLeastOneCheck)
                {
                    chkSelectAllC.CheckState = CheckState.Indeterminate;
                }
            }
        }

        private void checkbox_ClickSC(object sender, EventArgs eventArgs)
        {
            var controlList = this.tableLayoutPanel1.Controls.Cast<Control>().Where(c => c.GetType() == typeof(CheckBox) && c.Name.Contains("SC") && c != chkSelectAllSC).ToList();
            controlList.AddRange(this.tableLayoutPanel2.Controls.Cast<Control>().Where(c => c.GetType() == typeof(CheckBox) && c.Name.Contains("SC")).ToList());
            controlList.AddRange(this.tableLayoutPanel4.Controls.Cast<Control>().Where(c => c.GetType() == typeof(CheckBox) && c.Name.Contains("SC")).ToList());
            var checkboxList = controlList.Select(c => c as CheckBox).ToList();


            bool IsAllChecked = checkboxList.All(c => c.Checked);
            bool IsAtLeastOneChecked = checkboxList.Any(c => c.Checked);

            chkSelectAllSC.Checked = IsAllChecked;
            if (!IsAllChecked && IsAtLeastOneChecked)
            {
                chkSelectAllSC.CheckState = CheckState.Indeterminate;
            }
            if (IsAllChecked)
            {
                chkSelectAllSC.CheckState = CheckState.Checked;
            }
        }

        private void checkbox_ClickC(object sender, EventArgs eventArgs)
        {
            var controlList = this.tableLayoutPanel1.Controls.Cast<Control>().Where(c => c.GetType() == typeof(CheckBox) && !c.Name.Contains("SC") && c != chkSelectAllC).ToList();
            controlList.AddRange(this.tableLayoutPanel2.Controls.Cast<Control>().Where(c => c.GetType() == typeof(CheckBox) && !c.Name.Contains("SC")).ToList());
            controlList.AddRange(this.tableLayoutPanel4.Controls.Cast<Control>().Where(c => c.GetType() == typeof(CheckBox) && !c.Name.Contains("SC")).ToList());
            var checkboxList = controlList.Select(c => c as CheckBox).ToList();


            bool IsAllChecked = checkboxList.All(c => c.Checked);
            bool IsAtLeastOneChecked = checkboxList.Any(c => c.Checked);

            chkSelectAllC.Checked = IsAllChecked;
            if (!IsAllChecked && IsAtLeastOneChecked)
            {
                chkSelectAllC.CheckState = CheckState.Indeterminate;
            }
            if (IsAllChecked)
            {
                chkSelectAllC.CheckState = CheckState.Checked;
            }
        }
        #endregion

        #region Report Pannel
         public void IsAllCheckedReport(int RoleId)
        {
            RoleManagementController controller = new RoleManagementController();
            var RoleAllowanceList = controller.IsAllAllowedForReport(RoleId);
            bool IsAllTrue = RoleAllowanceList.All(x => x == true);
            bool IsAtLeastOneCheck = RoleAllowanceList.Any(x => x == true);
            // SC
            if (RoleId == 2)
            {
                chkSelectAllReportSC.Checked = IsAllTrue;
                if (!IsAllTrue && IsAtLeastOneCheck)
                {
                    chkSelectAllReportSC.CheckState = CheckState.Indeterminate;
                }
            }
            // C
            else if (RoleId == 3)
            {
                chkSelectAllReportC.Checked = IsAllTrue;
                if (!IsAllTrue && IsAtLeastOneCheck)
                {
                    chkSelectAllReportC.CheckState = CheckState.Indeterminate;
                }
            }
        }

         private void checkboxReport_ClickSC(object sender, EventArgs eventArgs)
         {
             var controlList = this.tableLayoutPanel3.Controls.Cast<Control>().Where(c => c.GetType() == typeof(CheckBox) && c.Name.Contains("SC")).ToList();
            // controlList.AddRange(this.tableLayoutPanel5.Controls.Cast<Control>().Where(c => c.GetType() == typeof(CheckBox) && c.Name.Contains("SC")).ToList());
             var checkboxList = controlList.Select(c => c as CheckBox).ToList();


             bool IsAllChecked = checkboxList.All(c => c.Checked);
             bool IsAtLeastOneChecked = checkboxList.Any(c => c.Checked);

             chkSelectAllReportSC.Checked = IsAllChecked;
             if (!IsAllChecked && IsAtLeastOneChecked)
             {
                 chkSelectAllReportSC.CheckState = CheckState.Indeterminate;
             }
             if (IsAllChecked)
             {
                 chkSelectAllReportSC.CheckState = CheckState.Checked;
             }
         }

         private void checkboxReport_ClickC(object sender, EventArgs eventArgs)
         {
             var controlList = this.tableLayoutPanel3.Controls.Cast<Control>().Where(c => c.GetType() == typeof(CheckBox) && !c.Name.Contains("SC")).ToList();
            // controlList.AddRange(this.tableLayoutPanel5.Controls.Cast<Control>().Where(c => c.GetType() == typeof(CheckBox) && !c.Name.Contains("SC")).ToList());
             var checkboxList = controlList.Select(c => c as CheckBox).ToList();


             bool IsAllChecked = checkboxList.All(c => c.Checked);
             bool IsAtLeastOneChecked = checkboxList.Any(c => c.Checked);

             chkSelectAllReportC.Checked = IsAllChecked;
             if (!IsAllChecked && IsAtLeastOneChecked)
             {
                 chkSelectAllReportC.CheckState = CheckState.Indeterminate;
             }
             if (IsAllChecked)
             {
                 chkSelectAllReportC.CheckState = CheckState.Checked;
             }
         }
        #endregion

         private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
         {

         }


        #endregion

         private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
         {

         }

         private void label42_Click(object sender, EventArgs e)
         {

         }

         private void chkSelectAllSC_CheckedChanged(object sender, EventArgs e)
         {

         }





    }
}
