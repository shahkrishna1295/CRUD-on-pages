using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pages_CRUD
{
    public partial class DeletePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;


            //We will attempt to get the record we need
            if (valid)
            {
                var db = new HttpPages();
                Dictionary<String, String> page_record = db.SearchPage(Int32.Parse(pageid));

                if (page_record.Count > 0)
                {
                    page_title.InnerHtml = page_record["pagetitle"];
                    page_body.InnerHtml = page_record["pagebody"];
                    author_name.InnerHtml = page_record["author"];
                    creation_date.InnerHtml = page_record["creationdate"];


                }
                else
                {
                    valid = false;
                }
            }

            if (!valid)
            {
                pages_result.InnerHtml = "There was an error finding that page.";
            }
        }

        protected void delete_function(object sender, EventArgs e)
        {
            //string query = "delete from pages where pageid=" + Request.QueryString["pageid"];
            var db = new HttpPages();
            
            string pageid = Request.QueryString["pageid"];
            db.Deletepage(pageid);
            Response.Redirect("ListPages.aspx");
        }
        protected void cancel_function(object sender, EventArgs e)
        {

            Response.Redirect("ListPages.aspx");
        }
    }
}