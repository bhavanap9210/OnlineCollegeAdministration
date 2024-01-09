<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.ascx.cs"
    Inherits="OCA.UserControls.MenuControl" %>
<div style="text-align:center; font-size:large;font-weight:bold;">
    <asp:Label ID="lblMenuName" runat="server"  />
</div>
<asp:Menu ID="RBSMenu" runat="server" Orientation="Horizontal" OnMenuItemClick="RBSMenu_MenuItemClick">
    <StaticMenuStyle BorderStyle="None" BackColor="#B8860B" HorizontalPadding="25px" VerticalPadding="2px"   />
    <StaticMenuItemStyle Font-Names="Time New Roman" ForeColor="White" BorderStyle="None" Font-Underline="true"  HorizontalPadding="50px"
        Font-Size="12pt" Font-Bold="true"  ItemSpacing="2px" BorderWidth="1px" />
    <DynamicMenuStyle BorderStyle="Outset" BorderWidth="1px" BorderColor="Gray" BackColor="#FFCC66"   VerticalPadding="2px" Width="220px" />
    <DynamicMenuItemStyle Font-Names="Tahoma" Font-Size="11pt" Height="18px" ItemSpacing="2px"   CssClass="MenuStyle"
        BorderStyle="None" BorderWidth="10px" BorderColor="#D9D9E6" ForeColor="DarkBlue" Width="120px"/>
</asp:Menu>
