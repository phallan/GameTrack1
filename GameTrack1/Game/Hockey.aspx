<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Hockey.aspx.cs" Inherits="GameTrack1.Hockey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">

                <h1>Student List</h1>
                <a href="AddResult.aspx" class="btn btn-success btn-sm">
                    <i class="fa fa-plus"></i> Add result
                </a>

                <div>
                    <label for="PageSizeDropDownList">Records per Page:</label>
                    <asp:DropDownList ID="PageSizeDropDownList" runat="server"
                        AutoPostBack="true" CssClass="btn btn-default btn-sm dropdown-toggle"
                        OnSelectedIndexChanged="PageSizeDropDownList_SelectedIndexChanged">
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="All" Value="10000" />
                    </asp:DropDownList>
                </div>

                <asp:GridView ID="StudentsGridView" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped table-hover" DataKeyNames="StudentID"
                    OnRowDeleting="StudentsGridView_RowDeleting" AllowPaging="true" PageSize="3"
                    OnPageIndexChanging="StudentsGridView_PageIndexChanging" AllowSorting="true"
                    OnSorting="StudentsGridView_Sorting" OnRowDataBound="StudentsGridView_RowDataBound"
                    PagerStyle-CssClass="pagination-ys">
                    <Columns>
                        <asp:BoundField DataField="StudentID" HeaderText="Week" Visible="true" SortExpression="StudentID" />
                        <asp:BoundField DataField="LastName" HeaderText="Team 1" Visible="true" SortExpression="LastName" />
                        <asp:BoundField DataField="FirstMidName" HeaderText="Team 2" Visible="true" SortExpression="FirstMidName" />
                        <asp:BoundField DataField="Enr" HeaderText="Team 1 Score" Visible="true" />
                        <asp:BoundField DataField="Enr" HeaderText="Team 2 Score" Visible="true" />
                        <asp:BoundField DataField="Enr" HeaderText="Winner" Visible="true" />


                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit"
                            NavigateUrl="~/Contoso/StudentDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm"
                            runat="server" DataNavigateUrlFields="StudentID"
                            DataNavigateUrlFormatString="StudentDetails.aspx?StudentID={0}" />

                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>
