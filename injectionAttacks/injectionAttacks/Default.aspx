<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" ValidateRequest="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:TextBox ID="TextBoxInput" runat="server" Height="113px" TextMode="MultiLine" Width="335px"></asp:TextBox>
            <asp:Button ID="ButtonEnter" runat="server" Text="Giriş" OnClick="ButtonEnter_Click" />
            <br />
            <asp:Label ID="LabelOutput" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="col-md-4">
            <p>
                &nbsp;</p>
        </div>
        <div class="col-md-4">
        </div>
    </div>
</asp:Content>
