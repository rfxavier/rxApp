﻿using DevExpress.DashboardWeb;
using rxApp.dashClasses;
using rxApp.dataObjClasses;
using System;

namespace rxApp.frmAgyliti.GetLock.cnCofre
{
    public partial class cnCofre : System.Web.UI.Page
    {
        public cnCofre()
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxDashboard1.DashboardType = typeof(dashCnCofre);
        }

        protected void ASPxDashboard1_DataLoading(object sender, DataLoadingWebEventArgs e)
        {
            e.Data = dsCofre.GetCofreCommStatus();
        }

        protected void ASPxDashboard1_ConfigureDataReloadingTimeout(object sender, ConfigureDataReloadingTimeoutWebEventArgs e)
        {
            e.DataReloadingTimeout = TimeSpan.FromMinutes(60);
        }
    }
}