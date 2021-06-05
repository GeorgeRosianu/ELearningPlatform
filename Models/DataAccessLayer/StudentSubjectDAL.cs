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
    class StudentSubjectDAL
    {
        public ObservableCollection<StudentSubject> GetAllStudentSubjects()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentSubjects", con);
                ObservableCollection<StudentSubject> result = new ObservableCollection<StudentSubject>();
                cmd.CommandType = CommandType.StoredProcedure;
                int teacherId;
                if (!int.TryParse(DALHelper.id.ToString(), out teacherId))
                {
                    return null;
                }
                //Id-ul materiei este printre cele predate de profesorul cu id-ul respectiv
                SqlParameter paramTeacherId = new SqlParameter("@id_teacher", teacherId);
                cmd.Parameters.Add(paramTeacherId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentSubject p = new StudentSubject();
                    p.StudentID = (int)(reader[0]);//reader.GetInt(0);
                    p.SubjectID = (int)(reader[1]);//reader[1].ToString();

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
        public void AddStudentSubject(StudentSubject studentSubject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddStudentSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramClassId = new SqlParameter("@id_student", studentSubject.StudentID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", studentSubject.SubjectID);

                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudentSubject(StudentSubject studentSubject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudentSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramClassId = new SqlParameter("@id_student", studentSubject.StudentID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", studentSubject.SubjectID);

                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyStudentSubject(StudentSubject studentSubject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyStudentSubject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramClassId = new SqlParameter("@id_student", studentSubject.StudentID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", studentSubject.SubjectID);

                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
