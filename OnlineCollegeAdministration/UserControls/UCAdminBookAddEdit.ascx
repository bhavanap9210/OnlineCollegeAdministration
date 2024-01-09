<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAdminBookAddEdit.ascx.cs" Inherits="OCA.UserControls.UCAdminBookAddEdit" %>
<div>
    <asp:Label ID="lblMsg" runat="server" />

</div>
<table>
    <tr>
        <td>Book Id</td>
        <td style="width: 300px;">
            <asp:Label ID="lblBookID" runat="server" /></td>
        <td></td>
        <td style="width: 300px;">&nbsp;</td>
    </tr>
    <tr>
        <td>Book Name*</td>
        <td>
            <asp:TextBox runat="server" ID="txtBookName" /></td>
      <td>Book Author Name*</td>
        <td>
            <asp:TextBox runat="server" ID="txtBookAuthorName" /></td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:GridView ID="gvCourse" runat="server" AutoGenerateColumns="false" AllowPaging="false" 
                AllowSorting="false" PageSize="20" ShowHeaderWhenEmpty="true" ShowHeader="true" SkinID="GVSkin" DataKeyNames="course_id,selected_ind,book_course_id"   OnRowDataBound="gvCourse_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkCourse" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Course ID" runat="server" ID="lblHdrCourseID" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("course_id") %>' runat="server" ID="lblItemCourseID" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Course Name" runat="server" ID="lblHdrCourseName" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("course_name") %>' runat="server" ID="lblItemCourseName" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
        </td>

    </tr>
    <tr>
        <td colspan="4">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 33%">
                        <asp:Button Text="Add" ID="btnAdd" runat="server" OnClick="btnAdd_Click" />
                        &nbsp;
                        <asp:Button Text="Edit" ID="btEdit" runat="server" OnClick="btEdit_Click" />
                    </td>
                    <td style="width: 33%">
                        
                    </td>
                    <td>
                        <asp:Button Text="Save" runat="server" ID="btnSave" OnClick="btnSave_Click" />
                        &nbsp;
                        <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
