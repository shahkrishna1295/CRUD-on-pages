using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pages_CRUD
{
    public class Pages
    {
        private string pagetitle;
        private string pagebody;
        private string authorname;

        public void Setpagetitle(string value)
        {
            this.pagetitle = value;
        }
        public void Setpagebody(string value)
        {
            this.pagebody = value;
        }
        public void Setauthorname(string value)
        {
            this.authorname = value;
        }
        public string Getpagetitle()
        {
            return pagetitle;
        }
        public string Getpagebody()
        {
            return pagebody;
        }
        public string Getauthorname()
        {
            return authorname;
        }

    }
}