<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutMaster.Master" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="Pages_CRUD.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page_summary" runat="server">

        <div>
            <h2 id="page_title" runat="server"></h2>
        </div>
        <div>
            <h3 id="author_name" runat="server"></h3>
        </div>       
        <div>
            <h4 id="creation_date" runat="server"></h4>
        </div>
        <div>
            <h5 id="page_body" runat="server"></h5>
        </div>
    </div>
    <div id="page_view" runat="server">

    </div>
</asp:Content>
