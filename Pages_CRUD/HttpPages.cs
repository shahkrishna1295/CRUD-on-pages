using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Pages_CRUD
{
    public class HttpPages
    {
        //variables to store the information for connection to db
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "http_page"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "	3308"; } }

        //ConnectionString is to connect to a database
        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }

        //method to list out the pages
        public List<Dictionary<String, String>> Page_List(string query)
        {
            //creating the db connection object
            MySqlConnection dbConnect = new MySqlConnection(ConnectionString);

            //object to store the results
            List<Dictionary<String, String>> Result_Set = new List<Dictionary<String, String>>();

            try
            {
                //first open the db connection
                dbConnect.Open();

                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);
                                
                //pass query fetched while calling the method to the db
                //initialize the instance to send the query
                MySqlCommand sqlcmd = new MySqlCommand(query, dbConnect);

                //fetch the result
                MySqlDataReader result_set = sqlcmd.ExecuteReader();

                //for every row in the result set
                while (result_set.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();
                    //for every column in the row
                    for (int i = 0; i < result_set.FieldCount; i++)
                    {
                        Row.Add(result_set.GetName(i), result_set.GetString(i));

                    }

                    Result_Set.Add(Row);
                }//end row

                result_set.Close();
                
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Something went wrong in the Pages List method!");
                Debug.WriteLine(ex.ToString());

            }

            //close the db connection
            dbConnect.Close();

            Debug.WriteLine("Database Connection Terminated.");

            return Result_Set;
            
        }//end of list pages

        //method for search page
        public Dictionary<String, String> SearchPage(int id)
        {
            //making connection to db by connection string
            MySqlConnection dbConnect = new MySqlConnection(ConnectionString);

           //creating empty student string 
            Dictionary<String, String> page = new Dictionary<String, String>();

            //try, to fetch the student if not than go to catch 
            try
            {
                //select particular page from  its id
                string query = "select * from pages where pageid = " + id;
                Debug.WriteLine("Connection Initialized...");
                
                dbConnect.Open();

                MySqlCommand cmd = new MySqlCommand(query, dbConnect);
                MySqlDataReader resultset = cmd.ExecuteReader();

                //make a list for pages 
                List<Dictionary<String, String>> Pages = new List<Dictionary<String, String>>();

                //read through the result set
                while (resultset.Read())
                {
                    //creating instance that will store a page
                    Dictionary<String, String> Page = new Dictionary<String, String>();

                    //getting the resultset in row and column
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Page.Add(resultset.GetName(i), resultset.GetString(i));

                    }
                    //Add the student to the list of students
                    Pages.Add(Page);
                }

                page = Pages[0]; //get the first page

            }
            catch (Exception ex)
            {
                //If something (anything) goes wrong with the try{} block, this block will execute
                Debug.WriteLine("Something went wrong in the find Page method!");
                Debug.WriteLine(ex.ToString());
            }

            dbConnect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return page;
        }
        public Dictionary<String, String> PageSummary(int id)
        {
            
            MySqlConnection dbConnect = new MySqlConnection(ConnectionString);
            
            Dictionary<String, String> page = new Dictionary<String, String>();

            
            try
            {
                
                string query = "select * from pages where studentid = " + id;
                Debug.WriteLine("Connection Initialized...");
                //open the db connection
                dbConnect.Open();
                
                //Pass the query to the database
                MySqlCommand cmd = new MySqlCommand(query, dbConnect);
                
                //retrive the result set
                MySqlDataReader resultset = cmd.ExecuteReader();

                //Create a list of pages
                List<Dictionary<String, String>> Pages = new List<Dictionary<String, String>>();

                //read through the result set
                while (resultset.Read())
                {
                    //information that will store a single page
                    Dictionary<String, String> Page = new Dictionary<String, String>();

                    
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Debug.WriteLine("Attempting to transfer data of " + resultset.GetName(i));
                        Debug.WriteLine("Attempting to transfer data of " + resultset.GetString(i));
                        Page.Add(resultset.GetName(i), resultset.GetString(i));

                    }
                    
                    Pages.Add(Page);
                }

                page = Pages[0]; 

            }
            catch (Exception ex)
            {
                //If something (anything) goes wrong with the try{} block, this block will execute
                Debug.WriteLine("Something went wrong in to Page Summary method!");
                Debug.WriteLine(ex.ToString());
            }

            dbConnect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return page;
        }

        public void Addpage(Pages pg)
        {
            //instance for the connection with db
            MySqlConnection dbConnect = new MySqlConnection(ConnectionString);

            //open the connection
            dbConnect.Open();

           

            //query to insert the data
            string query = "insert into pages(pagetitle,pagebody,author,creationdate) values('{0}','{1}','{2}',now())";

            query = string.Format(query,pg.Getpagetitle(),pg.Getpagebody(),pg.Getauthorname());

            //instance that passes the required query to the db
            //string query = "insert into pages(pagetitle,pagebody,creationdate) values('" + pg.Getpagetitle() + "'," + "'" + pg.Getpagebody() + "'," + "now())";
            MySqlCommand cmd = new MySqlCommand(query, dbConnect);

            cmd.ExecuteNonQuery();
            //execution of the query
            
        }

        public void Updatepage(Pages pg,string pageid)
        {
            //instance for the connection with db
            MySqlConnection dbConnect = new MySqlConnection(ConnectionString);

            //open the connection
            dbConnect.Open();

            string query = "update pages set pagetitle = '{0}', pagebody = '{1}', author = '{2}' where pageid = '{3}'";
            query = string.Format(query, pg.Getpagetitle(), pg.Getpagebody(),pg.Getauthorname(),pageid);
          
            MySqlCommand cmd = new MySqlCommand(query, dbConnect);

            cmd.ExecuteNonQuery();
            //execution of the query
            
        }

        public  void Deletepage(string pageid)
        {
            MySqlConnection dbConnect = new MySqlConnection(ConnectionString);

            //open the connection
            dbConnect.Open();

            
            string query = "delete from pages where pageid = '{0}'";
            query = string.Format(query, pageid);

            MySqlCommand cmd = new MySqlCommand(query, dbConnect);

            //execution of the query
            cmd.ExecuteNonQuery();     

        }

    }
}