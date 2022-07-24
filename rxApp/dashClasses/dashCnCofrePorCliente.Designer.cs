namespace rxApp.dashClasses
{
    partial class dashCnCofrePorCliente
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.DashboardCommon.Dimension dimension1 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.GridDimensionColumn gridDimensionColumn1 = new DevExpress.DashboardCommon.GridDimensionColumn();
            DevExpress.DashboardCommon.Dimension dimension2 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.GridDimensionColumn gridDimensionColumn2 = new DevExpress.DashboardCommon.GridDimensionColumn();
            DevExpress.DashboardCommon.Dimension dimension3 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.GridDimensionColumn gridDimensionColumn3 = new DevExpress.DashboardCommon.GridDimensionColumn();
            DevExpress.DashboardCommon.Dimension dimension4 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension5 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension6 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Measure measure1 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.CalculatedField calculatedField1 = new DevExpress.DashboardCommon.CalculatedField();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter1 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup1 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup2 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem1 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem2 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem3 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardParameter dashboardParameter1 = new DevExpress.DashboardCommon.DashboardParameter();
            this.gridDashboardItem1 = new DevExpress.DashboardCommon.GridDashboardItem();
            this.treeViewDashboardItem1 = new DevExpress.DashboardCommon.TreeViewDashboardItem();
            this.comboBoxDashboardItem1 = new DevExpress.DashboardCommon.ComboBoxDashboardItem();
            this.dashboardObjectDataSource1 = new DevExpress.DashboardCommon.DashboardObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // gridDashboardItem1
            // 
            dimension1.DataMember = "cofreDesc";
            dimension1.Name = "Cofre";
            gridDimensionColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridDimensionColumn1.AddDataItem("Dimension", dimension1);
            dimension2.DataMember = "commRemark";
            dimension2.Name = "Tempo desde última comunicação";
            gridDimensionColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridDimensionColumn2.AddDataItem("Dimension", dimension2);
            dimension3.DataMember = "comm_date";
            dimension3.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DateHourMinuteSecond;
            dimension3.Name = "Data última comunicação";
            gridDimensionColumn3.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridDimensionColumn3.AddDataItem("Dimension", dimension3);
            this.gridDashboardItem1.Columns.AddRange(new DevExpress.DashboardCommon.GridColumnBase[] {
            gridDimensionColumn1,
            gridDimensionColumn2,
            gridDimensionColumn3});
            this.gridDashboardItem1.ComponentName = "gridDashboardItem1";
            dimension4.DataMember = "nome_loja";
            this.gridDashboardItem1.DataItemRepository.Clear();
            this.gridDashboardItem1.DataItemRepository.Add(dimension4, "DataItem0");
            this.gridDashboardItem1.DataItemRepository.Add(dimension1, "DataItem1");
            this.gridDashboardItem1.DataItemRepository.Add(dimension2, "DataItem2");
            this.gridDashboardItem1.DataItemRepository.Add(dimension3, "DataItem3");
            this.gridDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.gridDashboardItem1.HiddenDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension4});
            this.gridDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.gridDashboardItem1.Name = "Cofres";
            this.gridDashboardItem1.ShowCaption = true;
            // 
            // treeViewDashboardItem1
            // 
            this.treeViewDashboardItem1.ComponentName = "treeViewDashboardItem1";
            dimension5.DataMember = "nome_loja";
            dimension5.Name = "Loja";
            this.treeViewDashboardItem1.DataItemRepository.Clear();
            this.treeViewDashboardItem1.DataItemRepository.Add(dimension5, "DataItem0");
            this.treeViewDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.treeViewDashboardItem1.FilterDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension5});
            this.treeViewDashboardItem1.InteractivityOptions.IgnoreMasterFilters = true;
            this.treeViewDashboardItem1.Name = "Loja";
            this.treeViewDashboardItem1.ShowCaption = true;
            // 
            // comboBoxDashboardItem1
            // 
            this.comboBoxDashboardItem1.ComponentName = "comboBoxDashboardItem1";
            dimension6.DataMember = "commStatus";
            dimension6.Name = "Status comunicação";
            measure1.DataMember = "commStatusCode";
            measure1.SummaryType = DevExpress.DashboardCommon.SummaryType.Min;
            dimension6.SortByMeasure = measure1;
            this.comboBoxDashboardItem1.DataItemRepository.Clear();
            this.comboBoxDashboardItem1.DataItemRepository.Add(dimension6, "DataItem0");
            this.comboBoxDashboardItem1.DataItemRepository.Add(measure1, "DataItem1");
            this.comboBoxDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.comboBoxDashboardItem1.FilterDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension6});
            this.comboBoxDashboardItem1.HiddenMeasures.AddRange(new DevExpress.DashboardCommon.Measure[] {
            measure1});
            this.comboBoxDashboardItem1.InteractivityOptions.IgnoreMasterFilters = true;
            this.comboBoxDashboardItem1.Name = "Sem Comunicação";
            this.comboBoxDashboardItem1.ShowCaption = true;
            // 
            // dashboardObjectDataSource1
            // 
            calculatedField1.Expression = "Concat([id_cofre], \' - \', Iif([cofre_nome] Is Null, \'\', [cofre_nome]))";
            calculatedField1.Name = "cofreDesc";
            this.dashboardObjectDataSource1.CalculatedFields.AddRange(new DevExpress.DashboardCommon.CalculatedField[] {
            calculatedField1});
            this.dashboardObjectDataSource1.ComponentName = "dashboardObjectDataSource1";
            this.dashboardObjectDataSource1.DataMember = "GetCofreCommStatusPorCliente";
            this.dashboardObjectDataSource1.DataSource = typeof(rxApp.dataObjClasses.dsCofre);
            this.dashboardObjectDataSource1.Name = "Object Data Source 1";
            parameter1.Name = "clienteId";
            parameter1.Type = typeof(DevExpress.DataAccess.Expression);
            parameter1.Value = new DevExpress.DataAccess.Expression("?dashParClienteId", typeof(long));
            this.dashboardObjectDataSource1.Parameters.AddRange(new DevExpress.DataAccess.ObjectBinding.Parameter[] {
            parameter1});
            // 
            // dashCnCofrePorCliente
            // 
            this.DataSources.AddRange(new DevExpress.DashboardCommon.IDashboardDataSource[] {
            this.dashboardObjectDataSource1});
            this.Items.AddRange(new DevExpress.DashboardCommon.DashboardItem[] {
            this.gridDashboardItem1,
            this.treeViewDashboardItem1,
            this.comboBoxDashboardItem1});
            dashboardLayoutItem1.DashboardItem = this.comboBoxDashboardItem1;
            dashboardLayoutItem1.Weight = 5.1383399209486162D;
            dashboardLayoutItem2.DashboardItem = this.treeViewDashboardItem1;
            dashboardLayoutItem2.Weight = 94.86166007905139D;
            dashboardLayoutGroup2.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem1,
            dashboardLayoutItem2});
            dashboardLayoutGroup2.DashboardItem = null;
            dashboardLayoutGroup2.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical;
            dashboardLayoutGroup2.Weight = 15.294117647058824D;
            dashboardLayoutItem3.DashboardItem = this.gridDashboardItem1;
            dashboardLayoutItem3.Weight = 84.705882352941174D;
            dashboardLayoutGroup1.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutGroup2,
            dashboardLayoutItem3});
            dashboardLayoutGroup1.DashboardItem = null;
            dashboardLayoutGroup1.Weight = 100D;
            this.LayoutRoot = dashboardLayoutGroup1;
            dashboardParameter1.Name = "dashParClienteId";
            dashboardParameter1.Type = typeof(long);
            dashboardParameter1.Value = ((long)(3));
            dashboardParameter1.Visible = false;
            this.Parameters.AddRange(new DevExpress.DashboardCommon.DashboardParameter[] {
            dashboardParameter1});
            this.Title.Text = "Cofres - Status Comunicação";
            ((System.ComponentModel.ISupportInitialize)(dimension1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DashboardCommon.GridDashboardItem gridDashboardItem1;
        private DevExpress.DashboardCommon.DashboardObjectDataSource dashboardObjectDataSource1;
        private DevExpress.DashboardCommon.TreeViewDashboardItem treeViewDashboardItem1;
        private DevExpress.DashboardCommon.ComboBoxDashboardItem comboBoxDashboardItem1;
    }
}
