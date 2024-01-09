<%@ Page Title="" Language="C#" MasterPageFile="~/OCAMaster.Master" AutoEventWireup="true" CodeBehind="MaintainBooks.aspx.cs" Inherits="OCA.Admin.MaintainBooks"  EnableTheming="true" Theme="OCAThemes" StylesheetTheme="OCAThemes"  %>


<%@ Register Src="~/UserControls/UCAdminBookView.ascx" TagName="BookView" TagPrefix="OCA" %>
<%@ Register Src="~/UserControls/UCAdminBookAddEdit.ascx" TagName="BookAddEdit" TagPrefix="OCA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" style="padding:0px;">
        <tr>
            <td nowrap  class="leftSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlBookView">
                    <ContentTemplate>
                        <OCA:BookView ID="udBookView" runat="server" OnevtBookSelected="udBookView_evtBookSelected" />

                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        
            <td class="rightSectionClass">
                <asp:UpdatePanel runat="server" ID="uppnlBookAddEdit">
                    <ContentTemplate>
                        <OCA:BookAddEdit ID="udBookAddEdit" runat="server" OnevtBookEdited="udBookAddEdit_evtBookEdited" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
