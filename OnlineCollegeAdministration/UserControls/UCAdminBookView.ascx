<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAdminBookView.ascx.cs" Inherits="OCA.UserControls.UCAdminBookView" %>

<table>
    <tr>
        <td>
            <table>
                <tr>
                    <td colspan="2" class="searchcol">Search
                    </td>

                </tr>
                <tr>
                    <td>Book ID</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtBookIDSearch" />

                    </td>
                </tr>
                <tr>
                    <td>Book Name</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtBookNameSearch" />

                    </td>
                </tr>
                <tr>
                    <td>Book Author Name</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtBookAuthorNameSearch" />

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
            <asp:GridView ID="gvBook" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvBook_PageIndexChanging"
                AllowSorting="false" PageSize="20" ShowHeaderWhenEmpty="true" ShowHeader="true" SkinID="GVSkin" DataKeyNames="book_id">
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
                            <asp:RadioButton ID="rdbook" runat="server" AutoPostBack="true" OnCheckedChanged="rdBook_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Book ID" runat="server" ID="lblHdrbookID" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("book_id") %>' runat="server" ID="lblItembookID" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Book Name" runat="server" ID="lblHdrbookName" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("book_name") %>' runat="server" ID="lblItembookName" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Author Name" runat="server" ID="lblHdrbookAuthName" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("book_author_name") %>' runat="server" ID="lblItembookAuthName" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>

