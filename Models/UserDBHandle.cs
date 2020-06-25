using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Project.Models
{
    public class UserDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            //string constring = @"Data Source=HAIER-pc;Initial Catalog=OOSEPROJECT;Integrated Security=True";
            string constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            con = new SqlConnection(constring); 
        }
        public bool AddUser(Employee login)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserName", login.UserName);
            cmd.Parameters.AddWithValue("@UserPassword", login.UserPassword);
            cmd.Parameters.AddWithValue("@type", login.UserType);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
      
        public List<Employee> GetLogins()
        {
            connection();
            List <Employee> UserList = new List<Employee>();
            SqlCommand cmd = new SqlCommand("GetUserDetails", con);
            cmd.CommandType =CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                UserList.Add(
                    new Employee
                    {
                        ID = Convert.ToInt32(dr["UserID"]),
                        UserName = Convert.ToString(dr["UserName"]),
                        UserPassword = Convert.ToString(dr["UserPassword"]),
                        UserType = Convert.ToString(dr["type"])
                    }
                    );
            }
            return UserList;
        }
        public bool UpdateDetails(Employee login)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.AddWithValue("@UserID", login.ID);
            cmd.Parameters.AddWithValue("@UserName", login.UserName);
            cmd.Parameters.AddWithValue("@UserPassword", login.UserPassword);
            cmd.Parameters.AddWithValue("@type", login.UserType);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
 
            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool DeleteUser(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.AddWithValue("@UserID", id);
 
            con.Open();
	            int i = cmd.ExecuteNonQuery();
	            con.Close();
	 
	            if (i >= 1)
	                return true;
	            else
	                return false;
	    }
	}
}