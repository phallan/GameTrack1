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
                switch (game)
                {
                    case "Basketball":
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
                        break;
                    case "Cricket":
                        Models.Cricket newCricket = (from x in db.Crickets
                                                           where x.Week == week
                                                           select x).FirstOrDefault();

                        //if not emptyfill in the previous data
                        if (newCricket != null)
                        {
                            var x = "Cricket";
                            x = newCricket.GameName;
                            TeamFirstTextBox.Text = newCricket.TeamOne;
                            TeamSecondTextBox.Text = newCricket.TeamTwo;
                            Convert.ToInt32(ScoreFirstTextBox.Text) = newCricket.ScoreOne;
                            Convert.ToInt32(ScoreSecondTextBox.Text) = newCricket.ScoreTwo;
                            WinnerTextBox.Text = newCricket.Winner;

                        }
                        break;
                    case "Hockey":
                        Models.Hockey newHockey = (from x in db.Hockeys
                                                           where x.Week == week
                                                           select x).FirstOrDefault();

                        //if not emptyfill in the previous data
                        if (newHockey != null)
                        {
                            var x = "Hockey";
                            x = newHockey.GameName;
                            TeamFirstTextBox.Text = newHockey.TeamOne;
                            TeamSecondTextBox.Text = newHockey.TeamTwo;
                            Convert.ToInt32(ScoreFirstTextBox.Text) = newHockey.ScoreOne;
                            Convert.ToInt32(ScoreSecondTextBox.Text) = newHockey.ScoreTwo;
                            WinnerTextBox.Text = newHockey.Winner;

                        }
                        break;
                    case "Tennis":
                        Models.Tenni newTennis = (from x in db.Tennis
                                                   where x.Week == week
                                                   select x).FirstOrDefault();

                        //if not emptyfill in the previous data
                        if (newTennis != null)
                        {
                            var x = "Tennis";
                            x = newTennis.GameName;
                            TeamFirstTextBox.Text = newTennis.TeamOne;
                            TeamSecondTextBox.Text = newTennis.TeamTwo;
                            Convert.ToInt32(ScoreFirstTextBox.Text) = newTennis.ScoreOne;
                            Convert.ToInt32(ScoreSecondTextBox.Text) = newTennis.ScoreTwo;
                            WinnerTextBox.Text = newTennis.Winner;

                        }
                        break;
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
                        case "Cricket":
                            Models.Cricket newCricket = new Models.Cricket();

                            if (Request.QueryString.Count > 0)
                            {
                                newCricket.GameName = "Basketball";
                                newCricket.TeamOne = TeamFirstTextBox.Text;
                                newCricket.TeamTwo = TeamSecondTextBox.Text;
                                newCricket.ScoreOne = Convert.ToInt32(ScoreFirstTextBox.Text);
                                newCricket.ScoreTwo = Convert.ToInt32(ScoreSecondTextBox.Text);
                                newCricket.Winner = WinnerTextBox.Text;
                            }
                            if (Game == "")
                            {
                                db.Crickets.Add(newCricket);
                            }
                            Response.Redirect("Cricket.aspx");
                            break;
                        case "Hockey":
                            Models.Hockey newHockey = new Models.Hockey();

                            if (Request.QueryString.Count > 0)
                            {
                                newHockey.GameName = "Basketball";
                                newHockey.TeamOne = TeamFirstTextBox.Text;
                                newHockey.TeamTwo = TeamSecondTextBox.Text;
                                newHockey.ScoreOne = Convert.ToInt32(ScoreFirstTextBox.Text);
                                newHockey.ScoreTwo = Convert.ToInt32(ScoreSecondTextBox.Text);
                                newHockey.Winner = WinnerTextBox.Text;
                            }
                            if (Game == "")
                            {
                                db.Hockeys.Add(newHockey);
                            }
                            Response.Redirect("Cricket.aspx");
                            break;
                        case "Tennis":
                            Models.Tenni newTennis = new Models.Tenni();

                            if (Request.QueryString.Count > 0)
                            {
                                newTennis.GameName = "Basketball";
                                newTennis.TeamOne = TeamFirstTextBox.Text;
                                newTennis.TeamTwo = TeamSecondTextBox.Text;
                                newTennis.ScoreOne = Convert.ToInt32(ScoreFirstTextBox.Text);
                                newTennis.ScoreTwo = Convert.ToInt32(ScoreSecondTextBox.Text);
                                newTennis.Winner = WinnerTextBox.Text;
                            }
                            if (Game == "")
                            {
                                db.Tennis.Add(newTennis);
                            }
                            Response.Redirect("Tennis.aspx");
                            break;
                    }
                }


            }
        }
    }
}