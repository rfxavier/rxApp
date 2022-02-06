using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;

namespace rxApp.frmAgyliti.GetLock.cnUsuarios
{
    public partial class cnUsuarios : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;

        public cnUsuarios()
        {
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            GridUsers.DataBind();

        }

        protected void GridUsers_DataBinding(object sender, EventArgs e)
        {
            //var userlist = userManager.Users.ToList();

            //foreach (var user in userlist)
            //{
            //    var b = user.
            //}

            GridUsers.DataSource = userManager.Users.ToList();
        }
    }
}