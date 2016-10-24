<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddResult.aspx.cs" Inherits="GameTrack1.Game.AddResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Results</h1>
                <h5>All Fields are required</h5>
                <br />

              
                    <div class="form-group">
                    <label class="control-label" for="TeamFirstTextBox">Team 1</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="TeamFirstTextBox"
                        placeholder="my team" required="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="control-label" for="TeamSecondTextBox">Team 2</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamSecondTextBox"
                        placeholder="opposite team" required="true"></asp:TextBox>
                </div>
                 <div class="form-group">
                    <label class="control-label" for="ScoreFirstTextBox">Score for Team 1</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="ScoreFirstTextBox"
                        placeholder="Score" required="true"></asp:TextBox>
                </div>
                 <div class="form-group">
                    <label class="control-label" for="ScoreSecondTextBox">Score for Team 2</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="ScoreSecondTextBox"
                        placeholder="Score" required="true"></asp:TextBox>
                </div>

                    <div class="form-group">
                    <label class="control-label" for="WinnerTextBox">Winner</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="WinnerTextBox" 
                        placeholder="Winner" required="true"></asp:TextBox>

                </div>
              <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server"
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server"
                        OnClick="SaveButton_Click" />
                </div>

                
            </div>
        </div>
    </div>
</asp:Content>
