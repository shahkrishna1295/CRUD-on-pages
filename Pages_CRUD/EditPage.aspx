<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutMaster.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="Pages_CRUD.EditPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label runat="server">Page Title : </asp:Label>
        <asp:TextBox runat="server" ID="pagetitle_input"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" EnableClientScript="True" ErrorMessage="Please input title." ControlToValidate="pagetitle_input"></asp:RequiredFieldValidator>
    </div>

    <div>
        <asp:Label runat="server">Page Body : </asp:Label>
        <asp:TextBox runat="server" ID="pagebody_input"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Input the body of the page" ControlToValidate="pagebody_input"></asp:RequiredFieldValidator>
    </div>

    <div>
        <asp:Label runat="server">Author Name : </asp:Label>
        <asp:TextBox runat="server" ID="authorname_input"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Input the author of the page" ControlToValidate="authorname_input"></asp:RequiredFieldValidator>
    </div>

    <div>
        <asp:Button runat="server" Text="Save" CssClass="save_button"/>
    </div>

    <div id="pages_result" runat="server">

    </div>
</asp:Content>
