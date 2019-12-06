using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pages_CRUD
{
    public partial class FeaturedPages : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpPages db = new HttpPages();
            ListFeaturedPages(db);
        }

        protected void ListFeaturedPages(HttpPages db)
        {
            //featured_pages.InnerHtml = "Hello";
            //query the most popular classes (most students)
            string query = "select * from pages";

            //to redirect to list of pages from anywhere
            featured_pages.InnerHtml += "<div><a href=\"ListPages.aspx\">Home</a></div>";

            List<Dictionary<String, String>> rs = db.Page_List(query);

            foreach (Dictionary<String, String> row in rs)
            {
                string pageid = row["pageid"];

                string pagetitle = row["pagetitle"];
                featured_pages.InnerHtml += "<div><a href=\"ViewPage.aspx?pageid=" + pageid + "\">" + pagetitle + "</a></div> ";
            }
            
        }
    }
}