<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAdminStaffView.ascx.cs" Inherits="OCA.UserControls.UCAdminStaffView" EnableTheming="true" %>

<table>
    <tr>
        <td>
            <table>
                <tr>
                    <td colspan="2" class="searchcol">
                        Search
                    </td>

                </tr>
                <tr>
                    <td>Staff ID</td>
                    <td>
                        <asp:TextBox runat="server"  ID="txtStaffIDSearch" />

                    </td>
                </tr>
                <tr>
                    <td>Staff Last Name</td>
                    <td>
                        <asp:TextBox runat="server"  ID="txtStaffLNSearch" />

                    </td>
                </tr>
                  <tr>
                    <td>Staff First Name</td>
                    <td>
                        <asp:TextBox runat="server"  ID="txtStaffFNSearch" />

                    </td>
                </tr>
                  <tr>
                    <td>Status</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlActive">
                            <asp:ListItem Text="ALL" Value="-1" />
                            <asp:ListItem Text="Active"  Value="1"/>
                            <asp:ListItem Text="Inactive"  Value="0"/>
                        </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">

                        <asp:Button Text="Search" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                    </td>

                </tr>
            </table>

        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvStaff" runat="server" AutoGenerateColumns="false" AllowPaging="true"  OnPageIndexChanging="gvStaff_PageIndexChanging"
                AllowSorting="false" PageSize="20" ShowHeaderWhenEmpty="true" ShowHeader="true" SkinID="GVSkin" DataKeyNames="staff_id">
                <EmptyDataTemplate>
                    <table style="width:100%">
                        <tr>
                            <td style="text-align:center">No Records</td>
                        </tr>
                    </table> 
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:RadioButton ID="rdStaff" runat="server" AutoPostBack="true" OnCheckedChanged="rdStaff_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Staff ID" runat="server" ID="lblHdrStaffID" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("staff_id_txt") %>' runat="server" ID="lblItemStaffID" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Last Name" runat="server" ID="lblHdrStaffLastName" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("staff_last_name") %>' runat="server" ID="lblItemStaffLastName" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="First Name" runat="server" ID="lblHdrStaffFirstName" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("staff_first_name") %>' runat="server" ID="lblItemStaffFirstName" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>

