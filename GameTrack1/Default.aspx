<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GameTrack1.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="conatainer">
        <div class="row">
            <div class="col-md-offset-4 col-md-6">
                <h1>Welcome to Game Tracker!</h1>
                <div class="container-fluid">
   <div class="row">
	<img src="Assets/images/1logo.PNG" class="img-responsive">
   </div>
</div>

               <a href="Game/Cricket.aspx"> <img src="Assets/images/cricket.jpg" class="img-rounded m-x-auto d-block"width="300" alt="cricket" ></a>
               <a href="Game/Hockey.aspx"> <img src="Assets/images/hockey.jpg" class="img-rounded m-x-auto d-block" width="300"alt="hockey"></a>
              
               <a href="Game/Tennis.aspx"> <img src="Assets/images/tennis.jpg" class="img-rounded m-x-auto d-block" width="300"alt="tennis"></a>
               <a href="Game/Basketball.aspx"> <img src="Assets/images/basketball.jpg" class="img-rounded m-x-auto d-block" width="300" alt="basketball"></a>

            </div>
        </div>
    </div>
    
</asp:Content>
