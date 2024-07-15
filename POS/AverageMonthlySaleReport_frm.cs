﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.APP_Data;

namespace POS
{
    public partial class AverageMonthlySaleReport_frm : Form
    {
        /// <summary>
        /// /aaaaa
        /// </summary>
        public AverageMonthlySaleReport_frm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        #region Variables

        List<AverageMonthlySaleController> avgSaleList = new List<AverageMonthlySaleController>();
        List<APP_Data.Product> productlist = new List<APP_Data.Product>();
        APP_Data.POSEntities entity = new POSEntities();
        Int64 totalAmount = 0;
        decimal totalQty = 0;
        int counterId;
        int brandId;
        string brandName;
        string counterName;
        string year;

        #endregion

        #region Functions


        private void LoadData()
        {
            counterId = 0;
            brandId = 0;
            totalAmount = 0;
            totalQty = 0;
            avgSaleList.Clear();
            counterName = "All-Counter";
            brandName = "All-Brand";
            //dtpFrom.Format = DateTimePickerFormat.Custom;
            //dtpFrom.CustomFormat = "yyyy";



            //DateTime startDate = new DateTime(Convert.ToInt32(year), 7, 1);
            //DateTime endDate = new DateTime(Convert.ToInt32(year) + 1, 6, 30);
            DateTime currentDate = new DateTime(Convert.ToInt32(year), 1, 01);



            if (cboCounter.SelectedIndex > 0)
            {
                counterId = Convert.ToInt32(cboCounter.SelectedValue);
                APP_Data.Counter cbo = entity.Counters.Where(x => x.Id == counterId).FirstOrDefault();
                counterName = cbo.Name.ToString() + "-Counter";
            }
            if (cboBrand.SelectedIndex > 0)
            {
                brandId = Convert.ToInt32(cboBrand.SelectedValue);
                APP_Data.Brand bobj = entity.Brands.Where(x => x.Id == brandId).FirstOrDefault();
                brandName = bobj.Name.ToString() + "-Brand";
            }

            if (brandId == 0 && counterId == 0)
            {
                System.Data.Objects.ObjectResult<AverageMonthlySaleReportByDateTime_Result> resultlist = entity.AverageMonthlySaleReportByDateTime(currentDate);
                foreach (AverageMonthlySaleReportByDateTime_Result r in resultlist)
                {
                    AverageMonthlySaleController avc = new AverageMonthlySaleController();
                    avc.ProductCode = r.PCode.ToString();
                    avc.ProductName = r.PName.ToString();
                    avc.Unit = r.PUnit.ToString();
                    avc.JanQty = Convert.ToInt32(r.January);
                    avc.FebQty = Convert.ToInt32(r.February);
                    avc.MarQty = Convert.ToInt32(r.March);
                    avc.AprQty = Convert.ToInt32(r.April);
                    avc.MayQty = Convert.ToInt32(r.May);
                    avc.JunQty = Convert.ToInt32(r.June);
                    avc.JulQty = Convert.ToInt32(r.July);
                    avc.AugQty = Convert.ToInt32(r.August);
                    avc.SepQty = Convert.ToInt32(r.September);
                    avc.OctQty = Convert.ToInt32(r.October);
                    avc.NovQty = Convert.ToInt32(r.November);
                    avc.DecQty = Convert.ToInt32(r.December);
                    avc.TotalQty = Convert.ToInt32(r.TotalQty);
                    avc.AvgQty = Convert.ToDecimal(r.AvgQty);
                    //avc.SellingPrice = Convert.ToInt64(r.Price);
                    avc.TotalAmount = Convert.ToInt64(r.TotalAmount);
                    avgSaleList.Add(avc);
                }
            }
            else if (brandId > 0 && counterId == 0)
            {
                System.Data.Objects.ObjectResult<AverageMonthlySaleReportBrandId_Result> resultlist = entity.AverageMonthlySaleReportBrandId(currentDate, brandId);
                foreach (AverageMonthlySaleReportBrandId_Result r in resultlist)
                {
                    AverageMonthlySaleController avc = new AverageMonthlySaleController();
                    avc.ProductCode = r.PCode.ToString();
                    avc.ProductName = r.PName.ToString();
                    avc.Unit = r.PUnit.ToString();
                    avc.JanQty = Convert.ToInt32(r.January);
                    avc.FebQty = Convert.ToInt32(r.February);
                    avc.MarQty = Convert.ToInt32(r.March);
                    avc.AprQty = Convert.ToInt32(r.April);
                    avc.MayQty = Convert.ToInt32(r.May);
                    avc.JunQty = Convert.ToInt32(r.June);
                    avc.JulQty = Convert.ToInt32(r.July);
                    avc.AugQty = Convert.ToInt32(r.August);
                    avc.SepQty = Convert.ToInt32(r.September);
                    avc.OctQty = Convert.ToInt32(r.October);
                    avc.NovQty = Convert.ToInt32(r.November);
                    avc.DecQty = Convert.ToInt32(r.December);
                    avc.TotalQty = Convert.ToInt32(r.TotalQty);
                    avc.AvgQty = Convert.ToDecimal(r.AvgQty);
                    //avc.SellingPrice = Convert.ToInt64(r.Price);
                    avc.TotalAmount = Convert.ToInt64(r.TotalAmount);
                    avgSaleList.Add(avc);
                }
            }
            else if (counterId > 0 && brandId == 0)
            {
                System.Data.Objects.ObjectResult<AverageMonthlySaleReportCounterId_Result> resultlist = entity.AverageMonthlySaleReportCounterId(currentDate, counterId);
                foreach (AverageMonthlySaleReportCounterId_Result r in resultlist)
                {
                    AverageMonthlySaleController avc = new AverageMonthlySaleController();
                    avc.ProductCode = r.PCode.ToString();
                    avc.ProductName = r.PName.ToString();
                    avc.Unit = r.PUnit.ToString();
                    avc.JanQty = Convert.ToInt32(r.January);
                    avc.FebQty = Convert.ToInt32(r.February);
                    avc.MarQty = Convert.ToInt32(r.March);
                    avc.AprQty = Convert.ToInt32(r.April);
                    avc.MayQty = Convert.ToInt32(r.May);
                    avc.JunQty = Convert.ToInt32(r.June);
                    avc.JulQty = Convert.ToInt32(r.July);
                    avc.AugQty = Convert.ToInt32(r.August);
                    avc.SepQty = Convert.ToInt32(r.September);
                    avc.OctQty = Convert.ToInt32(r.October);
                    avc.NovQty = Convert.ToInt32(r.November);
                    avc.DecQty = Convert.ToInt32(r.December);
                    avc.TotalQty = Convert.ToInt32(r.TotalQty);
                    avc.AvgQty = Convert.ToDecimal(r.AvgQty);
                    //avc.SellingPrice = Convert.ToInt64(r.Price);
                    avc.TotalAmount = Convert.ToInt64(r.TotalAmount);
                    avgSaleList.Add(avc);
                }
            }
            else if (counterId > 0 && brandId > 0)
            {
                System.Data.Objects.ObjectResult<AverageMonthlySaleReportByBrandIdAndCounterId_Result> resultlist = entity.AverageMonthlySaleReportByBrandIdAndCounterId(currentDate, brandId, counterId);
                foreach (AverageMonthlySaleReportByBrandIdAndCounterId_Result r in resultlist)
                {
                    AverageMonthlySaleController avc = new AverageMonthlySaleController();
                    avc.ProductCode = r.PCode.ToString();
                    avc.ProductName = r.PName.ToString();
                    avc.Unit = r.PUnit.ToString();
                    avc.JanQty = Convert.ToInt32(r.January);
                    avc.FebQty = Convert.ToInt32(r.February);
                    avc.MarQty = Convert.ToInt32(r.March);
                    avc.AprQty = Convert.ToInt32(r.April);
                    avc.MayQty = Convert.ToInt32(r.May);
                    avc.JunQty = Convert.ToInt32(r.June);
                    avc.JulQty = Convert.ToInt32(r.July);
                    avc.AugQty = Convert.ToInt32(r.August);
                    avc.SepQty = Convert.ToInt32(r.September);
                    avc.OctQty = Convert.ToInt32(r.October);
                    avc.NovQty = Convert.ToInt32(r.November);
                    avc.DecQty = Convert.ToInt32(r.December);
                    avc.TotalQty = Convert.ToInt32(r.TotalQty);
                    avc.AvgQty = Convert.ToDecimal(r.AvgQty);
                    //avc.SellingPrice = Convert.ToInt64(r.Price);
                    avc.TotalAmount = Convert.ToInt64(r.TotalAmount);
                    avgSaleList.Add(avc);
                }
            }

            totalAmount = avgSaleList.Sum(x => x.TotalAmount);
            totalQty = avgSaleList.Sum(x => x.TotalQty);

            ShowReportViewer();
        }









        private void ShowReportViewer()
        {
            dsReportTemp dsReport = new dsReportTemp();
            dsReportTemp.AverageMonthlySaleDataTableDataTable dtAvgSale = (dsReportTemp.AverageMonthlySaleDataTableDataTable)dsReport.Tables["AverageMonthlySaleDataTable"];
            foreach (AverageMonthlySaleController avgs in avgSaleList)
            {
                dsReportTemp.AverageMonthlySaleDataTableRow newRow = dtAvgSale.NewAverageMonthlySaleDataTableRow();
                newRow.ProductCode = avgs.ProductCode.ToString();
                newRow.ProductName = avgs.ProductName.ToString();
                newRow.Unit = avgs.Unit.ToString();
                newRow.JanQty = avgs.JanQty.ToString();
                newRow.FebQty = avgs.FebQty.ToString();
                newRow.MarQty = avgs.MarQty.ToString();
                newRow.AprQty = avgs.AprQty.ToString();
                newRow.MayQty = avgs.MayQty.ToString();
                newRow.JunQty = avgs.JunQty.ToString();
                newRow.JulQty = avgs.JulQty.ToString();
                newRow.AugQty = avgs.AugQty.ToString();
                newRow.SepQty = avgs.SepQty.ToString();
                newRow.OctQty = avgs.OctQty.ToString();
                newRow.NovQty = avgs.NovQty.ToString();
                newRow.DecQty = avgs.DecQty.ToString();
                newRow.TotalQty = avgs.TotalQty.ToString();
                newRow.AvgQty = avgs.AvgQty.ToString();
                newRow.TotalAmount = avgs.TotalAmount.ToString();
                newRow.Remark = "-";
                dtAvgSale.AddAverageMonthlySaleDataTableRow(newRow);
            }

            ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["AverageMonthlySaleDataTable"]);
            string reportPath = Application.StartupPath + "\\Reports\\AverageMonthlySaleReport.rdlc";
            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter Header = new ReportParameter("Header", " Average Monthly Sale Report For " + counterName + " and " + brandName + " From Jan-01-" + year + " To Dec-31-" + year);
            reportViewer1.LocalReport.SetParameters(Header);
            ReportParameter TotalAmount = new ReportParameter("TotalAmount", totalAmount.ToString());
            reportViewer1.LocalReport.SetParameters(TotalAmount);
            ReportParameter TotalQty = new ReportParameter("TotalQty", totalQty.ToString());
            reportViewer1.LocalReport.SetParameters(TotalQty);

            reportViewer1.RefreshReport();
        }

        #endregion

        #region Events
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void AverageMonthlySaleReport_frm_Load(object sender, EventArgs e)
        {
            for (int i = 2016; i <= 2030; i++)
            {
                cboYear.Items.Add(i);
            }
            cboYear.SelectedIndex = 0;

            List<APP_Data.Counter> counterlist = new List<APP_Data.Counter>();
            APP_Data.Counter ObjCounter = new APP_Data.Counter();
            ObjCounter.Id = 0;
            ObjCounter.Name = "All";
            counterlist.Add(ObjCounter);
            counterlist.AddRange((from c in entity.Counters select c).ToList());
            cboCounter.DataSource = counterlist;
            cboCounter.DisplayMember = "Name";
            cboCounter.ValueMember = "Id";
            cboCounter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCounter.AutoCompleteSource = AutoCompleteSource.ListItems;

            List<APP_Data.Brand> brandlist = new List<APP_Data.Brand>();
            APP_Data.Brand objBrand = new APP_Data.Brand();
            objBrand.Id = 0;
            objBrand.Name = "All";
            brandlist.Add(objBrand);
            brandlist.AddRange((from c in entity.Brands select c).ToList());
            cboBrand.DataSource = brandlist;
            cboBrand.DisplayMember = "Name";
            cboBrand.ValueMember = "Id";
            cboBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboBrand.AutoCompleteSource = AutoCompleteSource.ListItems;
            // dtpFrom.Value = DateTime.Now;  
            LoadData();
        }

        #endregion

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = cboYear.SelectedItem.ToString();
            LoadData();
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboCounter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
