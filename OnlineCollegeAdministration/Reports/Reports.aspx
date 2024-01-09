<%@ Page Title="" Language="C#" MasterPageFile="~/OCAMaster.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="OCA.Reports.Reports" EnableTheming="true"
    Theme="OCAThemes" StylesheetTheme="OCAThemes" %>

<%@ Register Src="~/UserControls/UCStudentReports.ascx" TagName="Student" TagPrefix="OCA" %>
<%@ Register Src="~/UserControls/UCStaffReports.ascx" TagName="Staff" TagPrefix="OCA" %>
<%@ Register Src="~/UserControls/UCOtherReports.ascx" TagName="Other" TagPrefix="OCA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableTopClass">
        <tr>
            <td>
                <OCA:Student ID="ucStudentReports" runat="server" />
                <OCA:Staff ID="ucStaffReports" runat="server" />
                <OCA:Other ID="ucOtherReports" runat="server" />
            </td>
        </tr>
    </table>

</asp:Content>
