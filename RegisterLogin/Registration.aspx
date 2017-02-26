<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            text-align: right;
        }
        .auto-style3 {
            height: 23px;
            text-align: right;
        }
        .auto-style4 {
            text-align: left;
        }
        .auto-style5 {
            height: 23px;
            text-align: left;
        }
        .auto-style6 {
            text-align: right;
            height: 26px;
        }
        .auto-style7 {
            height: 26px;
        }
        .auto-style8 {
            text-align: left;
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style3">Username:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxUsername" runat="server" Width="250px"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUsername" ErrorMessage="User Name is required." ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Email:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxEmail" runat="server" Width="250px"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Email is required." ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Enter a valid email address." ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Password:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                </td>
                <td class="auto-style8">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Password is required." ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Confirm Password:</td>
                <td>
                    <asp:TextBox ID="TextBoxRPassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxRPassword" ErrorMessage="Confirm Password is required." ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxRPassword" ErrorMessage="Both passwords must be identical." ForeColor="#CC0000"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Country:</td>
                <td class="auto-style7">
                    <asp:DropDownList ID="DropDownListCountry" runat="server" Width="250px">
                        <asp:ListItem>Select Country</asp:ListItem>
                        <asp:ListItem>USA</asp:ListItem>
                        <asp:ListItem>Russia</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style8">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownListCountry" ErrorMessage="Country is required." ForeColor="#CC0000" InitialValue="Select Country"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit" />
                    <input id="Reset1" type="reset" value="reset" /></td>
                <td></td>
            </tr>
        </table>
    
    </div>
    <div>
        &nbsp;</div>
    </form>
</body>
</html>
