using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pages_CRUD
{
    public partial class ViewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool valid = true;

            //pull the id of the page from query
            string pageid = Request.QueryString["pageid"];

            //check if the id exists or not
            if (String.IsNullOrEmpty(pageid)) valid = false;

            //if yes than show summary
            if (valid)
            {
                var db = new HttpPages();
                Dictionary<String, String> page_details = db.SearchPage(Int32.Parse(pageid));

                if (page_details.Count > 0)
                {
                    page_title.InnerHtml = page_details["pagetitle"];
                    author_name.InnerHtml = page_details["author"];
                    creation_date.InnerHtml = page_details["creationdate"];
                    page_body.InnerHtml = page_details["pagebody"];

                }
                else
                {
                    valid = false;
                }
            }

            //if no than show error message.
            if (!valid)
            {
                page_view.InnerHtml = "There was an error finding that page.";
            }
        }
    }
}