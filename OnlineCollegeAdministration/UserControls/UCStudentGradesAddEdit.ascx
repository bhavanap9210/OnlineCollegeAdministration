<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCStudentGradesAddEdit.ascx.cs" Inherits="OCA.UserControls.UCStudentGradesAddEdit" %>
<div>
    <asp:Label ID="lblMsg" runat="server" />
</div>
<table>
    
    <tr>
        <td>
            Staff ID
        </td>
        <td style="width: 300px;">
            <asp:Label ID="lblStaffID" runat="server" />
        </td>
        <td>
            Course ID
        </td>
        <td style="width: 300px;">
            <asp:Label ID="lblCourseDurationID" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Course Name
        </td>
        <td colspan="3">
            <asp:Label ID="lblCourseName" runat="server" />
        </td>

    </tr>
    <tr>
        <td>
            Course Description*
        </td>
        <td colspan="3">
            <asp:TextBox ID="txtCourseDurationDesc"  runat="server" Width="300px" Rows="4"  TextMode="MultiLine"/>
        </td>
    </tr>
    <tr>
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
    <tr>
        <td>
            Day
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlDay" />
        </td>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Start Time*
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtCourseStartTime" />
             <ajaxToolkit:MaskedEditExtender ID="meExtCourseStartTime" runat="server" TargetControlID="txtCourseStartTime"
                Mask="99:99" MessageValidatorTip="true" ClearMaskOnLostFocus="false"
                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Time"
                InputDirection="LeftToRight" AcceptNegative="None" 
                ErrorTooltipEnabled="True" />
        </td>
        <td>
            End Time*
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtCourseEndTime" />
             <ajaxToolkit:MaskedEditExtender ID="meExtCourseEndTime" runat="server" TargetControlID="txtCourseEndTime"
                Mask="99:99" MessageValidatorTip="true" ClearMaskOnLostFocus="false"
                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Time"
                InputDirection="LeftToRight" AcceptNegative="None" 
                ErrorTooltipEnabled="True" />
        </td>
    </tr>
      
    <tr>
        <td>
            Status
        </td>
        <td colspan="3">
            <asp:Label ID="lblStatus" runat="server" />
        </td>
    </tr>
     <tr>
        <td>
            Grade
        </td>
        <td colspan="3">
            <asp:Label ID="lblGrade" runat="server" CssClass="highlightClass" />
    
        </td>
    </tr>
    
</table>
