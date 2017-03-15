<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="FrontEndASPNETTest.Reservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Email:
            <asp:TextBox ID="EmailBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Phone:
            <asp:TextBox ID="PhoneBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Date of Birth:</p>
        <p>
            <asp:Calendar ID="DOBBox" runat="server"></asp:Calendar>
        </p>
        <p>
            Arrival<asp:Calendar ID="ArriveBox" runat="server"></asp:Calendar>
        </p>
        <p>
            Departure</p>
        <p>
            <asp:Calendar ID="DepartBox" runat="server"></asp:Calendar>
        </p>
        <p>
            Plan
            <asp:DropDownList ID="PlanBox" runat="server">
                <asp:ListItem>Hotel Only</asp:ListItem>
                <asp:ListItem>Hotel And Gym</asp:ListItem>
                <asp:ListItem>Full Buffet</asp:ListItem>
                <asp:ListItem>Luxury</asp:ListItem>
                <asp:ListItem>Full Package</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            Full Name<asp:TextBox ID="NameBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Special Requests</p>
        <p>
            <asp:TextBox ID="RequestBox" runat="server" Height="110px" TextMode="MultiLine"></asp:TextBox>
        </p>
        <p>
            Username
            <asp:TextBox ID="userBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Password
            <asp:TextBox ID="passBox" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="userh" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" Text="Submit" />
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
