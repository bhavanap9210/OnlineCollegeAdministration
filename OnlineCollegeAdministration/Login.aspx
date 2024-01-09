<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="OCA.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td align="center" colspan="2" style="color: Red; font-weight:bold;">
                <asp:Literal ID="litFailureText" runat="server" EnableViewState="False"></asp:Literal>
            </td>
        </tr>
    </table>
    <asp:Login ID="LoginControl" runat="server" Width="100%">
        <LayoutTemplate>
            <table cellpadding="1" cellspacing="1" style="border-collapse: collapse;" width="100%">
                <tr>
                    <td align="center">
                        <table cellpadding="1" cellpadding="1" width="300px">

                            <tr>
                                <td align="left" nowrap valign="middle">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Width="150px">User Name:</asp:Label>
                                </td>
                                <td align="left" valign="middle" nowrap>
                                    <asp:TextBox ID="UserName" runat="server" Width="150px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" Display="Dynamic" ForeColor="Red"
                                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap valign="middle">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Width="150px">Password:</asp:Label>
                                </td>
                                <td align="left" valign="middle" nowrap>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" Display="Dynamic" ForeColor="Red"
                                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="LoginButton" runat="server" Text="Log In" ValidationGroup="Login1"
                                        OnClick="LoginButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:Login>

</asp:Content>
