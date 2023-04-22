using DevExpress.Web;
using MQTTnet;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;
using rxApp.Domain.Entities;
using rxApp.Models;
using rxApp.mqttClient;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace rxApp.frmAgyliti.GetLock.cnCadastros
{
    public partial class cnGridCofreUser : System.Web.UI.Page
    {
        private ApplicationDbContext db;
        private MqttClientHandler mqttClient;

        public cnGridCofreUser()
        {
            db = new ApplicationDbContext();

            this.mqttClient = new MqttClientHandler();
            mqttClient.PublisherStart();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.GetLockCofreUsers.ToList();
        }

        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newCofreUser = new GetLockCofreUser();
            newCofreUser.id_cofre = e.NewValues["id_cofre"]?.ToString();
            newCofreUser.nome = e.NewValues["nome"]?.ToString();
            newCofreUser.data_user = e.NewValues["data_user"]?.ToString();
            newCofreUser.sobrenome = e.NewValues["sobrenome"]?.ToString();
            newCofreUser.enable = Convert.ToBoolean(e.NewValues["enable"]);
            newCofreUser.access_level = e.NewValues["access_level"]?.ToString();
            newCofreUser.passwd = e.NewValues["passwd"]?.ToString();

            db.GetLockCofreUsers.Add(newCofreUser);

            var topic = $"/{newCofreUser.id_cofre}/COMMAND";
            var ackPayload = $@"{{ ""COMMAND"": {{ ""DESTINY"": {newCofreUser.id_cofre}, ""CMD"": {{ ""USER-ADD"": {{ ""ID"": {newCofreUser.data_user}, ""ACCESSLEVEL"": ""{newCofreUser.access_level}"", ""NAME"": ""{newCofreUser.nome}"", ""LASTNAME"": ""{newCofreUser.sobrenome}"", ""PASSWD"": {newCofreUser.passwd} }} }} }} }}";
            var message = new MqttApplicationMessageBuilder().WithTopic(topic).WithPayload(ackPayload).WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce).WithRetainFlag(false).Build();

            if (this.mqttClient.managedMqttClientPublisher != null)
            {
                Task.Run(async () => await mqttClient.managedMqttClientPublisher.PublishAsync(message));
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException f)
            {

                throw;
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var gridKey = (long)Convert.ToInt64(e.Keys["id"]);
            var cofreUser = db.GetLockCofreUsers.FirstOrDefault(l => l.id == gridKey);
            if (cofreUser != null)
            {
                cofreUser.id_cofre = e.NewValues["id_cofre"]?.ToString();
                cofreUser.nome = e.NewValues["nome"]?.ToString();
                cofreUser.data_user = e.NewValues["data_user"]?.ToString();
                cofreUser.sobrenome = e.NewValues["sobrenome"]?.ToString();
                cofreUser.enable = Convert.ToBoolean(e.NewValues["enable"]);
                cofreUser.access_level = e.NewValues["access_level"]?.ToString();
                cofreUser.passwd = e.NewValues["passwd"]?.ToString();

                var topic = $"/{cofreUser.id_cofre}/COMMAND";
                var ackPayload = $@"{{ ""COMMAND"": {{ ""DESTINY"": {cofreUser.id_cofre}, ""CMD"": {{ ""USER-EDIT"": {{ ""ID"": {cofreUser.data_user}, ""ENABLE"": {cofreUser.enable.ToString().ToLower()}, ""ACCESSLEVEL"": ""{cofreUser.access_level}"", ""NAME"": ""{cofreUser.nome}"", ""LASTNAME"": ""{cofreUser.sobrenome}"", ""PASSWD"": {cofreUser.passwd} }} }} }} }}";
                var message = new MqttApplicationMessageBuilder().WithTopic(topic).WithPayload(ackPayload).WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce).WithRetainFlag(false).Build();

                if (this.mqttClient.managedMqttClientPublisher != null)
                {
                    Task.Run(async () => await mqttClient.managedMqttClientPublisher.PublishAsync(message));
                }

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();

        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = (long)Convert.ToInt64(e.Keys["id"]);
            var cofreUser = db.GetLockCofreUsers.FirstOrDefault(l => l.id == gridKey);

            db.GetLockCofreUsers.Remove(cofreUser);

            var topic = $"/{cofreUser.id_cofre}/COMMAND";
            var ackPayload = $@"{{ ""COMMAND"": {{ ""DESTINY"": {cofreUser.id_cofre}, ""CMD"": {{ ""USER-REMOVE"": {{ ""ID"": {cofreUser.data_user} }} }} }} }}";
            var message = new MqttApplicationMessageBuilder().WithTopic(topic).WithPayload(ackPayload).WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce).WithRetainFlag(false).Build();

            if (this.mqttClient.managedMqttClientPublisher != null)
            {
                Task.Run(async () => await mqttClient.managedMqttClientPublisher.PublishAsync(message));
            }

            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

        }

        void AddError(Dictionary<GridViewColumn, string> errors,
             GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }
    }
}