using DevExpress.DashboardWeb;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using rxApp.dashClasses;
using rxApp.dataObjClasses;
using rxApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace rxApp.frmAgyliti.GetLock.cnCofrePorListaCofres
{
    public partial class cnCofrePorListaCofres : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;

        public cnCofrePorListaCofres()
        {
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxDashboard1.DashboardType = typeof(dashCnCofrePorCliente);
        }

        protected void ASPxDashboard1_DataLoading(object sender, DataLoadingWebEventArgs e)
        {
            if (User.IsInRole("UserCofre"))
            {
                var db = new ApplicationDbContext();

                var userId = Page.User.Identity.GetUserId();
                var user = userManager.Users.Include(u => u.GetLockCofres).FirstOrDefault(ul => ul.Id == userId);

                var cofreList = user.GetLockCofres.Select(c => c.id_cofre).ToList();

                e.Data = dsCofre.GetDepositosMessageViewsPorListaCofres((List<string>) cofreList);
            }
        }

        protected void ASPxDashboard1_ConfigureDataReloadingTimeout(object sender, ConfigureDataReloadingTimeoutWebEventArgs e)
        {
            e.DataReloadingTimeout = TimeSpan.FromMinutes(0);
        }
    }
}
