<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Basketball.aspx.cs" Inherits="GameTrack1.Basketball" %>
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

                <asp:GridView ID="GameGridView" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped table-hover" DataKeyNames="name"
                   OnRowDeleting="GameGridView_RowDeleting"
                    AllowPaging="true" PageSize="3"
                    OnPageIndexChanging="GameGridView_PageIndexChanging" AllowSorting="true"
                    OnSorting="GameGridView_Sorting" OnRowDataBound="GameGridView_RowDataBound"
                    PagerStyle-CssClass="pagination-ys">
                    <Columns>
                         <asp:BoundField DataField="name" HeaderText="Game name" Visible="true" SortExpression="name" />
                        <asp:BoundField DataField="week" HeaderText="Week" Visible="true" SortExpression="week" />
                        <asp:BoundField DataField="firstTeam" HeaderText="Team 1" Visible="true"  />
                        <asp:BoundField DataField="secondTeam" HeaderText="Team 2" Visible="true" />
                        <asp:BoundField DataField="scoreFirst" HeaderText="Team 1 Score" Visible="true" />
                        <asp:BoundField DataField="scoreSecond" HeaderText="Team 2 Score" Visible="true" />
                        <asp:BoundField DataField="winner" HeaderText="Winner" Visible="true" />


                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit"
                            NavigateUrl="~/Game/AddResult.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm"
                            runat="server" DataNavigateUrlFields="name"
                            DataNavigateUrlFormatString="AddResult.aspx?name={0}" />

                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>


</asp:Content>
