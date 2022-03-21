using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using rxApp.Models;
using System;
using System.Linq;
using System.Web;

namespace rxApp.frmAgyliti.GetLock.cnMovimentos
{
    public partial class cnGridExtracoes : System.Web.UI.Page
    {
        private ApplicationDbContext db;
        private ApplicationUserManager userManager;

        public cnGridExtracoes()
        {
            db = new ApplicationDbContext();
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                deStart.Date = DateTime.Now;
                deEnd.Date = DateTime.Now;
            }

            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            object ds;
            var dateIni = new DateTime(deStart.Date.Year, deStart.Date.Month, deStart.Date.Day, 0, 0, 0);
            var dateEnd = new DateTime(deEnd.Date.Year, deEnd.Date.Month, deEnd.Date.Day, 23, 59, 59);

            if (User.IsInRole("User"))
            {
                var user = userManager.FindById(User.Identity.GetUserId());
                var loja = db.GetLockLojas.FirstOrDefault(l => l.id == user.GetLockLojaId);

                var codLoja = loja == null ? null : loja.cod_loja;

                ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "3") && m.cod_loja == codLoja && m.trackCreationTime >= dateIni && m.trackCreationTime <= dateEnd).ToList();
            }
            else
            {
                ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "3") && m.trackCreationTime >= dateIni && m.trackCreationTime <= dateEnd).ToList();
            }

            ASPxGridView1.DataSource = ds;
        }

        protected void ASPxGridView1_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
        {
            decimal b2 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_2"));
            decimal b5 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_5"));
            decimal b10 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_10"));
            decimal b20 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_20"));
            decimal b50 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_50"));
            decimal b100 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_100"));
            decimal b200 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_200"));

            if (e.Column.FieldName == "TotalCount")
            {
                e.Value = b2 + b5 + b10 + b20 + b50 + b100 + b200;
            }

            if (e.Column.FieldName == "TotalValue")
            {
                e.Value = b2 * 2 + b5 * 5 + b10 * 20 + b20 * 20 + b50 * 50 + b100 * 100 + b200 * 200;
            }
        }
    }
}