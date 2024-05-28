using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SchoolDataEditing
{
    public class LoginCS : clsGenral
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        #region :: Property ::
        string _userId;
        string _password;
        double _school_id;

        public string userId { get { return _userId; } set { _userId = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public double School_id { get { return _school_id; } set { _school_id = value; } }

        #endregion

        #region :: METHODS ::
        public LoginCS()
        {

        }

        public DataTable LoginUser()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Login";
                cmd.Connection = CN;
                cmd.Parameters.AddWithValue("@UserId", userId);
                if(Password != "") { 
                cmd.Parameters.AddWithValue("@Password", (Password));
                }else
                {
                    cmd.Parameters.AddWithValue("@Password", DBNull.Value);
                }
                if (CN.State == ConnectionState.Closed)
                {
                    CN.Open();
                }
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                CN.Close();
            }
            catch (Exception) { }
            return dt;
        }

        public DataTable chkPhase()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GetPhase";
                cmd.Connection = CN;
                if (CN.State == ConnectionState.Closed)
                {
                    CN.Open();
                }
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                CN.Close();
            }
            catch (Exception) { }
            return dt;
        }


        public DataTable ChangePassword()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_changePwd";
                cmd.Connection = CN;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Password", EncodePasswordToBase64(Password));
                if (CN.State == ConnectionState.Closed)
                {
                    CN.Open();
                }
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                CN.Close();
            }
            catch (Exception) { }
            return dt;
        }

        public DataTable getSchoolById()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_getSchoolById";
                cmd.Connection = CN;
                cmd.Parameters.AddWithValue("@school_id", School_id);
                if (CN.State == ConnectionState.Closed)
                {
                    CN.Open();
                }
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                CN.Close();
            }
            catch (Exception) { }
            return dt;
        }
        #endregion

    }
}