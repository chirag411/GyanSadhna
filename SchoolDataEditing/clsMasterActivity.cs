using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Runtime.CompilerServices;
using System.Data.OleDb;

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
        string _aadharUID;



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
        string _bankStatementPath;
        string _consentPath;

        //Variables for New properties
        string _isContinuingSameSchool;
        string _isRegSchool2024;
        string _reasonForLeaving;
        string _is80PercentAttendance;
        string _isReceived2Installments;
        string _newDISECode;
        string _isDistrictTransfer;
        string _oldSchoolDISECode;
        string _oldSchoolName;
        string _oldSchoolTypeName;
        string _oldDistrictName;
        string _oldBlockName;

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
        public double SerialID { get { return _SerialID; } set { _SerialID = value; } }
        public Int32 DistrictId { get { return _districtId; } set { _districtId = value; } }
        public Int32 SiCode { get { return _siCode; } set { _siCode = value; } }
        public Int32 SiCodeOther { get { return _siCodeOther; } set { _siCodeOther = value; } }
        public string Category { get { return _category; } set { _category = value; } }
        public DateTime Date1 { get { return _date1; } set { _date1 = value; } }
        public DateTime Date2 { get { return _date2; } set { _date2 = value; } }

        public string ConsentPath { get { return _consentPath; } set { _consentPath = value; } }
        public string BankStatementPath { get { return _bankStatementPath; } set { _bankStatementPath = value; } }
        public string AadharUID { get { return _aadharUID; } set { _aadharUID = value; } }
        public double SchoolId { get { return _schoolId; } set { _schoolId = value; } }
        public string SchoolMgmt { get { return _schoolMgmt; } set { _schoolMgmt = value; } }
        public string IndexNo { get { return _indexNo; } set { _indexNo = value; } }
        public string SchoolCategory { get { return _schoolCategory; } set { _schoolCategory = value; } }
        public double Std9FRC { get { return _std9FRC; } set { _std9FRC = value; } }
        public double Std10FRC { get { return _std10FRC; } set { _std10FRC = value; } }
        public string SchoolMedium { get { return _schoolMedium; } set { _schoolMedium = value; } }

        #region :: New Added ::
        //New Variables get set for New properties
        public string isContinuingSameSchool { get { return _isContinuingSameSchool; } set { _isContinuingSameSchool = value; } }
        public string isRegSchool2024 { get { return _isRegSchool2024; } set { _isRegSchool2024 = value; } }
        public string reasonForLeaving { get { return _reasonForLeaving; } set { _reasonForLeaving = value; } }
        public string is80PercentAttendance { get { return _is80PercentAttendance; } set { _is80PercentAttendance = value; } }
        public string isReceived2Installments { get { return _isReceived2Installments; } set { _isReceived2Installments = value; } }
        public string newDISECode { get { return _newDISECode; } set { _newDISECode = value; } }
        public string isDistrictTransfer { get { return _isDistrictTransfer; } set { _isDistrictTransfer = value; } }
        public string oldSchoolDISECode { get { return _oldSchoolDISECode; } set { _oldSchoolDISECode = value; } }
        public string oldSchoolName { get { return _oldSchoolName; } set { _oldSchoolName = value; } }
        public string oldDistrictName { get { return _oldDistrictName; } set { _oldDistrictName = value; } }
        public string oldBlockName { get { return _oldBlockName; } set { _oldBlockName = value; } }
        public string oldSchoolTypeName { get { return _oldSchoolTypeName; } set { _oldSchoolTypeName = value; } }
        #endregion

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

        public DataTable getSchoolsByDistrictFrontView()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@districtId", DistrictId);
                cmd.Parameters.AddWithValue("@board", Board);
                cmd.Parameters.AddWithValue("@management", SchoolManagement);
                cmd.Parameters.AddWithValue("@status", Status);

                cmd.CommandText = "GetSchoolsByDistrictMasterView";
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

        public DataTable getAllStudent()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DistrictName", district);
                //cmd.Parameters.AddWithValue("@districtId", DistrictId);
                //cmd.Parameters.AddWithValue("@board", Board);
                //cmd.Parameters.AddWithValue("@management", SchoolManagement);
                //cmd.Parameters.AddWithValue("@status", Status);

                cmd.CommandText = "getAllStudent";
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


        public DataTable getAllStudentCompleted()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DistrictName", district);
                //cmd.Parameters.AddWithValue("@districtId", DistrictId);
                //cmd.Parameters.AddWithValue("@board", Board);
                //cmd.Parameters.AddWithValue("@management", SchoolManagement);
                //cmd.Parameters.AddWithValue("@status", Status);

                cmd.CommandText = "getAllStudentCompleted";
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

        public DataTable getAllStudentTransferFrom()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DistrictName", district);
                //cmd.Parameters.AddWithValue("@districtId", DistrictId);
                //cmd.Parameters.AddWithValue("@board", Board);
                //cmd.Parameters.AddWithValue("@management", SchoolManagement);
                //cmd.Parameters.AddWithValue("@status", Status);

                cmd.CommandText = "getAllStudentFromOtherDistrict";
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

        public DataTable getAllStudentTranserferTO()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DistrictName", district);
                //cmd.Parameters.AddWithValue("@districtId", DistrictId);
                //cmd.Parameters.AddWithValue("@board", Board);
                //cmd.Parameters.AddWithValue("@management", SchoolManagement);
                //cmd.Parameters.AddWithValue("@status", Status);

                cmd.CommandText = "getAllStudentToOtherDistrict";
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

        public DataSet getTotalStudentCount()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DistrictName", district);
                cmd.CommandText = "getTotalStudentCount";
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
                cmd.Parameters.AddWithValue("@School_Id", SchoolId);
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

        public DataTable getStudentByAadhar()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AadharUID", AadharUID);
                cmd.CommandText = "getStudentByAadhar";
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

        //To showcase number of students who have left
        public DataTable getTotalLeavedStudents()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DistrictName", district);
                cmd.CommandText = "getTotalLeavedStudents";
                cmd.Connection = CN;
                if (CN.State == ConnectionState.Closed) { CN.Open(); }
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                CN.Close();
            }
            catch (Exception) { }
            return dt;
        }

        public DataTable getSchoolByNewDISE()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@newDISECode", newDISECode);
                cmd.CommandText = "getSchoolByNewDISE";
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

        public DataTable getTotalTransferStudents()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DistrictName", district);
                cmd.CommandText = "getTotalTransferStudents";
                cmd.Connection = CN;
                if (CN.State == ConnectionState.Closed) { CN.Open(); }
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                CN.Close();
            }
            catch (Exception) { }
            return dt;
        }

        public DataTable getTotalCompletedStudents()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DistrictName", district);
                cmd.CommandText = "getTotalCompletedStudents";
                cmd.Connection = CN;
                if (CN.State == ConnectionState.Closed) { CN.Open(); }
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
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
        //New function for Updating data based on Selection of Question 1,2,3
        public DataTable updateOnQuestionSelection()
        {
            try
            {

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AadharUID", AadharUID);
                cmd.Parameters.AddWithValue("@isContinuingSameSchool", isContinuingSameSchool);
                cmd.Parameters.AddWithValue("@isRegSchool2024", isRegSchool2024);
                cmd.Parameters.AddWithValue("@reasonForLeaving", reasonForLeaving);
                cmd.Parameters.AddWithValue("@is80PercentAttendance", is80PercentAttendance);
                cmd.Parameters.AddWithValue("@isReceived2Installments", isReceived2Installments);
                cmd.Parameters.AddWithValue("@DISECode", newDISECode);
                cmd.Parameters.AddWithValue("@schoolName", SchoolName);
                cmd.Parameters.AddWithValue("@districtName", district);
                cmd.Parameters.AddWithValue("@blockName", block);
                cmd.Parameters.AddWithValue("@schoolType", SchoolManagement);
                cmd.Parameters.AddWithValue("@isDistrictTransfer", isDistrictTransfer);
                cmd.Parameters.AddWithValue("@bankStatementPath", BankStatementPath);
                cmd.Parameters.AddWithValue("@consentLetterPath", ConsentPath);
                cmd.Parameters.AddWithValue("@oldSchoolDIESCode", oldSchoolDISECode);
                cmd.Parameters.AddWithValue("@oldSchoolName", oldSchoolName);
                cmd.Parameters.AddWithValue("@oldDistrictName", oldDistrictName);
                cmd.Parameters.AddWithValue("@oldBlockName", oldBlockName);
                cmd.Parameters.AddWithValue("@oldSchoolTypeName", oldSchoolTypeName);

                //if (newdist != Olddist)
                //{
                //    cmd.Parameters.AddWithValue("ischnged", true);
                //}
                cmd.CommandText = "updateOnQuestionSelection";
                cmd.Connection = CN;
                if (CN.State == ConnectionState.Closed) { CN.Open(); }
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                CN.Close();
            }
            catch (Exception) { }
            return dt;
        }

        public DataTable updateDispute()
        {
            try
            {

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AadharUID", AadharUID);
                cmd.CommandText = "updateDispute";
                cmd.Connection = CN;
                if (CN.State == ConnectionState.Closed) { CN.Open(); }
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                CN.Close();
            }
            catch (Exception) { }
            return dt;
        }

    }
}