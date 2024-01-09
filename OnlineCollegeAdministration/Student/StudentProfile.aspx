<%@ Page Title="" Language="C#" MasterPageFile="~/OCAMaster.Master" AutoEventWireup="true" CodeBehind="StudentProfile.aspx.cs" Inherits="OCA.Student.StudentProfile" EnableTheming="true"
    Theme="OCAThemes" StylesheetTheme="OCAThemes" %>

<%@ Register Src="~/UserControls/UCStudentEdit.ascx" TagName="StudentEdit" TagPrefix="OCA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableTopClass">
        <tr>
            <td>
                <asp:UpdatePanel runat="server" ID="uppnlStudentEdit">
                    <ContentTemplate>
                        <OCA:StudentEdit ID="ucStudentEdit" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
