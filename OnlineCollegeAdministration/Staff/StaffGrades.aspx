<%@ Page Title="" Language="C#" MasterPageFile="~/OCAMaster.Master" AutoEventWireup="true" CodeBehind="StaffGrades.aspx.cs" Inherits="OCA.Staff.StaffGrades" EnableTheming="true"
    Theme="OCAThemes" StylesheetTheme="OCAThemes" %>

<%@ Register Src="~/UserControls/UCStaffGradesView.ascx" TagName="StaffGradesView"
    TagPrefix="OCA" %>
<%@ Register Src="~/UserControls/UCStaffGradesEdit.ascx" TagName="StaffGradesEdit"
    TagPrefix="OCA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" style="padding: 0px;">
        <tr>
            <td nowrap class="leftSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlStaffGradeView">
                    <ContentTemplate>
                        <OCA:StaffGradesView ID="ucStaffGradeView" OnevtStudentSelected="ucStaffGradeView_evtStudentSelected"
                            runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="rightSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlStaffGradeEdit">
                    <ContentTemplate>
                        <OCA:StaffGradesEdit ID="ucStaffGradeEdit" OnevtStaffGradeEdited="ucStaffGradesEdit_evtStaffGradesEdited"
                            runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
