using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.ModelBinding;
using GameTrack1.Models;

namespace GameTrack1
{
    public partial class AddResult : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetGame();
            }
        }

       
        protected void CancelButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("Default.aspx");
        }

        protected void GetGame()
        {
            // populate the form with existing data from db
            var game =Request.QueryString["GameName"];
            var week = Convert.ToInt32(Request.QueryString["Week"]);

            // connect to the EF DB
            using (GameTrackerContext db = new GameTrackerContext())
            {
                // get todolist data from the query string
                Models.Basketball newBasketball = (from x in db.Basketballs
                                    where x.Week == week
                                    select x).FirstOrDefault();

                //if not emptyfill in the previous data
                if (newBasketball != null)
                {
                    var x = "Basketball";
                    x = newBasketball.GameName;
                    TeamFirstTextBox.Text = newBasketball.TeamOne;
                    TeamSecondTextBox.Text = newBasketball.TeamTwo;
                    Convert.ToInt32(ScoreFirstTextBox.Text) = newBasketball.ScoreOne;
                    Convert.ToInt32(ScoreSecondTextBox.Text) = newBasketball.ScoreTwo;
                    WinnerTextBox.Text = newBasketball.Winner;
                }

            }
            }
        
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (GameTrackerContext db = new GameTrackerContext())
            {
                var Game = "";
                // create new todo object
                // save a new record
              
                {
                    Game = Request.QueryString["GameName"];
                    switch (Game)
                    {
                        case "Basketball":
                            Models.Basketball newBasketball = new Models.Basketball();

                            if (Request.QueryString.Count > 0)
                            {
                                newBasketball.GameName = "Basketball";
                                newBasketball.TeamOne = TeamFirstTextBox.Text;
                                newBasketball.TeamTwo = TeamSecondTextBox.Text;
                                newBasketball.ScoreOne = Convert.ToInt32(ScoreFirstTextBox.Text);
                                newBasketball.ScoreTwo = Convert.ToInt32(ScoreSecondTextBox.Text);
                                newBasketball.Winner = WinnerTextBox.Text;
                            }
                            if (Game == "")
                            {
                                db.Basketballs.Add(newBasketball);
                            }
                            Response.Redirect("Basketball.aspx");
                            break;

                    }
                }


            }
        }
    }
}