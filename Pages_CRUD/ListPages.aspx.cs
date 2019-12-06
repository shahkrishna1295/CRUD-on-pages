using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pages_CRUD
{
    public partial class ListPages1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //resets the result set window
            pages_result.InnerHtml = "";

            string searchkey = "";
            if (Page.IsPostBack)
            {
                
                searchkey = page_search.Text;
            }


            string query = "select * from pages";

            if (searchkey != "")
            {
                query += " WHERE pagetitle like '%" + searchkey + "%' order by author ";

            }

           
            var db = new HttpPages();
            List<Dictionary<String, String>> rs = db.Page_List(query);
            foreach (Dictionary<String, String> row in rs)
            {
                pages_result.InnerHtml += "<div class=\"listitem\">";

                string pageid = row["pageid"];

                string pagetitle = row["pagetitle"];
                pages_result.InnerHtml += "<div class=\"col5\"><a href=\"ViewPage.aspx?pageid=" + pageid + "\">" + pagetitle + "</a></div>";

                string pagebody = row["pagebody"];
                pages_result.InnerHtml += "<div class=\"col5\">" + pagebody + "</div>";

                string authorname = row["author"];
                pages_result.InnerHtml += "<div class=\"col5\">" + authorname + "</div>";

                string creationdate = row["creationdate"];
                pages_result.InnerHtml += "<div class=\"col5\">" + creationdate  + "</div>";

                pages_result.InnerHtml += "<div class=\"col5last\"><a href=\"EditPage.aspx?pageid=" + pageid + "\">Edit / </a><a href=\"DeletePage.aspx?pageid=" + pageid + "\">Delete</a></div>";
                pages_result.InnerHtml += "</div>";
            }

        }
        //method to redirect to insert input form
        protected void Add_Page(object sender, EventArgs e)
        {
            Response.Redirect("NewPage.aspx");
        }

        //method to redirect to update input form
        protected void Edit_Page(object sender, EventArgs e)
        {
            Response.Redirect("EditPage.aspx");
        }
    }
}