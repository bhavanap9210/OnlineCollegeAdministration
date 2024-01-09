<%@ Page Title="" Language="C#" MasterPageFile="~/OCAMaster.Master" AutoEventWireup="true" CodeBehind="MaintainStaff.aspx.cs" Inherits="OCA.Admin.MaintainStaff" EnableTheming="true" Theme="OCAThemes" StylesheetTheme="OCAThemes" %>

<%@ Register Src="~/UserControls/UCAdminStaffView.ascx" TagName="StaffView" TagPrefix="OCA" %>
<%@ Register Src="~/UserControls/UCAdminStaffAddEdit.ascx" TagName="StaffAddEdit" TagPrefix="OCA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" style="padding:0px;">
        <tr>
            <td nowrap  class="leftSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlStaffView">
                    <ContentTemplate>
                        <OCA:StaffView ID="udStaffView" runat="server" OnevtStaffSelected="udStaffView_evtStaffSelected" />

                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        
            <td class="rightSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlStaffAddEdit">
                    <ContentTemplate>
                        <OCA:StaffAddEdit ID="udStaffAddEdit" runat="server" OnevtStaffEdited="udStaffAddEdit_evtStaffEdited" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
