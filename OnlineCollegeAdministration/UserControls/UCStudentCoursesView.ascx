<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCStudentCoursesView.ascx.cs" Inherits="OCA.UserControls.UCStudentCoursesView" %>

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
                            Staff
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlStaff" CssClass="dropdownClass"/>
                        </td>
                    </tr>
                <tr>
                    <td>
                        Course ID
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCourseIDSearch" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Course Name
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCourseNameSearch" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Year
                    </td>
                    <td>
                       <asp:DropDownList runat="server" ID="ddlYearSearch"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Month
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlMonthSearch"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Day
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlDaySearch"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Start Time
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCourseStartTimeSearch" />
                    </td>
                </tr>
                <tr>
                    <td>
                        End Time
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCourseEndTimeSearch" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Status
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
                        Courses Assigned
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlCoursesAssigned">
                            <asp:ListItem Text="ALL" Value="-1" />
                            <asp:ListItem Text="Assigned" Value="1" />
                            <asp:ListItem Text="Unassigned" Value="0" />
                        </asp:DropDownList>
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
            <asp:GridView ID="gvCourse" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                OnPageIndexChanging="gvCourse_PageIndexChanging" AllowSorting="false" PageSize="20"
                ShowHeaderWhenEmpty="true" ShowHeader="true" SkinID="GVSkin" DataKeyNames="course_duration_id,staff_course_id">
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
                            <asp:Label Text='<%# Eval("course_id_txt") %>' runat="server" ID="lblItemCourseID" />
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
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Start Time" runat="server" ID="lblHdrCourseStartTime" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("course_start_time") %>' runat="server" ID="lblItemCourseStartTime" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="End Time" runat="server" ID="lblHdrCourseEndTime" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("course_end_time") %>' runat="server" ID="lblItemCourseEndTime" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>

