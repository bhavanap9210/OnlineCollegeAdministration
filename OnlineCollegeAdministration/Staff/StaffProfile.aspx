<%@ Page Title="" Language="C#" MasterPageFile="~/OCAMaster.Master" AutoEventWireup="true"
    CodeBehind="StaffProfile.aspx.cs" Inherits="OCA.Staff.StaffProfile" EnableTheming="true"
    Theme="OCAThemes" StylesheetTheme="OCAThemes" %>

<%@ Register Src="~/UserControls/UCStaffEdit.ascx" TagName="StaffEdit" TagPrefix="OCA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableTopClass">
        <tr>
            <td>
                <asp:UpdatePanel runat="server" ID="uppnlStaffEdit">
                    <ContentTemplate>
                        <OCA:StaffEdit ID="ucStaffEdit" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

</asp:Content>
