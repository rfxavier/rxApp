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
            DevExpress.DashboardCommon.Measure measure1 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.CalculatedField calculatedField1 = new DevExpress.DashboardCommon.CalculatedField();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter1 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DashboardCommon.Dimension dimension2 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Measure measure2 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.Card card1 = new DevExpress.DashboardCommon.Card();
            DevExpress.DashboardCommon.CardStretchedLayoutTemplate cardStretchedLayoutTemplate1 = new DevExpress.DashboardCommon.CardStretchedLayoutTemplate();
            DevExpress.DashboardCommon.Dimension dimension3 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension4 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension5 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension6 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup1 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup2 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem1 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem2 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem3 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardParameter dashboardParameter1 = new DevExpress.DashboardCommon.DashboardParameter();
            this.comboBoxDashboardItem1 = new DevExpress.DashboardCommon.ComboBoxDashboardItem();
            this.dashboardObjectDataSource1 = new DevExpress.DashboardCommon.DashboardObjectDataSource();
            this.treeViewDashboardItem1 = new DevExpress.DashboardCommon.TreeViewDashboardItem();
            this.cardDashboardItem1 = new DevExpress.DashboardCommon.CardDashboardItem();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // comboBoxDashboardItem1
            // 
            this.comboBoxDashboardItem1.ComponentName = "comboBoxDashboardItem1";
            dimension1.DataMember = "commStatus";
            dimension1.Name = "Status comunicação";
            measure1.DataMember = "commStatusCode";
            measure1.SummaryType = DevExpress.DashboardCommon.SummaryType.Min;
            dimension1.SortByMeasure = measure1;
            this.comboBoxDashboardItem1.DataItemRepository.Clear();
            this.comboBoxDashboardItem1.DataItemRepository.Add(dimension1, "DataItem0");
            this.comboBoxDashboardItem1.DataItemRepository.Add(measure1, "DataItem1");
            this.comboBoxDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.comboBoxDashboardItem1.FilterDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension1});
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
            // treeViewDashboardItem1
            // 
            this.treeViewDashboardItem1.ComponentName = "treeViewDashboardItem1";
            dimension2.DataMember = "nome_loja";
            dimension2.Name = "Loja";
            this.treeViewDashboardItem1.DataItemRepository.Clear();
            this.treeViewDashboardItem1.DataItemRepository.Add(dimension2, "DataItem0");
            this.treeViewDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.treeViewDashboardItem1.FilterDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension2});
            this.treeViewDashboardItem1.InteractivityOptions.IgnoreMasterFilters = true;
            this.treeViewDashboardItem1.Name = "Loja";
            this.treeViewDashboardItem1.ShowCaption = true;
            // 
            // cardDashboardItem1
            // 
            measure2.DataMember = "secDiff";
            measure2.SummaryType = DevExpress.DashboardCommon.SummaryType.Count;
            cardStretchedLayoutTemplate1.BottomValue1.DimensionIndex = 0;
            cardStretchedLayoutTemplate1.BottomValue1.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.PercentVariation;
            cardStretchedLayoutTemplate1.BottomValue1.Visible = false;
            cardStretchedLayoutTemplate1.BottomValue2.DimensionIndex = 0;
            cardStretchedLayoutTemplate1.BottomValue2.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.AbsoluteVariation;
            cardStretchedLayoutTemplate1.BottomValue2.Visible = false;
            cardStretchedLayoutTemplate1.DeltaIndicator.Visible = false;
            cardStretchedLayoutTemplate1.MainValue.DimensionIndex = 0;
            cardStretchedLayoutTemplate1.MainValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Title;
            cardStretchedLayoutTemplate1.MainValue.Visible = true;
            cardStretchedLayoutTemplate1.Sparkline.Visible = false;
            cardStretchedLayoutTemplate1.SubValue.DimensionIndex = 0;
            cardStretchedLayoutTemplate1.SubValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Subtitle;
            cardStretchedLayoutTemplate1.SubValue.Visible = false;
            cardStretchedLayoutTemplate1.TopValue.DimensionIndex = 0;
            cardStretchedLayoutTemplate1.TopValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.ActualValue;
            cardStretchedLayoutTemplate1.TopValue.Visible = false;
            card1.LayoutTemplate = cardStretchedLayoutTemplate1;
            card1.AddDataItem("ActualValue", measure2);
            this.cardDashboardItem1.Cards.AddRange(new DevExpress.DashboardCommon.Card[] {
            card1});
            this.cardDashboardItem1.ComponentName = "cardDashboardItem1";
            dimension3.DataMember = "nome_loja";
            dimension4.DataMember = "cofreDesc";
            dimension4.Name = "Cofre";
            dimension5.DataMember = "commRemark";
            dimension5.Name = "Tempo desde última comunicação";
            dimension6.DataMember = "comm_date";
            dimension6.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DateHourMinuteSecond;
            dimension6.Name = "Data última comunicação";
            this.cardDashboardItem1.DataItemRepository.Clear();
            this.cardDashboardItem1.DataItemRepository.Add(dimension3, "DataItem0");
            this.cardDashboardItem1.DataItemRepository.Add(dimension4, "DataItem1");
            this.cardDashboardItem1.DataItemRepository.Add(dimension5, "DataItem2");
            this.cardDashboardItem1.DataItemRepository.Add(dimension6, "DataItem3");
            this.cardDashboardItem1.DataItemRepository.Add(measure2, "DataItem4");
            this.cardDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.cardDashboardItem1.HiddenDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension3});
            this.cardDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.cardDashboardItem1.InteractivityOptions.IsDrillDownEnabled = true;
            this.cardDashboardItem1.Name = "Cofres";
            this.cardDashboardItem1.SeriesDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension4,
            dimension5,
            dimension6});
            this.cardDashboardItem1.ShowCaption = true;
            // 
            // dashCnCofrePorCliente
            // 
            this.DataSources.AddRange(new DevExpress.DashboardCommon.IDashboardDataSource[] {
            this.dashboardObjectDataSource1});
            this.Items.AddRange(new DevExpress.DashboardCommon.DashboardItem[] {
            this.cardDashboardItem1,
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
            dashboardLayoutItem3.DashboardItem = this.cardDashboardItem1;
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
            ((System.ComponentModel.ISupportInitialize)(measure1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DashboardCommon.CardDashboardItem cardDashboardItem1;
        private DevExpress.DashboardCommon.DashboardObjectDataSource dashboardObjectDataSource1;
        private DevExpress.DashboardCommon.TreeViewDashboardItem treeViewDashboardItem1;
        private DevExpress.DashboardCommon.ComboBoxDashboardItem comboBoxDashboardItem1;
    }
}
