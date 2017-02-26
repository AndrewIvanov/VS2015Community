<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            text-align: right;
        }
        .auto-style4 {
            height: 23px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        Login Page</div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style3">Username:</td>
                <td>
                    <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUsername" ErrorMessage="Please enter a username." ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Password:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Please enter your password." ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Login" />
                </td>
                <td>
                    <asp:HyperLink ID="HyperLinkNewUserRegister" runat="server" NavigateUrl="~/Registration.aspx">New User Register Here</asp:HyperLink>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
