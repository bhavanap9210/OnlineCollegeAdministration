<%@ Page Title="" Language="C#" MasterPageFile="~/OCAMaster.Master" AutoEventWireup="true"
    CodeBehind="StaffCourses.aspx.cs" Inherits="OCA.Staff.StaffCourses" EnableTheming="true"
    Theme="OCAThemes" StylesheetTheme="OCAThemes" %>

<%@ Register Src="~/UserControls/UCStaffCoursesView.ascx" TagName="StaffCourseView"
    TagPrefix="OCA" %>
<%@ Register Src="~/UserControls/UCStaffCoursesAddEdit.ascx" TagName="StaffCourseAddEdit"
    TagPrefix="OCA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" style="padding: 0px;" class="tableTopClass">
        <tr id="trddlStaff" runat="server">
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width:150px;" class="headingClass">
                            Select Staff
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlStaff" OnSelectedIndexChanged="ddlStaff_SelectedIndexChanged"  AutoPostBack="true" CssClass="dropdownClass"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trCourseCtrls" runat="server">
            <td nowrap class="leftSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlStaffCourseView">
                    <ContentTemplate>
                        <OCA:StaffCourseView ID="ucStaffCourseView" OnevtCourseSelected="ucStaffCourseView_evtStaffCourseSelected"
                            runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="rightSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlStaffCourseAddEdit">
                    <ContentTemplate>
                        <OCA:StaffCourseAddEdit ID="ucStaffCourseAddEdit" OnevtStaffCourseEdited="ucStaffCourseAddEdit_evtStaffCourseEdited"
                            runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
