using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSV2
{
     class Godaddy
    {
        //singleton has a reference to itself
        private static Godaddy dbconec;
        string strconnection;
        private Godaddy() {}//private constructor so that it cannot be instantiated outside this class

        //grabs instance of singleton pattern
        public static Godaddy GetInstance()
        {
            if (dbconec == null) //check if  an instance has been created else  can create a new instance
            {
                dbconec = new Godaddy();
            }
            return dbconec;
        }
        public string myconnectDB() {
            return strconnection;
        }
        public string connectDB(string conn) //Database connection 
        {
            strconnection = conn;
            return conn;
            /*
            try
            {

                //create a string connection
                string strconnection;
                strconnection = "Server=x.x.x.x;Database =xxx;Uid = xxx;Password =xxx;CharSet=utf8;Connect Timeout=60;";
                //initialize the connection to DB
                MySqlConnection conn = new MySqlConnection(strconnection);

                conn.Open();

                return strconnection;

                //conn.Close();

            }

            catch (Exception ex)
            {

                return ex.Message;
            }
            */

        }

        ////
    }


}
