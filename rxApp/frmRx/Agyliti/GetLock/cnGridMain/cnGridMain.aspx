<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="cnGridMain.aspx.cs" Inherits="rxApp.frmRx.Agyliti.GetLock.cnGridMain.cnGridMain" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v19.1.Web.WebForms, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="EntityServerModeDataSource1" KeyFieldName="id">
        <Settings ShowHeaderFilterButton="True"></Settings>

        <Columns>
            <dx:GridViewDataTextColumn FieldName="id_cofre" Caption="ID Cofre" VisibleIndex="0"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="cofre_nome" Caption="Nome Cofre" VisibleIndex="1"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="cofre_serie" Caption="S&#233;rie Cofre" VisibleIndex="2"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="cofre_tipo" Caption="Tipo Cofre" VisibleIndex="3"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="cofre_marca" Caption="Marca Cofre" VisibleIndex="4"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="cofre_modelo" Caption="Modelo Cofre" VisibleIndex="5"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="cofre_tamanho_malote" Caption="Tamanho Malote Cofre" VisibleIndex="6"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="cofre_cliente" Caption="Cliente" VisibleIndex="7"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="cofre_loja" Caption="Loja" VisibleIndex="8"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="info_id" Caption="ID &#218;nico Cofre" VisibleIndex="9"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="info_ip" Caption="IP" VisibleIndex="10"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="info_mac" Caption="Mac" VisibleIndex="11"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="info_json" Caption="Json" VisibleIndex="12"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_hash" Caption="Hash" VisibleIndex="13"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_tmst_begin" Caption="Timestamp Inicial" VisibleIndex="14"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_tmst_end" Caption="Timestamp Final" VisibleIndex="15"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_user" Caption="Usu&#225;rio" VisibleIndex="16"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="user_nome" Caption="Usu&#225;rio Nome" VisibleIndex="17"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_type" Caption="Movimento" VisibleIndex="18"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="movimento_nome" Caption="Movimento Nome" VisibleIndex="19"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="movimento_tipo" Caption="Movimento Tipo" VisibleIndex="20"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_total" Caption="Valor Total" VisibleIndex="21"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_2" Caption="C&#233;dula R$ 2" VisibleIndex="22"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_5" Caption="C&#233;dula R$ 5" VisibleIndex="23"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_10" Caption="C&#233;dula R$ 10" VisibleIndex="24"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_20" Caption="C&#233;dula R$ 20" VisibleIndex="25"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_50" Caption="C&#233;dula R$ 50" VisibleIndex="26"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_100" Caption="C&#233;dula R$ 100" VisibleIndex="27"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_200" Caption="C&#233;dula R$ 200" VisibleIndex="28"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_bill_rejected" Caption="C&#233;dula Rejeitada" VisibleIndex="29"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_envelope" Caption="Envelope" VisibleIndex="30"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="data_currency_envelope_total" Caption="Envelope Valor Total" VisibleIndex="31"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="trackCreationTime" SortIndex="0" SortOrder="Descending" Caption="Data Hora" VisibleIndex="32">
                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataTextColumn>
        </Columns>
        <Toolbars>
            <dx:GridViewToolbar>
                <Items>
                    <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Exportar para Excel"></dx:GridViewToolbarItem>
                </Items>

                <SettingsAdaptivity Enabled="true" EnableCollapseRootItemsToIcons="true" />
            </dx:GridViewToolbar>
        </Toolbars>
        <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="Agyliti-GetLock-Ocorrencias" />
</dx:ASPxGridView>

    <dx:EntityServerModeDataSource ID="EntityServerModeDataSource1" runat="server" ContextTypeName="rxApp.getlockEntities" TableName="message_view" />
</asp:Content>

