using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Web;
using rxApp.Models;
using System;
using System.Globalization;
using System.Linq;

namespace rxApp.frmAgyliti.GetLock.cnRelatorios
{
    public partial class cnGridGetStatus : System.Web.UI.Page
    {
        private ApplicationDbContext db;
        public cnGridGetStatus()
        {
            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            ASPxGridView1.AutoGenerateColumns = false;

            var ds = db.GetLockGetStatusBitProfiles.AsNoTracking().ToList();

            var dsDeviceSensors = ds.Where(d => d.StatusType == "DeviceSensors");
            var dsBillMachineStatus = ds.Where(d => d.StatusType == "BillMachineStatus");
            var dsBillMachineError = ds.Where(d => d.StatusType == "BillMachineError");

            var i = 0;
            foreach (var itemDeviceSensor in dsDeviceSensors)
            {
                GridViewDataTextColumn c = new GridViewDataTextColumn();
                c.FieldName = $"DeviceStatusBit{itemDeviceSensor.Bit}";
                c.Caption = itemDeviceSensor.Caption;
                c.VisibleIndex = i + 7;
                ASPxGridView1.Columns.Add(c);
                i++;
            }

            foreach (var itemBillMachineStatus in dsBillMachineStatus)
            {
                GridViewDataTextColumn c = new GridViewDataTextColumn();
                c.FieldName = $"BillMachineStatusBit{itemBillMachineStatus.Bit}";
                c.Caption = itemBillMachineStatus.Caption;
                c.VisibleIndex = i + 7 + 32;
                ASPxGridView1.Columns.Add(c);
                i++;
            }

            foreach (var itemBillMachineError in dsBillMachineError)
            {
                GridViewDataTextColumn c = new GridViewDataTextColumn();
                c.FieldName = $"DeviceStatusBit{itemBillMachineError.Bit}";
                c.Caption = itemBillMachineError.Caption;
                c.VisibleIndex = i + 7 + 32 + 32;
                ASPxGridView1.Columns.Add(c);
                i++;
            }


            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            //var ds = new EntityServerModeSource { QueryableSource = new ApplicationDbContext().GetLockMessageViews };

            LinqServerModeDataSource lnsource = new LinqServerModeDataSource { ContextTypeName = "rxApp.Models.ApplicationDbContext", TableName = "GetLockMessageAckGetStatuses" };
            lnsource.Selecting += EntityServerModeDataSource1_Selecting;

            ASPxGridView1.DataSource = lnsource;
        }
        string displayText = String.Empty;
        DateTime curDate;
        protected void ASPxGridView1_ProcessColumnAutoFilter(object sender, DevExpress.Web.ASPxGridViewAutoFilterEventArgs e)
        {
            if (e.Column.FieldName != "trackCreationTime")
                return;

            if (e.Kind == DevExpress.Web.GridViewAutoFilterEventKind.CreateCriteria)
                if (DateTime.TryParse(e.Value, CultureInfo.InvariantCulture, DateTimeStyles.None, out curDate))
                {
                    BinaryOperator op1 = new BinaryOperator("trackCreationTime", curDate, BinaryOperatorType.GreaterOrEqual);
                    BinaryOperator op2 = new BinaryOperator("trackCreationTime", curDate.AddMinutes(1), BinaryOperatorType.Less);
                    GroupOperator grOp = new GroupOperator(GroupOperatorType.And, op1, op2);
                    e.Criteria = grOp;
                    displayText = curDate.ToString("dd-MMMM-yyyy hh:mm");
                }

            if (e.Kind == DevExpress.Web.GridViewAutoFilterEventKind.ExtractDisplayText)
                e.Value = displayText;
        }

        protected void ASPxGridView1_AutoFilterCellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "trackCreationTime")
                return;
            ASPxDateEdit ed = e.Editor as ASPxDateEdit;
            ed.TimeSectionProperties.Visible = true;
            ed.TimeSectionProperties.TimeEditProperties.EditFormatString = "hh:mm";
        }

        protected void EntityServerModeDataSource1_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            var db = new ApplicationDbContext();

            e.KeyExpression = "Id";

            e.QueryableSource = db.GetLockMessageAckGetStatuses;
        }
    }
}