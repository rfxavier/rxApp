<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridGetInfo.aspx.cs" Inherits="rxApp.frmAgyliti.GetLock.cnRelatorios.cnGridGetInfo" %>

<%@ Register Assembly="DevExpress.Web.ASPxGauges.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGauges" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxGauges.Gauges" Assembly="DevExpress.Web.ASPxGauges.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxGauges.Gauges.Linear" Assembly="DevExpress.Web.ASPxGauges.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxGauges.Gauges.Circular" Assembly="DevExpress.Web.ASPxGauges.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxGauges.Gauges.State" Assembly="DevExpress.Web.ASPxGauges.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxGauges.Gauges.Digital" Assembly="DevExpress.Web.ASPxGauges.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div><h4>Informações Cofre</h4></div>
    <div style="display: flex">
        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px" NullText="Cofre ID"></dx:ASPxTextBox>
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Solicitar informações" OnClick="ASPxButton1_Click" BackColor="#2A4E70" CssClass="noImage" ForeColor="White"></dx:ASPxButton>
    </div>

    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" KeyFieldName="id" OnAutoFilterCellEditorInitialize="ASPxGridView1_AutoFilterCellEditorInitialize" OnProcessColumnAutoFilter="ASPxGridView1_ProcessColumnAutoFilter">
        <SettingsPager PageSize="20"></SettingsPager>

        <Settings ShowHeaderFilterButton="True" ShowFilterBar="Visible" ShowFilterRow="true" ShowFilterRowMenu="true"></Settings>

        <SettingsCookies Enabled="true" />
        
        <Columns>
            <dx:GridViewDataTextColumn FieldName="TopicDeviceId" Caption="Cofre Id" VisibleIndex="0"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CofreNome" Caption="Cofre Nome" VisibleIndex="1"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="TimestampDatetime" SortIndex="0" SortOrder="Descending" Caption="Data Status" VisibleIndex="2" Settings-FilterMode="Value">
                <CellStyle Wrap="False"></CellStyle>
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="TimestampDatetime" SortIndex="1" Caption="Hora Status" VisibleIndex="3" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" Settings-ShowInFilterControl="False">
                <CellStyle Wrap="False"></CellStyle>
                <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="trackCreationTime" SortIndex="2" SortOrder="Descending" Caption="Data Mensagem" VisibleIndex="4" Settings-FilterMode="Value">
                <CellStyle Wrap="False"></CellStyle>
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="trackCreationTime" SortIndex="3" Caption="Hora Mensagem" VisibleIndex="5" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" Settings-ShowInFilterControl="False">
                <CellStyle Wrap="False"></CellStyle>
                <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="CompanyName" Caption="Nome Empresa" VisibleIndex="6"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CompanyCNPJ" Caption="CNPJ Empresa" VisibleIndex="7"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DeviceSN" Caption="SN Device" VisibleIndex="8"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DeviceFirmVersion" Caption="Versão Firmware Device" VisibleIndex="9"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DeviceBlocked" Caption="Device Bloqueado" VisibleIndex="10"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="BillMachineType" Caption="Tipo Cofre" VisibleIndex="11"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="BillMachineSN" Caption="SN Validador" VisibleIndex="12"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="IsAck" Caption="É Ack" VisibleIndex="13"></dx:GridViewDataTextColumn>
<%--            <dx:GridViewDataTextColumn FieldName="Level" Caption="Level" VisibleIndex="14" Visible="false">
                <Settings AllowDragDrop="False" AllowAutoFilterTextInputTimer="False" AllowAutoFilter="False" ShowFilterRowMenu="False" ShowFilterRowMenuLikeItem="False" AllowHeaderFilter="False" ShowInFilterControl="False" AllowSort="False" AllowGroup="False" AllowFilterBySearchPanel="False"></Settings>
                <DataItemTemplate>
                    <dx:ASPxGaugeControl runat="server" Height="40px" Width="260px" BackColor="White" Value="20" LayoutInterval="6">
                        <Gauges>
                            <dx:LinearGauge Bounds="0, -15, 260, 60" Name="linearGauge11" Orientation="Horizontal">
                                <scales>
                                    <dx:LinearScaleComponent AcceptOrder="0" Appearance-Brush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#4D4D4D&quot;/&gt;" Appearance-Width="4" AppearanceScale-Brush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#4D4D4D&quot;/&gt;" AppearanceScale-Width="4" AppearanceTickmarkText-TextBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#4D4D4D&quot;/&gt;" CustomLogarithmicBase="2" EndPoint="62.5, 20" MajorTickCount="8" MajorTickmark-FormatString="{0:#,#0.00}" MajorTickmark-ShapeOffset="-8" MajorTickmark-ShapeType="Circular_Style28_1" MajorTickmark-TextOffset="-18" MajorTickmark-TextOrientation="BottomToTop" MaxValue="140" MinorTickCount="4" MinorTickmark-ShapeScale="0.5,0.5" MinorTickmark-ShapeOffset="-14" MinorTickmark-ShapeType="Circular_Style28_1" MinorTickmark-ShowTick="False" Name="scale2" StartPoint="62.5, 230" Value="1" MajorTickmark-ShowFirst="False" MajorTickmark-ShowLast="False" AppearanceTickmarkText-Font="Tahoma, 6pt">
                                        <Labels>
                                            <dx:ScaleLabelWeb Name="Label0" Position="50, 90" TextOrientation="Tangent" Text="Level" FormatString="{0}"></dx:ScaleLabelWeb>
                                        </Labels>
                                        <ranges>
                                            <dx:LinearScaleRangeWeb AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#CE8396&quot;/&gt;" EndThickness="7" EndValue="90" Name="Range0" ShapeOffset="1" StartThickness="7" />
                                            <dx:LinearScaleRangeWeb AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#699BC1&quot;/&gt;" EndThickness="7" EndValue="100" Name="Range1" ShapeOffset="1" StartThickness="7" StartValue="90" />
                                            <dx:LinearScaleRangeWeb AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#F5E16B&quot;/&gt;" EndThickness="7" EndValue="105" Name="Range2" ShapeOffset="1" StartThickness="7" StartValue="100" />
                                            <dx:LinearScaleRangeWeb AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#67DD63&quot;/&gt;" EndThickness="7" EndValue="140" Name="Range3" ShapeOffset="1" StartThickness="7" StartValue="105" />
                                        </ranges>
                                    </dx:LinearScaleComponent>
                                </scales>
                                <markers>
                                    <dx:LinearScaleMarkerComponent AcceptOrder="150" LinearScale="" Name="linearGauge11_Marker1" ScaleID="scale2" ZOrder="-150" />
                                </markers>
                            </dx:LinearGauge>
                        </Gauges>
                        <LayoutPadding All="6" Bottom="6" Left="6" Right="6" Top="6" />
                    </dx:ASPxGaugeControl>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>--%>
        </Columns>
        <Toolbars>
            <dx:GridViewToolbar>
                <Items>
                    <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Exportar para Excel"></dx:GridViewToolbarItem>
                    <dx:GridViewToolbarItem Command="ExportToPdf" Text="Exportar para PDF"></dx:GridViewToolbarItem>
                    <dx:GridViewToolbarItem Command="ShowCustomizationWindow" />
                </Items>

                <SettingsAdaptivity Enabled="true" EnableCollapseRootItemsToIcons="true" />
            </dx:GridViewToolbar>
        </Toolbars>
        <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="GetLock-GetInfo" Landscape="true" />
        <SettingsBehavior EnableCustomizationWindow="true" />
        <Styles>
            <AlternatingRow Enabled="True" BackColor="#D6EBFF">
            </AlternatingRow>
        </Styles>
    </dx:ASPxGridView>
</asp:Content>
