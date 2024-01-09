<%@ Page Title="" Language="C#" MasterPageFile="~/OCAMaster.Master" AutoEventWireup="true" CodeBehind="MaintainStudent.aspx.cs" Inherits="OCA.Admin.MaintainStudent" EnableTheming="true" Theme="OCAThemes" StylesheetTheme="OCAThemes" %>

<%@ Register Src="~/UserControls/UCAdminStudentView.ascx" TagName="StudentView" TagPrefix="OCA" %>
<%@ Register Src="~/UserControls/UCAdminStudentAddEdit.ascx" TagName="StudentAddEdit" TagPrefix="OCA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" style="padding:0px;">
        <tr>
            <td nowrap  class="leftSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlStudentView">
                    <ContentTemplate>
                        <OCA:StudentView ID="udStudentView" runat="server" OnevtStudentSelected="udStudentView_evtStudentSelected" />

                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        
            <td class="rightSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlStudentAddEdit">
                    <ContentTemplate>
                        <OCA:StudentAddEdit ID="udStudentAddEdit" runat="server" OnevtStudentEdited="udStudentAddEdit_evtStudentEdited" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
