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
    class StudentClassDAL
    {
        public ObservableCollection<StudentClass> GetAllStudentClass()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentClass", con);
                ObservableCollection<StudentClass> result = new ObservableCollection<StudentClass>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentClass p = new StudentClass();
                    p.ClassID = (int)(reader[0]);//reader.GetInt(0);
                    p.StudentID = (int)(reader[1]);//reader[1].ToString();
                    p.StudentName = reader[2].ToString();
                   
                  

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
        public void AddStudentClass(StudentClass studentClass)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddStudentClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramClassId = new SqlParameter("@id_class", studentClass.ClassID);
                SqlParameter paramSubjectId = new SqlParameter("@id_student", studentClass.StudentID);

                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudentClass(StudentClass studentClass)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudentClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id_student", studentClass.StudentID);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyStudentClass(StudentClass studentClass)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyClassSubject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramClassId = new SqlParameter("@id_class", studentClass.ClassID);
                SqlParameter paramStudentId = new SqlParameter("@id_student", studentClass.StudentID);

                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramStudentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
