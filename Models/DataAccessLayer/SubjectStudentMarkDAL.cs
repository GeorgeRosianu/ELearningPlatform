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
    class SubjectStudentMarkDAL
    {
        public ObservableCollection<SubjectStudentMark> GetAllSSM()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSSMByTeacherId", con);
                ObservableCollection<SubjectStudentMark> result = new ObservableCollection<SubjectStudentMark>();
                int teacherId;
                if (!int.TryParse(DALHelper.id.ToString(), out teacherId))
                {
                    return null;
                }
                //Id-ul materiei este printre cele predate de profesorul cu id-ul respectiv
                SqlParameter paramTeacherId = new SqlParameter("@id_teacher", teacherId);
                cmd.Parameters.Add(paramTeacherId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SubjectStudentMark t = new SubjectStudentMark();
                    t.SubjectID = (int)(reader[0]);
                    t.StudentID = (int)(reader[1]);
                    t.SemesterID = (int)(reader[2]);
                    t.Mark = (int)(reader[3]);
                    t.Date = reader.GetString(4);
                    t.IsThesis = (int)(reader[5]);


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
        public ObservableCollection<SubjectStudentMark> GetAllSSMByStudentId()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSSMByStudentId", con);
                ObservableCollection<SubjectStudentMark> result = new ObservableCollection<SubjectStudentMark>();
                int studentId;
                if (!int.TryParse(DALHelper.id.ToString(), out studentId))
                {
                    return null;
                }
                //Id-ul materiei este printre cele predate de profesorul cu id-ul respectiv
                SqlParameter paramStudentId = new SqlParameter("@id_student", studentId);
                cmd.Parameters.Add(paramStudentId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SubjectStudentMark t = new SubjectStudentMark();
                    t.SubjectID = (int)(reader[0]);
                    t.StudentID = (int)(reader[1]);
                    t.SemesterID = (int)(reader[2]);
                    t.Mark = (int)(reader[3]);
                    t.Date = reader.GetString(4);
                    t.IsThesis = (int)(reader[5]);


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

        public int GetAverage(StudentSubject studentSubject)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAverage", con);
                int average = 0;

                //Id-ul materiei este printre cele predate de profesorul cu id-ul respectiv
                SqlParameter paramClassId = new SqlParameter("@id_student", studentSubject.StudentID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", studentSubject.SubjectID);



                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    average = (int)reader[0];
                }
                reader.Close();
                return average;
            }
            finally
            {
                con.Close();
            }

        }
        public int GetMarkCount(StudentSubject studentSubject)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetMarkCount", con);
                int count = 0;

                SqlParameter paramClassId = new SqlParameter("@id_student", studentSubject.StudentID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", studentSubject.SubjectID);



                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count = (int)reader[0];
                }
                reader.Close();
                return count;
            }
            finally
            {
                con.Close();
            }

        }
        public int VerifyIfClassHasThesis(StudentSubject studentSubject)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("VerifyIfClassHasThesis", con);
                int id = 0;

                //Id-ul materiei este printre cele predate de profesorul cu id-ul respectiv
                SqlParameter paramClassId = new SqlParameter("@id_student", studentSubject.StudentID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", studentSubject.SubjectID);



                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = (int)reader[0];
                }
                reader.Close();
                return id;
            }
            finally
            {
                con.Close();
            }

        }
        public int GetThesisMark(StudentSubject studentSubject)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetThesisMark", con);
                int id = 0;

                //Id-ul materiei este printre cele predate de profesorul cu id-ul respectiv
                SqlParameter paramClassId = new SqlParameter("@id_student", studentSubject.StudentID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", studentSubject.SubjectID);



                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = (int)reader[0];
                }
                reader.Close();
                return id;
            }
            finally
            {
                con.Close();
            }

        }
        public int GetMarkSum(StudentSubject studentSubject)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetMarkSum", con);
                int sum = 0;

                //Id-ul materiei este printre cele predate de profesorul cu id-ul respectiv
                SqlParameter paramClassId = new SqlParameter("@id_student", studentSubject.StudentID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", studentSubject.SubjectID);



                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sum = (int)reader[0];
                }
                reader.Close();
                return sum;
            }
            finally
            {
                con.Close();
            }

        }
        public int GetMarkAverage(StudentSubject studentSubject)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetMarkAverage", con);
                int sum = 0;

                //Id-ul materiei este printre cele predate de profesorul cu id-ul respectiv
                SqlParameter paramClassId = new SqlParameter("@id_student", studentSubject.StudentID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", studentSubject.SubjectID);



                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sum = (int)reader[0];
                }
                reader.Close();
                return sum;
            }
            finally
            {
                con.Close();
            }

        }
        public ObservableCollection<SubjectStudentMark> GetAllSSMByStudentIdAndSubjectId(StudentSubject studentSubject)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSSMByStudentIdAndSubjectId", con);
                ObservableCollection<SubjectStudentMark> result = new ObservableCollection<SubjectStudentMark>();
                int teacherId;
                if (!int.TryParse(DALHelper.id.ToString(), out teacherId))
                {
                    return null;
                }
                //Id-ul materiei este printre cele predate de profesorul cu id-ul respectiv
                SqlParameter paramClassId = new SqlParameter("@id_student", studentSubject.StudentID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", studentSubject.SubjectID);
                SqlParameter paramTeacherId = new SqlParameter("@id_teacher", teacherId);


                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);
                cmd.Parameters.Add(paramTeacherId);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SubjectStudentMark t = new SubjectStudentMark();
                    t.SubjectID = (int)(reader[0]);
                    t.StudentID = (int)(reader[1]);
                    t.SemesterID = (int)(reader[2]);
                    t.Mark = (int)(reader[3]);
                    t.Date = reader.GetString(4);
                    t.IsThesis = (int)(reader[5]);


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
        public void AddSSM(SubjectStudentMark subjectStudentMark)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddSMM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@id_subject", subjectStudentMark.SubjectID);
                SqlParameter paramIdStudent = new SqlParameter("@id_student", subjectStudentMark.StudentID);
                SqlParameter paramIdSemester = new SqlParameter("@id_semester", subjectStudentMark.SemesterID);

                SqlParameter paramDate = new SqlParameter("@date", subjectStudentMark.Date);
                SqlParameter paramMark = new SqlParameter("@mark", subjectStudentMark.Mark);
                SqlParameter paramIsThesis = new SqlParameter("@is_thesis", subjectStudentMark.IsThesis);


                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramIdSemester);
                cmd.Parameters.Add(paramDate);
                cmd.Parameters.Add(paramMark);
                cmd.Parameters.Add(paramIsThesis);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSSM(SubjectStudentMark subjectStudentMark)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSSM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@id_subject", subjectStudentMark.SubjectID);
                SqlParameter paramIdStudent = new SqlParameter("@id_student", subjectStudentMark.StudentID);
                SqlParameter paramIdSemester = new SqlParameter("@id_semester", subjectStudentMark.SemesterID);

                SqlParameter paramDate = new SqlParameter("@date", subjectStudentMark.Date);
                SqlParameter paramMark = new SqlParameter("@mark", subjectStudentMark.Mark);

                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramIdSemester);
                cmd.Parameters.Add(paramDate);
                cmd.Parameters.Add(paramMark);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /*public void ModifySSM(SubjectStudentMark subjectStudentMark)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifySSM", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@id_subject", subjectStudentMark.SubjectID);
                SqlParameter paramIdStudent = new SqlParameter("@id_student", subjectStudentMark.StudentID);
                SqlParameter paramIdSemester = new SqlParameter("@id_semester", subjectStudentMark.SemesterID);

                SqlParameter paramDate = new SqlParameter("@date", subjectStudentMark.Date);
                SqlParameter paramMark = new SqlParameter("@mark", subjectStudentMark.Mark);

                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramIdSemester);
                cmd.Parameters.Add(paramDate);
                cmd.Parameters.Add(paramMark);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }*/
    }
}
