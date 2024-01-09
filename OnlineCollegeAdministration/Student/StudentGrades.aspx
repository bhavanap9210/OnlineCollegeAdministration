<%@ Page Language="C#" MasterPageFile="~/OCAMaster.Master" AutoEventWireup="true" CodeBehind="StudentGrades.aspx.cs" Inherits="OCA.Student.StudentGrades" EnableTheming="true"
    Theme="OCAThemes" StylesheetTheme="OCAThemes" %>

<%@ Register Src="~/UserControls/UCStudentGradesView.ascx" TagName="StudentGradesView"
    TagPrefix="OCA" %>
<%@ Register Src="~/UserControls/UCStudentGradesAddEdit.ascx" TagName="StudentGradesAddEdit"
    TagPrefix="OCA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" style="padding: 0px;">
        <tr>
            <td nowrap class="leftSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlStudentGradeView">
                    <ContentTemplate>
                        <OCA:StudentGradesView ID="ucStudentGradeView" OnevtCourseSelected="ucStudentGradesView_evtStudentGradesSelected"
                            runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="rightSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlStudentGradeAddEdit">
                    <ContentTemplate>
                        <OCA:StudentGradesAddEdit ID="ucStudentGradeAddEdit" OnevtStudentGradeEdited="ucStudentGradesAddEdit_evtStudentGradesEdited"
                            runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

