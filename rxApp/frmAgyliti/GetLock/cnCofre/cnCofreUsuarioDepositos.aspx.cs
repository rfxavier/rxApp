using DevExpress.DashboardWeb;
using rxApp.dashClasses;
using rxApp.dataObjClasses;
using System;

namespace rxApp.frmAgyliti.GetLock.cnCofre
{
    public partial class cnCofreUsuarioDepositos : System.Web.UI.Page
    {
        public cnCofreUsuarioDepositos()
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxDashboard1.DashboardType = typeof(dashCnCofreUsuarioDepositos);
        }

        protected void ASPxDashboard1_DataLoading(object sender, DataLoadingWebEventArgs e)
        {
            e.Data = dsCofre.GetDepositosMessageViews();
        }

        protected void ASPxDashboard1_ConfigureDataReloadingTimeout(object sender, ConfigureDataReloadingTimeoutWebEventArgs e)
        {
            e.DataReloadingTimeout = TimeSpan.FromMinutes(60);
        }

    }
}