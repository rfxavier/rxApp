<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridMain.aspx.cs" Inherits="rxApp.frmRx.Agyliti.GetLock.cnGridMain.cnGridMain" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v19.1.Web.WebForms, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="EntityServerModeDataSource1" KeyFieldName="id">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="id_cofre" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="nome_ponto_venda" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="id" VisibleIndex="2" ReadOnly="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="info_id" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="info_ip" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="info_mac" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="info_json" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_hash" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_tmst_begin" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_tmst_end" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_user" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_type" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_total" VisibleIndex="12">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_2" VisibleIndex="13">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_5" VisibleIndex="14">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_10" VisibleIndex="15">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_20" VisibleIndex="16">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_50" VisibleIndex="17">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_100" VisibleIndex="18">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_200" VisibleIndex="19">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_rejected" VisibleIndex="20">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_envelope" VisibleIndex="21">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_envelope_total" VisibleIndex="22">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="trackLastWriteTime" VisibleIndex="23">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="trackCreationTime" VisibleIndex="24">
            </dx:GridViewDataDateColumn>
        </Columns>
</dx:ASPxGridView>

    <dx:EntityServerModeDataSource ID="EntityServerModeDataSource1" runat="server" ContextTypeName="rxApp.getlockEntities" TableName="message_cofre" />
</asp:Content>

