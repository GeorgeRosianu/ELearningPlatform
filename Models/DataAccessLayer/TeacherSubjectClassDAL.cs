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
    class TeacherSubjectClassDAL
    {
        public ObservableCollection<TeacherSubjectClass> GetAllTeacherSubjectClass()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllTeacherSubjectClass", con);
                ObservableCollection<TeacherSubjectClass> result = new ObservableCollection<TeacherSubjectClass>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TeacherSubjectClass p = new TeacherSubjectClass();
                    p.TeacherID = (int)(reader[1]);
                    p.TeacherName = reader[0].ToString();
                    p.SubjectID = (int)(reader[2]);
                    p.SubjectName = reader[3].ToString();
                    p.ClassID = (int)(reader[4]);
                   

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
        public void AddTeacherSubjectClass(TeacherSubjectClass teacherSubjectClass)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddTeacherSubjectClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramTeacherId = new SqlParameter("@id_teacher", teacherSubjectClass.TeacherID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", teacherSubjectClass.SubjectID);
                SqlParameter paramClassId = new SqlParameter("@id_class", teacherSubjectClass.ClassID);

                cmd.Parameters.Add(paramTeacherId);
                cmd.Parameters.Add(paramSubjectId);
                cmd.Parameters.Add(paramClassId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTeacherSubjectClass(TeacherSubjectClass teacherSubjectClass)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacherSubjectClass", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramTeacherId = new SqlParameter("@id_teacher", teacherSubjectClass.TeacherID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", teacherSubjectClass.SubjectID);
                SqlParameter paramClassId = new SqlParameter("@id_class", teacherSubjectClass.ClassID);

                cmd.Parameters.Add(paramTeacherId);
                cmd.Parameters.Add(paramSubjectId);
                cmd.Parameters.Add(paramClassId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyTeacherSubjectClass(TeacherSubjectClass teacherSubjectClass)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyTeacherSubjectClass", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramTeacherId = new SqlParameter("@id_teacher", teacherSubjectClass.TeacherID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", teacherSubjectClass.SubjectID);
                SqlParameter paramClassId = new SqlParameter("@id_class", teacherSubjectClass.ClassID);

                cmd.Parameters.Add(paramTeacherId);
                cmd.Parameters.Add(paramSubjectId);
                cmd.Parameters.Add(paramClassId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
