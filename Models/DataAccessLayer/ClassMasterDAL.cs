using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPlatform.Models.EntityLayer;

namespace EducationPlatform.Models.DataAccessLayer
{
    class ClassMasterDAL
    {
        public ObservableCollection<ClassMaster> GetAllClassMasters()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClassMasters", con);
                ObservableCollection<ClassMaster> result = new ObservableCollection<ClassMaster>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClassMaster p = new ClassMaster();
                    p.ClassMasterID = (int)(reader[0]);//reader.GetInt(0);
                    p.TeacherID= (int)(reader[1]);//reader[1].ToString();
                    p.TeacherName = reader[2].ToString();
                  
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public void AddClassMaster(ClassMaster classMaster)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddClassMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramClassMasterId = new SqlParameter("@id_classmaster", classMaster.ClassMasterID);
                SqlParameter paramTeacherId = new SqlParameter("@id_teacher",classMaster.TeacherID);
               
                cmd.Parameters.Add(paramClassMasterId);
                cmd.Parameters.Add(paramTeacherId);
               
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteClassMaster(ClassMaster classMaster)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClassMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@classMasterID", classMaster.ClassMasterID);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyClassMaster(ClassMaster classMaster)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyClassMaster", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdClassMaster = new SqlParameter("@classMasterID", classMaster.ClassMasterID);
                SqlParameter paramIdTeacher = new SqlParameter("@id_teacher", classMaster.TeacherID);
               
                cmd.Parameters.Add(paramIdClassMaster);
                cmd.Parameters.Add(paramIdTeacher);
               
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
