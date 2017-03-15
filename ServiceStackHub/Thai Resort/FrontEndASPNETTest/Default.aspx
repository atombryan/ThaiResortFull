<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontEndASPNETTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:HyperLink ID="reserve" runat="server" NavigateUrl="~/Reservation.aspx">Reservation</asp:HyperLink>
        <br />
        <asp:HyperLink ID="reserve0" runat="server" NavigateUrl="~/FitnessInfoReadWrite.aspx">Fitness Info</asp:HyperLink>
    </div>

    <div class="row">
    </div>

</asp:Content>
