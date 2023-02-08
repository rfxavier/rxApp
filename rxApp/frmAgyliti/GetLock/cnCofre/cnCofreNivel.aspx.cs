using DevExpress.DashboardWeb;
using rxApp.dashClasses;
using rxApp.dataObjClasses;
using System;

namespace rxApp.frmAgyliti.GetLock.cnCofre
{
    public partial class cnCofreNivel : System.Web.UI.Page
    {
        public cnCofreNivel()
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxDashboard1.DashboardType = typeof(dashCnCofreNivel);
        }

        protected void ASPxDashboard1_DataLoading(object sender, DataLoadingWebEventArgs e)
        {
            e.Data = dsCofre.GetCofreNivel();
        }

        protected void ASPxDashboard1_ConfigureDataReloadingTimeout(object sender, ConfigureDataReloadingTimeoutWebEventArgs e)
        {
            e.DataReloadingTimeout = TimeSpan.FromMinutes(60);
        }

    }
}