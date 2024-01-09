<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCStaffGradesView.ascx.cs"
    Inherits="OCA.UserControls.UCStaffGradesView" %>
<table>
    <tr>
        <td>
            <table>
                <tr>
                    <td colspan="2" class="searchcol">
                        Search
                    </td>
                </tr>
                <tr>
                    <td>
                        Course
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlCourses">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                      Course  Status
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlActive">
                            <asp:ListItem Text="ALL" Value="-1" />
                            <asp:ListItem Text="Active" Value="1" />
                            <asp:ListItem Text="Inactive" Value="0" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Student ID
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtStudentIDSearch" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Student Last Name
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtStudentLNSearch" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Student First Name
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtStudentFNSearch" />
                    </td>
                </tr>                
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button Text="Search" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                OnPageIndexChanging="gvStudent_PageIndexChanging" AllowSorting="false" PageSize="20"
                ShowHeaderWhenEmpty="true" ShowHeader="true" SkinID="GVSkin" DataKeyNames="student_id,course_duration_id,staff_course_id">
                <EmptyDataTemplate>
                    <table style="width:100%">
                        <tr>
                            <td style="text-align:center">No Records</td>
                        </tr>
                    </table> 
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:RadioButton ID="rdStudent" runat="server" AutoPostBack="true" OnCheckedChanged="rdStudent_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Student ID" runat="server" ID="lblHdrStudentID" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("student_id_txt") %>' runat="server" ID="lblItemStudentID" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Last Name" runat="server" ID="lblHdrStudentLastName" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("student_last_name") %>' runat="server" ID="lblItemStudentLastName" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="First Name" runat="server" ID="lblHdrStudentFirstName" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("student_first_name") %>' runat="server" ID="lblItemStudentFirstName" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
