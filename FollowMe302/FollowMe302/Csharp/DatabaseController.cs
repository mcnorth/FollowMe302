using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FollowMe302.Csharp
{
    public class DatabaseController
    {
        //variable for connection to database
        private SqlConnection con;

        public SqlConnection Con
        {
            get { return con; }
            set { con = value; }
        }

        public DatabaseController()
        {
            
        }

        //string for path to database 
        public SqlConnection ConnectToDatabase()
        {
            return new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");
        }
    }
}