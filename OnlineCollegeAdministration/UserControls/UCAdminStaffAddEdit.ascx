﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAdminStaffAddEdit.ascx.cs" Inherits="OCA.UserControls.UCAdminStaffAddEdit" %>
<div>
    <asp:Label ID="lblMsg" runat="server" />

</div>
<asp:UpdatePanel runat="server" ID="uppnlUpload">
    <ContentTemplate>
        <table style="width: 100%">
            <tr>
                <td colspan="4" style="width: 100px; height: 100px;">
                    <asp:Image ImageUrl="~/CustomImageHandler.ashx?type=S&id=" runat="server" Width="100px" Height="100px" ID="imgStaff" />

                </td>

            </tr>
            <tr>
                <td colspan="4" nowrap>
                    <asp:FileUpload ID="fileUpload" runat="server" />
                    &nbsp;
                    <asp:Button Text="Upload Image" ID="btnUploadImage" runat="server" OnClick="btnUploadImage_Click" />
                </td>

            </tr>
        </table>

    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnUploadImage" />
    </Triggers>
</asp:UpdatePanel>

<table>

    <tr>
        <td>Staff ID</td>
        <td style="width: 300px;">
            <asp:Label ID="lblStaffID" runat="server" /></td>
        <td></td>
        <td style="width: 300px;">&nbsp;</td>
    </tr>
    <tr>
        <td>Last Name*</td>
        <td>
            <asp:TextBox runat="server" ID="txtLastName" /></td>
        <td>First Name*</td>
        <td>
            <asp:TextBox runat="server" ID="txtFirstName" /></td>
    </tr>
    <tr>
        <td>Middle Name</td>
        <td>
            <asp:TextBox runat="server" ID="txtMiddleName" /></td>
        <td>Date of Birth*</td>
        <td>
            <asp:TextBox runat="server" ID="txtDOB" />
            <ajaxToolkit:CalendarExtender ID="calExtDOB" runat="server" Format="MM/dd/yyyy" TargetControlID="txtDOB"></ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="meExtDOB" runat="server" Mask="99/99/9999" MaskType="Date"
                MessageValidatorTip="true" TargetControlID="txtDOB" />

        </td>

    </tr>
    <tr>
        <td>Address 1*</td>
        <td>
            <asp:TextBox runat="server" ID="txtAddr1" /></td>
        <td>Address 2</td>
        <td>
            <asp:TextBox runat="server" ID="txtAddr2" /></td>
    </tr>
    <tr>
        <td>City*</td>
        <td>
            <asp:TextBox runat="server" ID="txtCity" /></td>
        <td>State*</td>
        <td>
            <asp:TextBox runat="server" ID="txtState" /></td>
    </tr>
    <tr>
        <td>ZipCode*</td>
        <td>
            <asp:TextBox runat="server" ID="txtZipCode" />
            <ajaxToolkit:MaskedEditExtender ID="meExtZipCode" runat="server" TargetControlID="txtZipCode"
                Mask="99999" MessageValidatorTip="true" ClearMaskOnLostFocus="false"
                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="None"
                InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                ErrorTooltipEnabled="True" />
        </td>
        <td>Country*</td>
        <td>
            <asp:TextBox runat="server" ID="txtCountry" /></td>
    </tr>
    <tr>
        <td>Email*</td>
        <td>
            <asp:TextBox runat="server" ID="txtEmail" />
            <asp:RegularExpressionValidator ID="regEmail" ControlToValidate="txtEmail" CssClass="errorLabelClass"
                runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Enter valid Email"
                ValidationGroup="check" Display="Dynamic">                   
            </asp:RegularExpressionValidator>

        </td>
        <td>Mobile*</td>
        <td>
            <asp:TextBox runat="server" ID="txtMobile" />
            <ajaxToolkit:MaskedEditExtender ID="meExtMobile" runat="server" TargetControlID="txtMobile"
                Mask="(999) 999-9999" MessageValidatorTip="true" ClearMaskOnLostFocus="false"
                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="None"
                InputDirection="LeftToRight" AcceptNegative="None" Filtered="-"
                ErrorTooltipEnabled="True" />

        </td>
    </tr>
    <tr id="trChangePwd" runat="server">
        <td>Change Password*</td>
        <td>
            <asp:TextBox runat="server" ID="txtChangePassword" /></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>Status
        </td>
        <td colspan="3">
            <asp:Label ID="lblStatus" runat="server" />

        </td>
    </tr>
    <tr>
        <td colspan="4">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 33%">
                        <asp:Button Text="Add" ID="btnAdd" runat="server" OnClick="btnAdd_Click" />
                        &nbsp;
                        <asp:Button Text="Edit" ID="btEdit" runat="server" OnClick="btEdit_Click" />
                    </td>
                    <td style="width: 33%">
                        <asp:Button Text="Activate/Inactivate" runat="server" ID="btnActivate" OnClick="btnActivate_Click" />
                    </td>
                    <td>
                        <asp:Button Text="Save" runat="server" ID="btnSave" OnClick="btnSave_Click" CausesValidation="true" UseSubmitBehavior="false" ValidationGroup="check" />
                        &nbsp;
                        <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
