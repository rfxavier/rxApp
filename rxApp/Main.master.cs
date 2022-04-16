using Microsoft.AspNet.Identity.Owin;
using rxApp.Models;
using System;
using System.Linq;
using System.Web;

namespace rxApp
{
    public partial class Main : System.Web.UI.MasterPage
    {
        private ApplicationDbContext db;
        private ApplicationUserManager userManager;
        object ds;

        public Main()
        {
            db = new ApplicationDbContext();
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxTreeList1.DataBind();
        }

        protected void ASPxTreeList1_DataBinding(object sender, EventArgs e)
        {
            ds = db.GetLockLojaClienteRedeViews.AsNoTracking().ToList();
            ASPxTreeList1.DataSource = ds;
        }
    }
}