using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SchoolDataEditing
{
    public class clsMasterActivity : clsGenral
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt;

        #region :: Property ::
        string _userId;
        string _district;
        string _block;
        string _cluster;
        string _village;
        string _parameter;
        double _SerialID;
        int _districtId;
        int _siCode;
        int _siCodeOther;
        string _category;
        DateTime _date1;
        DateTime _date2;

        string _siName;
        double _Code;
        double _siContactNumber;
        string _role;
        string _isActive;
        string _mode;

        double _schoolId;
        string _schoolCategory;
        string _indexNo;
        string _schoolMgmt;
        double _std9FRC;
        double _std10FRC;
        string _schoolMedium;



        string _schoolName;
        string _schoolType;
        string _taluka;
        string _schoolAddress;
        string _schoolManagement;
        string _que1;
        string _que2;
        string _que3;
        string _board;
        string _status;

        public string Status { get { return _status; } set { _status = value; } }
        public string Board { get { return _board; } set { _board = value; } }
        public string SchoolName { get { return _schoolName; } set { _schoolName = value; } }
         public string Que1 { get { return _que1; } set { _que1 = value; } }
         public string Que2 { get { return _que2; } set { _que2 = value; } }
         public string Que3 { get { return _que3; } set { _que3 = value; } }

        public string SchoolType { get { return _schoolType; } set { _schoolType = value; } }
        public string Taluka { get { return _taluka; } set { _taluka = value; } }
        public string SchoolAddress { get { return _schoolAddress; } set { _schoolAddress = value; } }
        public string SchoolManagement { get { return _schoolManagement; } set { _schoolManagement = value; } }


        public string userId { get { return _userId; } set { _userId = value; } }
        public string district { get { return _district; } set { _district = value; } }
        public string block { get { return _block; } set { _block = value; } }
        public string cluster { get { return _cluster; } set { _cluster = value; } }
        public string village { get { return _village; } set { _village = value; } }
        public string parameter { get { return _parameter; } set { _parameter = value; } }
        public double SerialID { get { return _SerialID; } set { _SerialID = value;} }
        public Int32 DistrictId { get { return _districtId; } set { _districtId = value;} }
        public Int32 SiCode { get { return _siCode; } set { _siCode = value;} }
        public Int32 SiCodeOther { get { return _siCodeOther; } set { _siCodeOther = value;} }
        public string Category { get { return _category; } set { _category = value; } }
        public DateTime Date1 { get { return _date1; } set { _date1 = value; } }
        public DateTime Date2 { get { return _date2; } set { _date2 = value; } }




        public double SchoolId { get { return _schoolId; } set { _schoolId = value; } }
        public string SchoolMgmt { get { return _schoolMgmt; } set { _schoolMgmt = value; } }
        public string IndexNo { get { return _indexNo; } set { _indexNo = value; } }
        public string SchoolCategory { get { return _schoolCategory; } set { _schoolCategory = value; } }
        public double Std9FRC { get { return _std9FRC; } set { _std9FRC = value; } }
        public double Std10FRC { get { return _std10FRC; } set { _std10FRC = value; } }
        public string SchoolMedium { get { return _schoolMedium; } set { _schoolMedium = value; } }

        #endregion

        #region :: GET METHODS ::

        public DataTable getSchoolsByDistrict()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@districtId", DistrictId);
                cmd.CommandText = "GetSchoolsByDistrict";
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

        public DataTable getSchoolsByDistrictFront()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@districtId", DistrictId);
                cmd.Parameters.AddWithValue("@board", Board);
                cmd.Parameters.AddWithValue("@management", SchoolManagement);
                cmd.Parameters.AddWithValue("@status", Status);

                cmd.CommandText = "GetSchoolsByDistrictMaster";
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


        public DataTable getSchoolsByDeleteFront()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@districtId", DistrictId);
                cmd.CommandText = "GetSchoolsByDeletdStatus";
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

        public DataSet getCount()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@districtId", DistrictId);
                cmd.CommandText = "getCount";
                cmd.Connection = CN;
                if (CN.State == ConnectionState.Closed)
                {
                    CN.Open();
                }
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                CN.Close();
            }
            catch (Exception) { }
            return ds;
        }


        public DataTable getSchoolsByUDIS()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@school_Id", SchoolId);
                cmd.CommandText = "getSchoolsByUDIS";
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

        public DataTable getSchoolGridByUDIS()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@school_Id", SchoolId);
                cmd.CommandText = "getSchoolGridByUDIS";
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

        public DataTable getDeletedSchoolsByUDIS()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@School_Id", SchoolId );
                cmd.CommandText = "getDeletedSchoolsByUDIS";
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
        public DataTable delSchool()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@school_Id", SchoolId);
                cmd.CommandText = "sp_delSchool";
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


        public DataTable getAllDistrict()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllDistrict";
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

        public DataTable getBlockByDistrict()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@district", district);
                cmd.CommandText = "getBlockByDistrict";
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

        public DataTable getClusterByBlock()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@block", block);
                cmd.CommandText = "getClusterByBlock";
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

        public DataTable getVillageByCluster()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cluster", cluster);
                cmd.CommandText = "getVillageByCluster";
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

        public DataTable getSearchGrid()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@parameter", parameter);
                cmd.CommandText = "getSearchGrid";
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

        public DataTable getSISearchGrid()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getSISearchGrid";
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


        #endregion

        #region :: INSERT METHODS ::

        public DataTable updData()
        {
            try
            {
            }
            catch (Exception) { }
            return dt;
        }


        public DataTable insDtlsData()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SchoolId", SchoolId);
                cmd.Parameters.AddWithValue("@SchoolCategory", SchoolCategory);
                cmd.Parameters.AddWithValue("@IndexNo", IndexNo);
                cmd.Parameters.AddWithValue("@SchoolMgmt", SchoolMgmt);
                cmd.Parameters.AddWithValue("@Std9FRC", Std9FRC);
                cmd.Parameters.AddWithValue("@Std10FRC", Std10FRC);
                cmd.Parameters.AddWithValue("@SchoolMedium", SchoolMedium);

                //cmd.Parameters.AddWithValue("@UpdatedTimeStamp", UpdatedTimeStamp);


                cmd.CommandText = "insDtlsData";
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

        public DataTable delDtlsGrid()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@school_Id", SchoolId);
              

                //cmd.Parameters.AddWithValue("@UpdatedTimeStamp", UpdatedTimeStamp);


                cmd.CommandText = "delDtlsGrid";
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
        
        public DataTable UpsertSchool()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SchoolUDISECode", SchoolId);
                cmd.Parameters.AddWithValue("@SchoolType", SchoolType);
                cmd.Parameters.AddWithValue("@District", district);
                cmd.Parameters.AddWithValue("@Taluka", Taluka);
                cmd.Parameters.AddWithValue("@SchoolName", SchoolName);
                cmd.Parameters.AddWithValue("@SchoolManagement", SchoolManagement);
                cmd.Parameters.AddWithValue("@SchoolAddress", SchoolAddress);
                cmd.Parameters.AddWithValue("@Que1", Que1);
                cmd.Parameters.AddWithValue("@Que2", Que2);
                cmd.Parameters.AddWithValue("@Que3", Que3);

                //cmd.Parameters.AddWithValue("@UpdatedTimeStamp", UpdatedTimeStamp);


                cmd.CommandText = "UpsertSchool";
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


        //public DataTable insSIData()
        //{
        //    try
        //    {
        //        cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@SiName", SiName);
        //        cmd.Parameters.AddWithValue("@SiCode", SiCode);
        //        cmd.Parameters.AddWithValue("@ContactNumber", ContactNumber);
        //        cmd.Parameters.AddWithValue("@Role", Role);
        //        cmd.Parameters.AddWithValue("@ISACTIVE", ISACTIVE);
        //        cmd.Parameters.AddWithValue("@Mode", Mode);
        //        //cmd.Parameters.AddWithValue("@UpdatedTimeStamp", UpdatedTimeStamp);


        //        cmd.CommandText = "insSIData";
        //        cmd.Connection = CN;
        //        if (CN.State == ConnectionState.Closed)
        //        {
        //            CN.Open();
        //        }
        //        da = new SqlDataAdapter(cmd);
        //        dt = new DataTable();
        //        da.Fill(dt);
        //        CN.Close();
        //    }
        //    catch (Exception) { }
        //    return dt;
        //}



        #endregion
    }
}