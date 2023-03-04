using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Web;
using MQTTnet;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;
using rxApp.Models;
using rxApp.mqttClient;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace rxApp.frmAgyliti.GetLock.cnConfig
{
    public partial class cnGridUpdateFirmware : System.Web.UI.Page
    {
        private MqttClientHandler mqttClient;

        public cnGridUpdateFirmware()
        {
            this.mqttClient = new MqttClientHandler();
            mqttClient.PublisherStart();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            //var ds = new EntityServerModeSource { QueryableSource = new ApplicationDbContext().GetLockMessageViews };

            LinqServerModeDataSource lnsource = new LinqServerModeDataSource { ContextTypeName = "rxApp.Models.ApplicationDbContext", TableName = "GetLockMessageAckUpdateFirmwareViews" };
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

            e.QueryableSource = db.GetLockMessageAckUpdateFirmwareViews;
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            var idCofre = "0";
            if (ASPxTextBoxCofreID.Value != null)
            {
                idCofre = ASPxTextBoxCofreID.Value.ToString();
            }
            var topic = $"/{idCofre}/COMMAND";
            //var ackPayload = $@"{{ ""COMMAND"": {{ ""DESTINY"": {idCofre}, ""CMD"": ""UPDATE-FIRMWARE"": {{ ""FILE"": ""safe_fw_v2.3.0.srec"", ""VERSION"": ""v2.3.0"", ""HASH"": ""1ed0c85d5f78fe9950cdffa9947df80ea2b7f4b638b4370e320f70e820984554"" }} }} }}";
            var ackPayload = $@"{{ ""COMMAND"": {{ ""DESTINY"": {idCofre}, ""CMD"": {{ ""UPDATE-FIRMWARE"": {{ ""FILE"": ""{ASPxTextBoxFilename.Value}"", ""VERSION"": ""{ASPxTextBoxVersion.Value}"", ""HASH"": ""{ASPxTextBoxHash.Value}"" }} }} }} }}";
            var message = new MqttApplicationMessageBuilder().WithTopic(topic).WithPayload(ackPayload).WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce).WithRetainFlag(false).Build();

            if (this.mqttClient.managedMqttClientPublisher != null)
            {
                Task.Run(async () => await mqttClient.managedMqttClientPublisher.PublishAsync(message));
            }
            ASPxTextBoxCofreID.Value = "";
            ASPxTextBoxFilename.Value = "";
            ASPxTextBoxVersion.Value = "";
            ASPxTextBoxHash.Value = "";
            //mqttClient.PublisherStop();
        }
    }
}