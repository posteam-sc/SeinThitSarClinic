﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using POS.APP_Data;

namespace POS
{
    public partial class TopSaleReport : Form
    {
        #region Variable

        POSEntities entity = new POSEntities();
        List<TopProductHolder> itemList = new List<TopProductHolder>();
        System.Data.Objects.ObjectResult<Top100SaleItemList_Result> resultList;
        #endregion

        #region Event
        public TopSaleReport()
        {
            InitializeComponent();
        }

        private void TopSaleReport_Load(object sender, EventArgs e)
        {
            txtRow.Text = SettingController.DefaultTopSaleRow.ToString() ;
            LoadData();
            this.reportViewer1.RefreshReport();
        }

        private void rdbQty_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void rdbAmount_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtRow_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region [print]
            dsReportTemp dsReport = new dsReportTemp();
            //dsReportTemp.ItemListDataTable dtItemReport = (dsReportTemp.ItemListDataTable)dsReport.Tables["TopItemList"];
            dsReportTemp.TopItemListDataTable dtItemReport = (dsReportTemp.TopItemListDataTable)dsReport.Tables["TopItemList"];
            foreach (TopProductHolder p in itemList)
            {
                //dsReportTemp.ItemListRow newRow = dtItemReport.NewItemListRow();
                dsReportTemp.TopItemListRow newRow = dtItemReport.NewTopItemListRow();
                newRow.ProductCode = p.ProductId.ToString();
                newRow.ProductName = p.Name.ToString();
                newRow.Discount = p.Discount.ToString();
                newRow.UnitPrice = p.UnitPrice.ToString();
                newRow.Qty = p.Qty.ToString();
                newRow.Amount = p.totalAmount.ToString();
                dtItemReport.AddTopItemListRow(newRow);
                //dtItemReport.AddItemListRow(newRow);
            }

            ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["TopItemList"]);
            string reportPath = Application.StartupPath + "\\Reports\\BestSellersReport.rdlc";
            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter ShopName = new ReportParameter("ShopName", "Best Seller Report for " + SettingController.ShopName);
            reportViewer1.LocalReport.SetParameters(ShopName);

            ReportParameter Date = new ReportParameter("Date", " from " + dtpFrom.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpTo.Value.Date.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(Date);

            ReportParameter RowAmount = new ReportParameter("RowAmount", txtRow.Text.Trim());
            reportViewer1.LocalReport.SetParameters(RowAmount);
            PrintDoc.PrintReport(reportViewer1);
            #endregion
        }

        #endregion

        #region Function

        private void LoadData()
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;
            bool IsAmount = rdbAmount.Checked;
            int totalRow = 0;
            Int32.TryParse(txtRow.Text,out totalRow);
            itemList.Clear();
            
            resultList = entity.Top100SaleItemList(fromDate, toDate, IsAmount, totalRow);
            ////foreach (Top100SaleItemList_Result r in resultList)
            ////{
            ////    TopProductHolder p = new TopProductHolder();
            ////    p.ProductId = r.ItemId.ToString();
            ////    p.Name = r.ItemName;
            ////    p.Discount = r.DisCount;
            ////    p.UnitPrice = Convert.ToInt64(r.UnitPrice);
            ////    p.Qty = Convert.ToInt32(r.ItemQty);
            ////    p.totalAmount = Convert.ToInt64(r.ItemTotalAmount);                
            ////    itemList.Add(p);
            ////}
            ShowReportViewer();
            lblPeriod.Text = fromDate.ToString() + " to " + toDate.ToString();
        }

         private void ShowReportViewer()
        {

            ////dsReportTemp dsReport = new dsReportTemp();
            //////dsReportTemp.ItemListDataTable dtItemReport = (dsReportTemp.ItemListDataTable)dsReport.Tables["TopItemList"];
            //// dsReportTemp.TopItemListDataTable dtItemReport = (dsReportTemp.TopItemListDataTable)dsReport.Tables["TopItemList"];
            ////foreach (TopProductHolder p in itemList)
            ////{
            ////    //dsReportTemp.ItemListRow newRow = dtItemReport.NewItemListRow();
            ////    dsReportTemp.TopItemListRow newRow = dtItemReport.NewTopItemListRow();
            ////    newRow.ProductCode = p.ProductId.ToString();
            ////    newRow.ProductName = p.Name.ToString();
            ////    newRow.Discount = p.Discount.ToString();
            ////    newRow.UnitPrice = p.UnitPrice.ToString();
            ////    newRow.Qty = p.Qty.ToString();
            ////    newRow.Amount = p.totalAmount.ToString();
            ////    dtItemReport.AddTopItemListRow(newRow);
            ////    //dtItemReport.AddItemListRow(newRow);
            ////}


         //   ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["TopItemList"]);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = resultList;

            string reportPath = Application.StartupPath + "\\Reports\\BestSellersReport.rdlc";
            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter ShopName = new ReportParameter("ShopName", "Best Seller Report for " + SettingController.ShopName);
            reportViewer1.LocalReport.SetParameters(ShopName);

            ReportParameter Date = new ReportParameter("Date", " from " + dtpFrom.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpTo.Value.Date.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(Date);            

            ReportParameter RowAmount = new ReportParameter("RowAmount", txtRow.Text.Trim());
            reportViewer1.LocalReport.SetParameters(RowAmount);
            reportViewer1.RefreshReport();
        }

        #endregion                                         

       
    }
}
