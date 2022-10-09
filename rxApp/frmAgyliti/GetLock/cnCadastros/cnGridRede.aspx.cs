using rxApp.Domain.Entities;
using rxApp.Models;
using System;

namespace rxApp.frmAgyliti.GetLock.cnCadastros
{
    public partial class cnGridRede : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridRede()
        {
            db = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            var newRede = new GetLockRede();

            newRede.cod_rede = e.NewValues["cod_rede"] == null ? Guid.NewGuid().ToString() : e.NewValues["cod_rede"]?.ToString();
            newRede.nome = e.NewValues["nome"]?.ToString();

            db.GetLockRedes.Add(newRede);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

    }
}