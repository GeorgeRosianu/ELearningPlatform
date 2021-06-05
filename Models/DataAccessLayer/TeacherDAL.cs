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
    class TeacherDAL
    {
        public ObservableCollection<Teacher> GetAllTeachers()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllTeachers", con);
                ObservableCollection<Teacher> result = new ObservableCollection<Teacher>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher t = new Teacher();
                    t.TeacherID = (int)(reader[0]);//reader.GetInt(0);
                    t.Name = reader.GetString(1);//reader[1].ToString();
                   
                    result.Add(t);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public void AddTeacher(Teacher teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id_teacher", teacher.TeacherID);
                SqlParameter paramNume = new SqlParameter("@teacher_name", teacher.Name);
                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramNume);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTeacher(Teacher teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdTeacher = new SqlParameter("@teacherID", teacher.TeacherID);
                cmd.Parameters.Add(paramIdTeacher);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyTeacher(Teacher teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyTeacher", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdTeacher = new SqlParameter("@teacherID", teacher.TeacherID);
                SqlParameter paramNume = new SqlParameter("@name", teacher.Name);
               
                cmd.Parameters.Add(paramIdTeacher);
                cmd.Parameters.Add(paramNume);
           
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

