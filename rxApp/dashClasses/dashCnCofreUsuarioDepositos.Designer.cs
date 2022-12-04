
namespace rxApp.dashClasses
{
    partial class dashCnCofreUsuarioDepositos
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
            DevExpress.DashboardCommon.Measure measure1 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.GridMeasureColumn gridMeasureColumn1 = new DevExpress.DashboardCommon.GridMeasureColumn();
            DevExpress.DashboardCommon.Dimension dimension3 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension4 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension5 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension6 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension7 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Measure measure2 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.SimpleSeries simpleSeries1 = new DevExpress.DashboardCommon.SimpleSeries();
            DevExpress.DashboardCommon.CalculatedField calculatedField1 = new DevExpress.DashboardCommon.CalculatedField();
            DevExpress.DashboardCommon.CalculatedField calculatedField2 = new DevExpress.DashboardCommon.CalculatedField();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashCnCofreUsuarioDepositos));
            DevExpress.DashboardCommon.CalculatedField calculatedField3 = new DevExpress.DashboardCommon.CalculatedField();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup1 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup2 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup3 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem1 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem2 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem3 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem4 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            this.gridDashboardItem1 = new DevExpress.DashboardCommon.GridDashboardItem();
            this.treeViewDashboardItem1 = new DevExpress.DashboardCommon.TreeViewDashboardItem();
            this.comboBoxDashboardItem1 = new DevExpress.DashboardCommon.ComboBoxDashboardItem();
            this.rangeFilterDashboardItem1 = new DevExpress.DashboardCommon.RangeFilterDashboardItem();
            this.dashboardObjectDataSource1 = new DevExpress.DashboardCommon.DashboardObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeFilterDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // gridDashboardItem1
            // 
            dimension1.DataMember = "userName";
            dimension1.Name = "Depositante";
            gridDimensionColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridDimensionColumn1.AddDataItem("Dimension", dimension1);
            dimension2.DataMember = "movimento_nome";
            dimension2.Name = "Tipo";
            gridDimensionColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridDimensionColumn2.AddDataItem("Dimension", dimension2);
            measure1.DataMember = "currencyTotalFinalValue";
            measure1.Name = "Total R$";
            measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number;
            measure1.NumericFormat.IncludeGroupSeparator = true;
            measure1.NumericFormat.Precision = 0;
            measure1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones;
            gridMeasureColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridMeasureColumn1.AddDataItem("Measure", measure1);
            this.gridDashboardItem1.Columns.AddRange(new DevExpress.DashboardCommon.GridColumnBase[] {
            gridDimensionColumn1,
            gridDimensionColumn2,
            gridMeasureColumn1});
            this.gridDashboardItem1.ComponentName = "gridDashboardItem1";
            this.gridDashboardItem1.DataItemRepository.Clear();
            this.gridDashboardItem1.DataItemRepository.Add(dimension1, "DataItem0");
            this.gridDashboardItem1.DataItemRepository.Add(dimension2, "DataItem1");
            this.gridDashboardItem1.DataItemRepository.Add(measure1, "DataItem3");
            this.gridDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.gridDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.gridDashboardItem1.InteractivityOptions.IsDrillDownEnabled = true;
            this.gridDashboardItem1.Name = "Grid 1";
            this.gridDashboardItem1.ShowCaption = false;
            // 
            // treeViewDashboardItem1
            // 
            this.treeViewDashboardItem1.ComponentName = "treeViewDashboardItem1";
            dimension3.DataMember = "nome_rede";
            dimension3.Name = "Rede";
            dimension4.DataMember = "nome_cliente";
            dimension4.Name = "Cliente";
            dimension5.DataMember = "nome_loja";
            dimension5.Name = "Loja";
            this.treeViewDashboardItem1.DataItemRepository.Clear();
            this.treeViewDashboardItem1.DataItemRepository.Add(dimension3, "DataItem0");
            this.treeViewDashboardItem1.DataItemRepository.Add(dimension4, "DataItem1");
            this.treeViewDashboardItem1.DataItemRepository.Add(dimension5, "DataItem2");
            this.treeViewDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.treeViewDashboardItem1.FilterDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension3,
            dimension4,
            dimension5});
            this.treeViewDashboardItem1.InteractivityOptions.IgnoreMasterFilters = true;
            this.treeViewDashboardItem1.Name = "Rede - Cliente - Loja";
            this.treeViewDashboardItem1.ShowCaption = true;
            // 
            // comboBoxDashboardItem1
            // 
            this.comboBoxDashboardItem1.ComponentName = "comboBoxDashboardItem1";
            dimension6.DataMember = "movimento_nome";
            dimension6.Name = "Tipo";
            this.comboBoxDashboardItem1.DataItemRepository.Clear();
            this.comboBoxDashboardItem1.DataItemRepository.Add(dimension6, "DataItem0");
            this.comboBoxDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.comboBoxDashboardItem1.FilterDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension6});
            this.comboBoxDashboardItem1.InteractivityOptions.IgnoreMasterFilters = true;
            this.comboBoxDashboardItem1.Name = "Tipo Depósito";
            this.comboBoxDashboardItem1.ShowCaption = true;
            // 
            // rangeFilterDashboardItem1
            // 
            dimension7.DataMember = "data_tmst_end_datetime";
            dimension7.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DayMonthYear;
            dimension7.Name = "Data";
            this.rangeFilterDashboardItem1.Argument = dimension7;
            this.rangeFilterDashboardItem1.ComponentName = "rangeFilterDashboardItem1";
            measure2.DataMember = "currencyTotalFinalValue";
            measure2.Name = "Total R$";
            this.rangeFilterDashboardItem1.DataItemRepository.Clear();
            this.rangeFilterDashboardItem1.DataItemRepository.Add(measure2, "DataItem0");
            this.rangeFilterDashboardItem1.DataItemRepository.Add(dimension7, "DataItem1");
            this.rangeFilterDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.rangeFilterDashboardItem1.InteractivityOptions.IgnoreMasterFilters = true;
            this.rangeFilterDashboardItem1.Name = "Range Filter 1";
            simpleSeries1.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line;
            simpleSeries1.AddDataItem("Value", measure2);
            this.rangeFilterDashboardItem1.Series.AddRange(new DevExpress.DashboardCommon.SimpleSeries[] {
            simpleSeries1});
            this.rangeFilterDashboardItem1.ShowCaption = false;
            // 
            // dashboardObjectDataSource1
            // 
            calculatedField1.Expression = "[user_name] + \' \' + [user_lastname]";
            calculatedField1.Name = "userName";
            calculatedField2.Expression = resources.GetString("calculatedField2.Expression");
            calculatedField2.Name = "currencyTotal";
            calculatedField3.Expression = "Iif([data_type] = \'2\', [data_currency_total], [currencyTotal])";
            calculatedField3.Name = "currencyTotalFinalValue";
            this.dashboardObjectDataSource1.CalculatedFields.AddRange(new DevExpress.DashboardCommon.CalculatedField[] {
            calculatedField1,
            calculatedField2,
            calculatedField3});
            this.dashboardObjectDataSource1.ComponentName = "dashboardObjectDataSource1";
            this.dashboardObjectDataSource1.DataMember = "GetDepositosMessageViews";
            this.dashboardObjectDataSource1.DataSource = typeof(rxApp.dataObjClasses.dsCofre);
            this.dashboardObjectDataSource1.Name = "Object Data Source 1";
            // 
            // dashCnCofreUsuarioDepositos
            // 
            this.DataSources.AddRange(new DevExpress.DashboardCommon.IDashboardDataSource[] {
            this.dashboardObjectDataSource1});
            this.Items.AddRange(new DevExpress.DashboardCommon.DashboardItem[] {
            this.gridDashboardItem1,
            this.treeViewDashboardItem1,
            this.comboBoxDashboardItem1,
            this.rangeFilterDashboardItem1});
            dashboardLayoutItem1.DashboardItem = this.comboBoxDashboardItem1;
            dashboardLayoutItem1.Weight = 6.0362173038229372D;
            dashboardLayoutItem2.DashboardItem = this.treeViewDashboardItem1;
            dashboardLayoutItem2.Weight = 93.963782696177063D;
            dashboardLayoutGroup3.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem1,
            dashboardLayoutItem2});
            dashboardLayoutGroup3.DashboardItem = null;
            dashboardLayoutGroup3.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical;
            dashboardLayoutGroup3.Weight = 12.577714012434242D;
            dashboardLayoutItem3.DashboardItem = this.gridDashboardItem1;
            dashboardLayoutItem3.Weight = 87.422285987565758D;
            dashboardLayoutGroup2.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutGroup3,
            dashboardLayoutItem3});
            dashboardLayoutGroup2.DashboardItem = null;
            dashboardLayoutGroup2.Weight = 85.837651122625218D;
            dashboardLayoutItem4.DashboardItem = this.rangeFilterDashboardItem1;
            dashboardLayoutItem4.Weight = 14.162348877374784D;
            dashboardLayoutGroup1.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutGroup2,
            dashboardLayoutItem4});
            dashboardLayoutGroup1.DashboardItem = null;
            dashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical;
            dashboardLayoutGroup1.Weight = 100D;
            this.LayoutRoot = dashboardLayoutGroup1;
            this.Title.Text = "Depositantes x Cofres";
            ((System.ComponentModel.ISupportInitialize)(dimension1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeFilterDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DashboardCommon.GridDashboardItem gridDashboardItem1;
        private DevExpress.DashboardCommon.DashboardObjectDataSource dashboardObjectDataSource1;
        private DevExpress.DashboardCommon.TreeViewDashboardItem treeViewDashboardItem1;
        private DevExpress.DashboardCommon.ComboBoxDashboardItem comboBoxDashboardItem1;
        private DevExpress.DashboardCommon.RangeFilterDashboardItem rangeFilterDashboardItem1;
    }
}
