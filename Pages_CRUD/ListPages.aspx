<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutMaster.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="Pages_CRUD.ListPages1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <label>Please enter keyword to search page from page title : </label>
        <asp:TextBox ID="page_search" runat="server"></asp:TextBox>
        <asp:Button runat="server" text="Search" CssClass="search_button"/>
    </div>
    <div>
        <asp:Button runat="server" text="Add Page" OnClick="Add_Page" CssClass="add_button"/>
    </div>
    <div class="table_view" runat="server">
        <div class="listitem">
            <div class="col5">PAGE TITLE</div>
            <div class="col5">PAGE BODY</div>
            <div class="col5">AUTHOR</div>
            <div class="col5">CREATION DATE</div>
            <div class="col5last">Action</div>
        </div>
       <div id="pages_result" runat="server">

        </div>
    </div>
</asp:Content>
