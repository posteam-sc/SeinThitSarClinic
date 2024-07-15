using System;
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
using System.Data.Objects;

namespace POS
{
    public partial class DamageRpt : Form
    {
        public DamageRpt()
        {
            InitializeComponent();
        }

        #region variable
        POSEntities entity = new POSEntities();

      // List<object> _damageList = new List<object>();
      List<Damage_Controller> _damageList = new List<Damage_Controller>();
        #endregion

        #region Function
      private void Bind_Brand()
      {
          List<APP_Data.Brand> BrandList = new List<APP_Data.Brand>();
          APP_Data.Brand brandObj1 = new APP_Data.Brand();
          brandObj1.Id = 0;
          brandObj1.Name = "Select";
          //APP_Data.Brand brandObj2 = new APP_Data.Brand();
          //brandObj2.Id = 1;
          //brandObj2.Name = "None";
          BrandList.Add(brandObj1);
          //BrandList.Add(brandObj2);
          BrandList.AddRange((from bList in entity.Brands select bList).ToList());
          cboBrand.DataSource = BrandList;
          cboBrand.DisplayMember = "Name";
          cboBrand.ValueMember = "Id";
          cboBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
          cboBrand.AutoCompleteSource = AutoCompleteSource.ListItems;
      }

      private Char Radio_Status()
      {
          Char _St = '\0';
          if (rdoAll.Checked)
          {
              _St = 'A';
          }
          else if (rdConsignment.Checked)
          {
              _St = 'C';
          }
          else
          {
              _St = 'N';
          }
          return _St;
      }

        public void loadData()
        {
            int _braindId = 0;
            if (cboBrand.SelectedIndex > 0)
            {
                _braindId = Convert.ToInt32(cboBrand.SelectedValue);
            }

            Char _status = Radio_Status();

            DateTime fromDate = dtFrom.Value.Date;
            DateTime toDate = dtTo.Value.Date;

            entity = new POSEntities();

            IQueryable<Damage_Controller> q = from d in entity.Damages
                                   join p in entity.Products on d.ProductId equals p.Id
                                   where d.IsDeleted == false
                                   && (EntityFunctions.TruncateTime((DateTime)d.DamageDateTime) >= fromDate
                                   && EntityFunctions.TruncateTime((DateTime)d.DamageDateTime) <= toDate)
                                   && ((_status == 'A' && 1 == 1) || (_status == 'C' && p.IsConsignment == true) || (_status == 'N' && p.IsConsignment == false))
                                   && ((_braindId==0 && 1==1) || (_braindId !=0 && p.BrandId==_braindId))
                                   select new Damage_Controller
                                   {
                                       Id = d.Id,
                                       ProductCode = p.ProductCode,
                                       ProductName = p.Name,
                                       Price = p.Price,
                                       DamageQty = d.DamageQty,
                                       TotalCost = d.DamageQty * p.Price,
                                       DamageDateTime = d.DamageDateTime,
                                       ResponsibleName = d.ResponsibleName,
                                       Reason = d.Reason
                                   };
            _damageList = new List<Damage_Controller>(q);
            
            ShowReportViewer();
        }

        private void ShowReportViewer()
        {
            string dmgtype = string.Empty;
            dsReportTemp dsReport = new dsReportTemp();
            dsReportTemp.DamageListDataTable dtDmgReport = (dsReportTemp.DamageListDataTable)dsReport.Tables["DamageList"];
            foreach (Damage_Controller dm in _damageList)
            {

                dsReportTemp.DamageListRow newRow = dtDmgReport.NewDamageListRow();
              
                newRow.Name = dm.ProductName;
                newRow.ProductCode = dm.ProductCode;
                newRow.DamageDateTime = Convert.ToDateTime(dm.DamageDateTime);

                if (dm.ResponsibleName != null)
                {
                    newRow.ResponsibleName = dm.ResponsibleName;
                }
                else
                {
                    newRow.ResponsibleName = "-";
                }

                //newRow.UserId = dm.UserName.ToString();
    
                newRow.Reason = dm.Reason.ToString();
                newRow.Price = dm.Price.ToString();
                newRow.Qty = Convert.ToInt32(dm.DamageQty);
                newRow.TotalCost = Convert.ToInt32(dm.TotalCost);
                dtDmgReport.AddDamageListRow(newRow);
            }

            ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["DamageList"]);
            string reportPath = Application.StartupPath + "\\Reports\\Damage.rdlc";

            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            
         
            ReportParameter Header = new ReportParameter("Header", "Damage report for " + dmgtype + " from " + dtFrom.Value.Date.ToString("dd/MM/yyyy") + " To " + dtTo.Value.Date.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(Header);

            reportViewer1.RefreshReport();
        }

        #endregion

        #region 
        private void cboBrand_SelectedValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void rdConsignment_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void DamageRpt_Load(object sender, EventArgs e)
        {
            Bind_Brand();
            loadData();
        }
        #endregion

    }

}
