<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCOtherReports.ascx.cs"
    Inherits="OCA.UserControls.UCOtherReports" %>
<div>
    <asp:Label ID="lblMsg" runat="server" />
</div>
<table>
    <tr id="trStudent0" runat="server">
        <td>Student ID
        </td>
        <td style="width: 300px;">
            <asp:TextBox runat="server" ID="txtStudentID" />
        </td>
        <td></td>
        <td style="width: 300px;">&nbsp;
        </td>
    </tr>
     <tr id="trStaff" runat="server">
        <td>Staff ID
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtStaffId" />
        </td>
        <td> 
        </td>
        <td>
            
        </td>
    </tr>
    <tr id="trStudent1" runat="server">
        <td>Last Name
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtLastName" />
        </td>
        <td>First Name
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtFirstName" />
        </td>
    </tr>
    <tr id="trStudent2" runat="server">
        <td>Middle Name
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtMiddleName" />
        </td>
        <td>Date of Birth
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtDOB" />
             <ajaxToolkit:CalendarExtender ID="calExtDOB" runat="server" Format="MM/dd/yyyy" TargetControlID="txtDOB">
            </ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="meExtDOB" runat="server" Mask="99/99/9999" MaskType="Date"
                MessageValidatorTip="true" TargetControlID="txtDOB" />
        </td>
    </tr>
   
    <tr id="trCourse" runat="server">
        <td>Course ID
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtCourseId" />
        </td>
        <td>Course Name
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtCourseName" />
        </td>
    </tr>
     <tr id="trBook" runat="server">
       
        <td>Book Name
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtBookName" />
        </td>
         <td>Book Author Name
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtBookAuthorName" />
        </td>
    </tr>
     <tr  id="trYearMonth" runat="server">
        <td>
            Year*
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlYear" />
        </td>
        <td>
            Month*
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlMonth" />
        </td>
    </tr>
    <tr id="trStatus" runat="server">
        <td>Status</td>
        <td colspan="3">
            <asp:DropDownList runat="server" ID="ddlActive">
                <asp:ListItem Text="ALL" Value="-1" />
                <asp:ListItem Text="Active" Value="1" />
                <asp:ListItem Text="Inactive" Value="0" />
            </asp:DropDownList>

        </td>
    </tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
    <tr>
        <td align="center">
            <asp:Button Text="Export" ID="btnExport" runat="server" OnClick="btnExport_Click" />
            &nbsp;<asp:Button Text="Reset" runat="server" ID="btnReset" OnClick="btnReset_Click" />
        </td>
    </tr>
</table>
