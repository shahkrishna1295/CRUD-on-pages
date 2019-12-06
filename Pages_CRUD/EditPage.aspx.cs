using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pages_CRUD
{
    public partial class EditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    string page_record = Request.QueryString["pageid"];
                    var db = new HttpPages();
                    
                    Pages pg = new Pages();

                    pg.Setpagetitle(pagetitle_input.Text.ToString());
                    pg.Setpagebody(pagebody_input.Text.ToString());
                    pg.Setauthorname(authorname_input.Text.ToString());

                    db.Updatepage(pg, page_record);
                    Response.Redirect("ListPages.aspx");
                }
            }
            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            if (valid)
            {
                var db = new HttpPages();
                Dictionary<String, String> page_record = db.SearchPage(Int32.Parse(pageid));

                if (page_record.Count > 0)
                {
                    pagetitle_input.Text = page_record["pagetitle"];
                    pagebody_input.Text = page_record["pagebody"];
                    authorname_input.Text = page_record["author"];
                }
                else
                {
                    valid = false;
                }
            }

            if (!valid)
            {
                pages_result.InnerHtml = "There was an error finding that page!.";
            }
        }
    }
}