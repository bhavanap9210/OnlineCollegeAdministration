<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAdminCourseView.ascx.cs" Inherits="OCA.UserControls.UCAdminCourseView" EnableTheming="true" %>

<table>
    <tr>
        <td>
            <table>
                <tr>
                    <td colspan="2" class="searchcol">Search
                    </td>

                </tr>
                <tr>
                    <td>Course ID</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCourseIDSearch" />

                    </td>
                </tr>
                <tr>
                    <td>Course Name</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCourseNameSearch" />

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
            <asp:GridView ID="gvCourse" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvCourse_PageIndexChanging"
                AllowSorting="false" PageSize="20" ShowHeaderWhenEmpty="true" ShowHeader="true" SkinID="GVSkin" DataKeyNames="course_id">
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
                            <asp:RadioButton ID="rdCourse" runat="server" AutoPostBack="true" OnCheckedChanged="rdCourse_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Course ID" runat="server" ID="lblHdrCourseID" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("course_id") %>' runat="server" ID="lblItemCourseID" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Course Name" runat="server" ID="lblHdrCourseName" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("course_name") %>' runat="server" ID="lblItemCourseName" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>

