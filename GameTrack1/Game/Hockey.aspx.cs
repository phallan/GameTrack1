using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameTrack1.Models;
using System.Linq.Dynamic;


namespace GameTrack1
{
    public partial class Hockey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortColumn"] = "Week"; // default sort column
                Session["SortDirection"] = "ASC";

                // Get data
                this.GetGame();

            }

        }
        private void GetGame()
        {
            using (GameTrackerContext db = new GameTrackerContext())
            {
                string SortString = Session["SortColumn"].ToString() + " " +
                    Session["SortDirection"].ToString();

                // query todo table using EF and LINQ
                var bb = (from b in db.Hockeys
                          select b);

                // bind the result to the todo GridView
                GameGridView.DataSource = bb.AsQueryable().OrderBy(SortString).ToList();
                GameGridView.DataBind();
            }
        }

        protected void GameGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex;


            int Week = Convert.ToInt32(GameGridView.DataKeys[selectedRow].Values["Week"]);


            using (GameTrackerContext db = new GameTrackerContext())
            {

                Models.Hockey deletedbb = (from todoR in db.Hockeys
                                           where todoR.Week == Week
                                           select todoR).FirstOrDefault();


                db.Hockeys.Remove(deletedbb);



                db.SaveChanges();


                this.GetGame();
            }
        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            // refresh the GridView
            this.GetGame();
        }

        protected void GameGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GameGridView.PageIndex = e.NewPageIndex;

            // refresh the Gridview
            this.GetGame();
        }

        protected void GameGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["SortColumn"] = e.SortExpression;

            // refresh the GridView
            this.GetGame();

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
    }
}