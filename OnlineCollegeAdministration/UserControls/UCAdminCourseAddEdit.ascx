<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAdminCourseAddEdit.ascx.cs" Inherits="OCA.UserControls.UCAdminCourseAddEdit" %>
<div>
    <asp:Label ID="lblMsg" runat="server" />

</div>
<table>
    <tr>
        <td>Course ID</td>
        <td style="width: 300px;">
            <asp:Label ID="lblCourseID" runat="server" /></td>
        <td></td>
        <td style="width: 300px;">&nbsp;</td>
    </tr>
    <tr>
        <td>Course Name*</td>
        <td>
            <asp:TextBox runat="server" ID="txtCourseName" /></td>
        <td>Course Description*</td>
        <td>
            <asp:TextBox runat="server" ID="txtCourseDesc" /></td>
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
