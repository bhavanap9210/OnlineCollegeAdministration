<%@ Page Title="" Language="C#" MasterPageFile="~/OCAMaster.Master" AutoEventWireup="true" CodeBehind="MaintainCourse.aspx.cs" Inherits="OCA.Admin.MaintainCourse" EnableTheming="true" Theme="OCAThemes" StylesheetTheme="OCAThemes"  %>


<%@ Register Src="~/UserControls/UCAdminCourseView.ascx" TagName="CourseView" TagPrefix="OCA" %>
<%@ Register Src="~/UserControls/UCAdminCourseAddEdit.ascx" TagName="CourseAddEdit" TagPrefix="OCA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" style="padding:0px;">
        <tr>
            <td nowrap  class="leftSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlCourseView">
                    <ContentTemplate>
                        <OCA:CourseView ID="udCourseView" runat="server" OnevtCourseSelected="udCourseView_evtCourseSelected" />

                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        
            <td class="rightSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlCourseAddEdit">
                    <ContentTemplate>
                        <OCA:CourseAddEdit ID="udCourseAddEdit" runat="server" OnevtCourseEdited="udCourseAddEdit_evtCourseEdited" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
