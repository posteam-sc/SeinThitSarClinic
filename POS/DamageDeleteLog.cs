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
using System.Data.Objects;


namespace POS
{
    public partial class DamageDeleteLog : Form
    {
        #region Variables

        private POSEntities entity = new POSEntities();

        #endregion

        #region Events

        public DamageDeleteLog()
        {
            InitializeComponent();
        }

        private void DamageDeleteLog_Load(object sender, EventArgs e)
        {
            LoadData();
        }
       

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        #endregion

        #region Function
        
        private void LoadData()
        {
            DateTime fromDate = dtFrom.Value.Date;
            DateTime toDate = dtTo.Value.Date;

          
            //List<APP_Data.Damage> mainLog = (from d in entity.Damages
            //                                 join p in entity.Products on d.ProductId equals p.Id
            //                                 where System.Data.Objects.EntityFunctions.TruncateTime((DateTime)d.DeletedDate) >= fromDate && System.Data.Objects.EntityFunctions.TruncateTime((DateTime)d.DeletedDate) <= toDate && d.IsDeleted == true select d).ToList();
            //dgvPurchaseDeleteLog.AutoGenerateColumns = false;
            //dgvPurchaseDeleteLog.DataSource = mainLog;

            //List<APP_Data.PurchaseDeleteLog> partialLog = (from d in entity.PurchaseDeleteLogs where System.Data.Objects.EntityFunctions.TruncateTime((DateTime)d.DeletedDate) >= fromDate && System.Data.Objects.EntityFunctions.TruncateTime((DateTime)d.DeletedDate) <= toDate && d.IsParent != true select d).ToList();
            //dgvPurchaseDeleteLogPartial.AutoGenerateColumns = false;
            //dgvPurchaseDeleteLogPartial.DataSource = partialLog;



            entity = new POSEntities();

            IQueryable<object> q = from d in entity.Damages
                                   join p in entity.Products on d.ProductId equals p.Id
                                   join u in entity.Users on d.DeletedUserId equals u.Id
                                   where d.IsDeleted == true
                                   && (EntityFunctions.TruncateTime((DateTime)d.DamageDateTime) >= fromDate
                                   && EntityFunctions.TruncateTime((DateTime)d.DamageDateTime) <= toDate)
                              
                                   select new
                                   {
                                       DamageId = d.Id,
                                       DeletedDate = d.DeletedDate,
                                       DeletedUser = u.Name,
                                       ProductName = p.Name,
                                       UnitPrice =p.Price,
                                       DamageQty = d.DamageQty,
                                       TotalCost = d.DamageQty * p.Price,
                                       DamageDateTime = d.DamageDateTime,
                                       ResponsibleName = d.ResponsibleName,
                                       Reason = d.Reason
                                   };
            List<object> _damage = new List<object>(q);
            dgvDamageDeleteLog.AutoGenerateColumns = false;
            dgvDamageDeleteLog.DataSource = _damage;
        }
        #endregion

    }
}
