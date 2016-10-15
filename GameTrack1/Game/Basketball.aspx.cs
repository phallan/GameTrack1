using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GameTrack1.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace GameTrack1
{
    public partial class Basketball : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // if loading the page for the first time
            // populate the student grid
            if (!IsPostBack)
            {
                Session["SortColumn"] = "name"; // default sort column
                Session["SortDirection"] = "ASC";

                // Get the student data
                this.GetName();
            }
        }

               private void GetName()
        {
            // connect to EF DB
            using (GameTrackerContext db = new GameTrackerContext())
            {
                string SortString = Session["SortColumn"].ToString() + " " +
                    Session["SortDirection"].ToString();

                // query the Student Table using EF and LINQ
                var Basketball = (from a in db.Games
                                  where a.name == "Basketball"
                                  select a);

                // bind the result to the Students GridView
                GameGridView.DataSource = Basketball.AsQueryable().OrderBy(SortString).ToList();
           GameGridView.DataBind();
            }
        }

        protected void GameGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            // Set the new page number
            GameGridView.PageIndex = e.NewPageIndex;

            // refresh the Gridview
            this.GetName();

        }
       

       protected void GameGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            // store which row was clicked
            int selectedRow = e.RowIndex;
            
            // get the selected StudentID using the Grid's DataKey collection
            String Week = GameGridView.DataKeys[selectedRow].Values["week"] + "";

            // use EF and LINQ to find the selected student in the DB and remove it
            using (GameTrackerContext db = new GameTrackerContext())
            {
               
                // create object ot the student clas and store the query inside of it
             Models.Game deletedGame    = (from GameRecords in db.Games
                                     where GameRecords.week == Week
                                     select GameRecords).FirstOrDefault();

                // remove the selected student from the db
                db.Games.Remove(deletedGame);
               
                // save my changes back to the db
                db.SaveChanges();

                // refresh the grid
                this.GetName();

            }
        }

        protected void GameGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["SortColumn"] = e.SortExpression;

            // refresh the GridView
            this.GetName();

            // toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        protected void GameGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header) // if header row has been clicked
                {
                    LinkButton linkbutton = new LinkButton();

                    for (int index = 0; index < GameGridView.Columns.Count - 1; index++)
                    {
                        if (GameGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkbutton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkbutton.Text = " <i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkbutton);
                        }
                    }
                }
            }
        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set the new Page size
            GameGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            // refresh the GridView
            this.GetName();

        }
    }
}