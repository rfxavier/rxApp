<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnUsuarios.aspx.cs" Inherits="rxApp.frmAgyliti.GetLock.cnUsuarios.cnUsuarios" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxGridView ID="GridUsers" runat="server" AutoGenerateColumns="False" OnDataBinding="GridUsers_DataBinding">
        <Columns>
            <dx:GridViewDataTextColumn Caption="Id" FieldName="Id" Name="Id" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Usuário" FieldName="UserName" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
</asp:Content>
