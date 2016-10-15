using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameTrack1.Models;
using System.Web.ModelBinding;

namespace GameTrack1
{
    public partial class AddResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetName();
            }
        }

        protected void GetName()
        {

            // populate the form with existing data from db
            

            // connect to the EF DB
            using (GameTrackerContext db = new GameTrackerContext())
            {
                string week =Request.QueryString["Week"];
                // populate a student object instance with the StudentID from 
                // the URL parameter
                Models.Game updatedGame = (from GameRecords in db.Games
                                           where GameRecords.week == week
                                           select GameRecords).FirstOrDefault();

                // map the student properties to the form control
                if (updatedGame != null)
                {
               
                    TeamFirstTextBox.Text =updatedGame.firstTeam ;
                    TeamSecondTextBox.Text = updatedGame.secondTeam;
                    TeamFirstTextBox.Text = updatedGame.firstTeam;
                    ScoreFirstTextBox.Text = updatedGame.scoreFirst;
                    ScoreSecondTextBox.Text = updatedGame.scoreSecond;
                    WinnerTextBox.Text = updatedGame.winner;

                }
            }
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
         
            Response.Redirect("~/Game/Basketball.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to conect to the server
            using (GameTrackerContext db = new GameTrackerContext())
            {
                // use the student model to create a new student object and 
                // save a new record

                Models.Game updatedGame = new Models.Game();

                string week= "";

                if (Request.QueryString.Count > 0) // our URL has a STUDENTID in it
                {
                    // get the id from the URL
                     week= (Request.QueryString["StudentID"]);

                    // get the current student from EF db
                    updatedGame = (from x in db.Games
                                  where x.week == week
                                  select x).FirstOrDefault();
                }

                // add form data to the new student record


           updatedGame.firstTeam = TeamFirstTextBox.Text;
                 updatedGame.secondTeam= TeamSecondTextBox.Text;
                  updatedGame.firstTeam=TeamFirstTextBox.Text;
                updatedGame.scoreFirst =ScoreFirstTextBox.Text;
                  updatedGame.scoreSecond=ScoreSecondTextBox.Text;
                 updatedGame.winner= WinnerTextBox.Text;


                // use LINQ to ADO.NET to add / insert new student into the db

                if (week == "")
                {
                    db.Games.Add(updatedGame);
                }

                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/Game/Basketball.aspx");
            }
}