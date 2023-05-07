<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridCofreUser.aspx.cs" Inherits="rxApp.frmAgyliti.GetLock.cnCadastros.cnGridCofreUser" %>

<%@ Register Assembly="Microsoft.AspNet.EntityDataSource" Namespace="Microsoft.AspNet.EntityDataSource" TagPrefix="ef" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div><h4>Cadastro Cofre Usuário</h4></div>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="id" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" OnDataBinding="ASPxGridView1_DataBinding" OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserting="ASPxGridView1_RowInserting" OnRowUpdating="ASPxGridView1_RowUpdating" OnRowValidating="ASPxGridView1_RowValidating">
        <SettingsPager PageSize="20"></SettingsPager>
        <SettingsDataSecurity AllowInsert="true" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" ShowInCustomizationForm="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:GridViewCommandColumn>
            <dx:GridViewDataColumn FieldName="id_cofre" Caption="ID Cofre" />
            <dx:GridViewDataColumn FieldName="data_user" Caption="ID Usuário" />
            <dx:GridViewDataColumn FieldName="nome" Caption="Nome" />
            <dx:GridViewDataColumn FieldName="sobrenome" Caption="Sobrenome" />
            <dx:GridViewDataColumn FieldName="enable" Caption="Habilitado" />
            <dx:GridViewDataColumn FieldName="access_level" Caption="Access Level" />
            <dx:GridViewDataColumn FieldName="passwd" Caption="Senha" />
        </Columns>
        <SettingsBehavior ConfirmDelete="True" />
        <SettingsPopup>
            <EditForm Width="600">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" />
            </EditForm>
        </SettingsPopup>
    </dx:ASPxGridView>

    <div><h4>Operações Usuário</h4></div>
    <dx:ASPxGridView ID="ASPxGridView2" runat="server" KeyFieldName="Id" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" OnDataBinding="ASPxGridView2_DataBinding">
        <SettingsPager PageSize="20"></SettingsPager>
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewDataDateColumn FieldName="TimestampDatetime" SortIndex="0" SortOrder="Descending" Caption="Data Operação" VisibleIndex="0" Settings-FilterMode="Value">
                <CellStyle Wrap="False"></CellStyle>
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm:ss">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataColumn FieldName="TopicDeviceId" Caption="ID Cofre" />
            <dx:GridViewDataColumn FieldName="Destiny" Caption="Destiny" />
            <dx:GridViewDataColumn FieldName="Operation" Caption="Operação" />
            <dx:GridViewDataColumn FieldName="UserId" Caption="User ID" />
            <dx:GridViewDataColumn FieldName="Response" Caption="Resp" />
        </Columns>
    </dx:ASPxGridView>

</asp:Content>
