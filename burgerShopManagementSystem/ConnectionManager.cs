using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace burgerShopManagementSystem
{
   public class ConnectionManager
   {
        public static SqlConnection newCon;
        public static string constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        public static SqlConnection GetConnection() 
        {
            newCon = new SqlConnection(constr);
            return newCon;
        }
   }
}
