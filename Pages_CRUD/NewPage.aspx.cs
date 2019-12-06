using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pages_CRUD
{
    public partial class NewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }
        public void Save_Page(object sender, EventArgs e)
        {

            Pages pg = new Pages();
            pg.Setpagetitle(pagetitle_input.Text.ToString());
            pg.Setpagebody(pagebody_input.Text.ToString());
            pg.Setauthorname(authorname_input.Text.ToString());
            //string query = "insert into pages(pagetitle,pagebody,creationdate) values('" + page_title + "'," + "'" + page_body + "'," + "current_date)";
            var db = new HttpPages();
            db.Addpage(pg);
            //db.PerformCRUD();
            Response.Redirect("ListPages.aspx");
        }
    }
}