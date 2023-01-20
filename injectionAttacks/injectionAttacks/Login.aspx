<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" ValidateRequest="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <br />
            <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Giriş" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="col-md-4">
            <p>
                &nbsp;</p>
        </div>
        <div class="col-md-4">
        </div>
    </div>
</asp:Content>
