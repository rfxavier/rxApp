﻿using DevExpress.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using rxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rxApp.frmAgyliti.GetLock.cnMovimentos
{
    public partial class cnGridOperacoes : System.Web.UI.Page
    {
        private ApplicationDbContext db;
        private ApplicationUserManager userManager;
        object ds;

        public cnGridOperacoes()
        {
            db = new ApplicationDbContext();
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Create an event handler for the master page's contentCallEvent event
            Master.contentCallEvent += new EventHandler(Page_Load);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            DateTime dateStart;
            DateTime dateEnd;

            if (Session["dateStart"] != null)
            {
                dateStart = (DateTime)Session["dateStart"];
            } else
            {
                dateStart = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);
            }

            if (Session["dateEnd"] != null)
            {
                dateEnd = (DateTime)Session["dateEnd"];
            }
            else
            {
                dateEnd = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);
            }

            if (User.IsInRole("User"))
            {
                var user = userManager.FindById(User.Identity.GetUserId());
                var loja = db.GetLockLojas.FirstOrDefault(l => l.id == user.GetLockLojaId);

                var codLoja = loja == null ? null : loja.cod_loja;

                ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "1" || m.data_type == "2" || m.data_type == "3" || m.data_type == "4"  || m.data_type == "5") &&  m.cod_loja == codLoja && m.data_tmst_end_datetime >= dateStart && m.data_tmst_end_datetime <= dateEnd).ToList();
            }
            else if (User.IsInRole("UserClient"))
            {
                var user = userManager.FindById(User.Identity.GetUserId());
                var cliente = db.GetLockClientes.FirstOrDefault(l => l.id == user.GetLockClienteId);

                var codCliente = cliente == null ? null : cliente.cod_cliente;

                if (Session["selectedLojas"] != null && (Session["dateStart"] != null) && (Session["dateEnd"] != null))
                {
                    var selectedLojas = (List<long>)Session["selectedLojas"];

                    ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "1" || m.data_type == "2" || m.data_type == "3" || m.data_type == "4" || m.data_type == "5") && m.cod_cliente == codCliente && selectedLojas.Contains(m.id_loja) && m.data_tmst_end_datetime >= dateStart && m.data_tmst_end_datetime <= dateEnd).ToList();
                }
                else if (Session["selectedLojas"] != null && (Session["dateStart"] != null) && (Session["dateEnd"] == null))
                {
                    var selectedLojas = (List<long>)Session["selectedLojas"];

                    ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "1" || m.data_type == "2" || m.data_type == "3" || m.data_type == "4" || m.data_type == "5") && m.cod_cliente == codCliente && selectedLojas.Contains(m.id_loja) && m.data_tmst_end_datetime >= dateStart).ToList();
                }
                else if (Session["selectedLojas"] != null && (Session["dateStart"] == null) && (Session["dateEnd"] != null))
                {
                    var selectedLojas = (List<long>)Session["selectedLojas"];

                    ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "1" || m.data_type == "2" || m.data_type == "3" || m.data_type == "4" || m.data_type == "5") && m.cod_cliente == codCliente && selectedLojas.Contains(m.id_loja) && m.data_tmst_end_datetime <= dateEnd).ToList();
                }
                else if (Session["selectedLojas"] == null && (Session["dateStart"] != null) && (Session["dateEnd"] != null))
                {
                    ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "1" || m.data_type == "2" || m.data_type == "3" || m.data_type == "4" || m.data_type == "5") && m.cod_cliente == codCliente && m.data_tmst_end_datetime >= dateStart && m.data_tmst_end_datetime <= dateEnd).ToList();
                }
                else if (Session["selectedLojas"] == null && (Session["dateStart"] != null) && (Session["dateEnd"] == null))
                {
                    ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "1" || m.data_type == "2" || m.data_type == "3" || m.data_type == "4" || m.data_type == "5") && m.cod_cliente == codCliente && m.data_tmst_end_datetime >= dateStart).ToList();
                }
                else if (Session["selectedLojas"] == null && (Session["dateStart"] == null) && (Session["dateEnd"] != null))
                {
                    ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "1" || m.data_type == "2" || m.data_type == "3" || m.data_type == "4" || m.data_type == "5") && m.cod_cliente == codCliente && m.data_tmst_end_datetime <= dateEnd).ToList();
                }
            }
            else
            {
                if (Session["selectedLojas"] != null && (Session["dateStart"] != null) && (Session["dateEnd"] != null))
                {
                    var selectedLojas = (List<long>)Session["selectedLojas"];

                    ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "1" || m.data_type == "2" || m.data_type == "3" || m.data_type == "4"  || m.data_type == "5") && selectedLojas.Contains(m.id_loja) && m.data_tmst_end_datetime >= dateStart && m.data_tmst_end_datetime <= dateEnd).ToList();
                }
                else if (Session["selectedLojas"] != null && (Session["dateStart"] != null) && (Session["dateEnd"] == null))
                {
                    var selectedLojas = (List<long>)Session["selectedLojas"];

                    ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "1" || m.data_type == "2" || m.data_type == "3" || m.data_type == "4"  || m.data_type == "5") && selectedLojas.Contains(m.id_loja) && m.data_tmst_end_datetime >= dateStart).ToList();
                }
                else if (Session["selectedLojas"] != null && (Session["dateStart"] == null) && (Session["dateEnd"] != null))
                {
                    var selectedLojas = (List<long>)Session["selectedLojas"];

                    ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "1" || m.data_type == "2" || m.data_type == "3" || m.data_type == "4"  || m.data_type == "5") && selectedLojas.Contains(m.id_loja) && m.data_tmst_end_datetime <= dateEnd).ToList();
                }
                else if (Session["selectedLojas"] == null && (Session["dateStart"] != null) && (Session["dateEnd"] != null))
                {
                    ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "1" || m.data_type == "2" || m.data_type == "3" || m.data_type == "4"  || m.data_type == "5") && m.data_tmst_end_datetime >= dateStart && m.data_tmst_end_datetime <= dateEnd).ToList();
                }
                else if (Session["selectedLojas"] == null && (Session["dateStart"] != null) && (Session["dateEnd"] == null))
                {
                    ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "1" || m.data_type == "2" || m.data_type == "3" || m.data_type == "4"  || m.data_type == "5") && m.data_tmst_end_datetime >= dateStart).ToList();
                }
                else if (Session["selectedLojas"] == null && (Session["dateStart"] == null) && (Session["dateEnd"] != null))
                {
                    ds = db.GetLockMessageViews.AsNoTracking().Where(m => (m.data_type == "1" || m.data_type == "2" || m.data_type == "3" || m.data_type == "4"  || m.data_type == "5") && m.data_tmst_end_datetime <= dateEnd).ToList();
                }
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
                e.Value = b2 * 2 + b5 * 5 + b10 * 10 + b20 * 20 + b50 * 50 + b100 * 100 + b200 * 200;
            }
        }

        protected void ASPxGridView2_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detailGridView = (ASPxGridView)sender;

            var mainGridId = Convert.ToInt64((sender as ASPxGridView).GetMasterRowKeyValue());
            detailGridView.DataSource = db.GetLockMessageViews.AsNoTracking().Where(x => x.id == mainGridId).ToList();
        }

    }
}