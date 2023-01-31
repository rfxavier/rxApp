<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridGetStatus.aspx.cs" Inherits="rxApp.frmAgyliti.GetLock.cnRelatorios.cnGridGetStatus" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
            <div><h4>Status Cofre</h4></div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" KeyFieldName="id" OnAutoFilterCellEditorInitialize="ASPxGridView1_AutoFilterCellEditorInitialize" OnProcessColumnAutoFilter="ASPxGridView1_ProcessColumnAutoFilter">
                <SettingsPager PageSize="20"></SettingsPager>

                <Settings ShowHeaderFilterButton="True" ShowFilterBar="Visible" ShowFilterRow="true" ShowFilterRowMenu="true"></Settings>

                <SettingsCookies Enabled="true" />
        
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="TopicDeviceId" Caption="Cofre Id" VisibleIndex="0"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="TimestampDatetime" SortIndex="0" SortOrder="Descending" Caption="Data Status" VisibleIndex="1" Settings-FilterMode="Value">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="TimestampDatetime" SortIndex="1" Caption="Hora Status" VisibleIndex="2" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" Settings-ShowInFilterControl="False">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="trackCreationTime" SortIndex="40" SortOrder="Descending" Caption="Data Mensagem" VisibleIndex="3" Settings-FilterMode="Value">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="trackCreationTime" SortIndex="41" Caption="Hora Mensagem" VisibleIndex="4" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" Settings-ShowInFilterControl="False">
                        <CellStyle Wrap="False"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm:ss" EditFormatString="HH:mm:ss">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="DeviceStatusBit0" Caption="PouchNoPresent" VisibleIndex="5"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DeviceStatusBit1" Caption="PouchIsFull" VisibleIndex="6"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DeviceStatusBit2" Caption="DoorLock" VisibleIndex="7"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DeviceStatusBit3" Caption="DoorOpen" VisibleIndex="8"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DeviceStatusBit4" Caption="Tamper" VisibleIndex="9"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DeviceStatusBit5" Caption="Printer disconnected" VisibleIndex="10"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DeviceStatusBit6" Caption="Ethernet cable disconnected" VisibleIndex="11"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DeviceStatusBit7" Caption="Pendrive is disconnected" VisibleIndex="12"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineStatusBit0" Caption="Front door is open" VisibleIndex="13"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineStatusBit1" Caption="Bottom door is open" VisibleIndex="14"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineStatusBit2" Caption="Cash in feeding pocket" VisibleIndex="15"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineStatusBit3" Caption="Cash in reject pocket" VisibleIndex="16"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineStatusBit4" Caption="Reject pocket is full" VisibleIndex="17"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineStatusBit5" Caption="Cash in escrow pocket" VisibleIndex="18"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineStatusBit6" Caption="Escrow pocket is full" VisibleIndex="19"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineStatusBit7" Caption="Flow deposit fail" VisibleIndex="20"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit0" Caption="OnFailure" VisibleIndex="21"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit1" Caption="IsDisconnect" VisibleIndex="22"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit2" Caption="MainMotorError" VisibleIndex="23"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit3" Caption="FeedingMotorError" VisibleIndex="24"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit4" Caption="JammingError" VisibleIndex="25"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit5" Caption="FeedingJammingError" VisibleIndex="26"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit6" Caption="DataCaptureJammingError" VisibleIndex="27"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit7" Caption="U_ChannelJammingError" VisibleIndex="28"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit8" Caption="ExitChannelJammingError" VisibleIndex="29"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit9" Caption="ElectromagnetSwitchError" VisibleIndex="30"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit10" Caption="ExitPocketJammingError" VisibleIndex="31"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit11" Caption="RejectionPocketJamming" VisibleIndex="32"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit12" Caption="UpperCoverLiftingError" VisibleIndex="33"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit13" Caption="CIS_ModuleError" VisibleIndex="34"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit14" Caption="MagnetReadingModuleError" VisibleIndex="35"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit15" Caption="ThicknessMeasurementModuleError" VisibleIndex="36"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit16" Caption="BottomShutterError" VisibleIndex="37"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit17" Caption="ShutterError" VisibleIndex="38"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="BillMachineErrorBit18" Caption="ShutterLockError" VisibleIndex="39"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="UptimeSec" Caption="Uptime" VisibleIndex="40"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="IsAck" Caption="É Ack" VisibleIndex="41"></dx:GridViewDataTextColumn>
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
                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="GetLock-Ocorrencias" Landscape="true" />
                <SettingsBehavior EnableCustomizationWindow="true" />
                <Styles>
                    <AlternatingRow Enabled="True" BackColor="#D6EBFF">
                    </AlternatingRow>
                </Styles>
            </dx:ASPxGridView>
</asp:Content>
