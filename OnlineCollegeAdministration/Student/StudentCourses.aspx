<%@ Page Language="C#" MasterPageFile="~/OCAMaster.Master" AutoEventWireup="true" CodeBehind="StudentCourses.aspx.cs" Inherits="OCA.Student.StudentCourses" EnableTheming="true"
    Theme="OCAThemes" StylesheetTheme="OCAThemes" %>

<%@ Register Src="~/UserControls/UCStudentCoursesView.ascx" TagName="StudentCoursesView"
    TagPrefix="OCA" %>
<%@ Register Src="~/UserControls/UCStudentCoursesAddEdit.ascx" TagName="StudentCoursesAddEdit"
    TagPrefix="OCA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" style="padding: 0px;">
        <tr>
            <td nowrap class="leftSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlStudentCourseView">
                    <ContentTemplate>
                        <OCA:StudentCoursesView ID="ucStudentCourseView" OnevtCourseSelected="ucStudentCourseView_evtStudentCourseSelected"
                            runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="rightSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlStudentCourseAddEdit">
                    <ContentTemplate>
                        <OCA:StudentCoursesAddEdit ID="ucStudentCourseAddEdit" OnevtStudentCourseEdited="ucStudentCourseAddEdit_evtStudentCourseEdited"
                            runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

