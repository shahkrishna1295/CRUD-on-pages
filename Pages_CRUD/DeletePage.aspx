<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutMaster.Master" AutoEventWireup="true" CodeBehind="DeletePage.aspx.cs" Inherits="Pages_CRUD.DeletePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Details of <span id="page_title" runat="server"></span></h2>
    </div>
    <div>
        <label for="author_name">Author name : </label>
        <span id="author_name" runat="server"></span>
    </div>
     <div>
        <label for="creation_date">Creation Date : </label>
        <span id="creation_date" runat="server"></span>
    </div>
    <div>
        <label for="page_body">Page Content</label>
        <span id="page_body" runat="server"></span>
    </div>
   <div id="confirmation">Are you sure you want to delete?</div>
   <asp:button type="button" runat="server" text="Delete" onclick="delete_function" CssClass="delete_button" />
   <asp:button type="button" runat="server" text="Cancel" onclick="cancel_function" CssClass="cancel_button" />

    <div id="pages_result" runat="server">
    </div>
</asp:Content>
