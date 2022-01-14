<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridCofre.aspx.cs" Inherits="rxApp.frmRx.Agyliti.GetLock.cnCadastros.cnGridCofre" %>

<%@ Register Assembly="Microsoft.AspNet.EntityDataSource" Namespace="Microsoft.AspNet.EntityDataSource" TagPrefix="ef" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v19.1.Web.WebForms, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="EntityDataSource1" KeyFieldName="id" Width="100%" EnableRowsCache="False">
        <SettingsDataSecurity AllowInsert="true" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" ShowInCustomizationForm="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:GridViewCommandColumn>
            <dx:GridViewDataColumn FieldName="id_cofre" />
            <dx:GridViewDataColumn FieldName="nome" />
            <dx:GridViewDataColumn FieldName="serie" />
            <dx:GridViewDataColumn FieldName="tipo" />
            <dx:GridViewDataColumn FieldName="marca" />
            <dx:GridViewDataColumn FieldName="modelo" />
            <dx:GridViewDataColumn FieldName="tamanho_malote" />
            <dx:GridViewDataColumn FieldName="cliente" />
            <dx:GridViewDataColumn FieldName="loja" />
        </Columns>
        <SettingsPopup>
            <EditForm Width="600">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" />
            </EditForm>
        </SettingsPopup>
    </dx:ASPxGridView>
    <ef:EntityDataSource ID="EntityDataSource1" runat="server" ContextTypeName="rxApp.getlockEntities" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntitySetName="cofre"></ef:EntityDataSource>
</asp:Content>
