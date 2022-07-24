using System;
using System.Web.UI;

namespace rxApp
{
    public partial class Root : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxMenu1.Visible = Page.User?.Identity.IsAuthenticated == true;
        }
    }
}