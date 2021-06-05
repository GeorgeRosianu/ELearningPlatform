using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels;

namespace EducationPlatform.Models.DataAccessLayer
{
    class StudentSubjectAverageDAL
    {

        public ObservableCollection<StudentSubjectAverage> GetAllStudentSubjectAverage()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentSubjectAverage", con);
                ObservableCollection<StudentSubjectAverage> result = new ObservableCollection<StudentSubjectAverage>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentSubjectAverage p = new StudentSubjectAverage();
                    p.StudentID = (int)(reader[0]);
                    p.SubjectID = (int)(reader[1]);
                    p.SemesterID = (int)(reader[2]);
                    p.Average = (int)(reader[3]);
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

        public ObservableCollection<CorigentStudent> GetAllCorigentStudent()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllCorigentStudent", con);
                ObservableCollection<CorigentStudent> result = new ObservableCollection<CorigentStudent>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CorigentStudent p = new CorigentStudent();
                    p.StudentID = (int)(reader[0]);
                    p.Name = reader[1].ToString();
                    p.Subject = reader[2].ToString();
                    p.Average = (int)(reader[3]);


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
        public ObservableCollection<StudentAbsence> GetAllExmatriculatiStudenti()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllExmatriculatiStudenti", con);
                ObservableCollection<StudentAbsence> result = new ObservableCollection<StudentAbsence>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentAbsence p = new StudentAbsence();
                   
                    p.Name = reader[0].ToString();
                    p.Absences = (int)reader[1];
                    if (p.Absences > 10)
                    {
                        result.Add(p);

                    }

                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Student> GetRepetenti()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetRepetenti", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student();
                    s.StudentID = (int)reader[0];
                    s.Name = reader[1].ToString();
                    

                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<StudentSubjectAverage> GetAllStudentSubjectAverageByClassMasterId()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentSubjectAverageByClassMasterId", con);
                ObservableCollection<StudentSubjectAverage> result = new ObservableCollection<StudentSubjectAverage>();
                cmd.CommandType = CommandType.StoredProcedure;
                int teacherId;
                if (!int.TryParse(DALHelper.id.ToString(), out teacherId))
                {
                    return null;
                }
                SqlParameter paramTeacherId = new SqlParameter("@id_class_master", teacherId);
                cmd.Parameters.Add(paramTeacherId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentSubjectAverage p = new StudentSubjectAverage();
                    p.StudentID = (int)(reader[0]);
                    p.SubjectID = (int)(reader[1]);
                    p.SemesterID = (int)(reader[2]);
                    p.Average = (int)(reader[3]);
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
        public ObservableCollection<StudentSubjectAverage> GetAllStudentSubjectAverageByStudentId(Student s)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentSubjectAverageByStudentId", con);
                ObservableCollection<StudentSubjectAverage> result = new ObservableCollection<StudentSubjectAverage>();
               
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramTeacherId = new SqlParameter("@id_student", s.StudentID);
                cmd.Parameters.Add(paramTeacherId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentSubjectAverage p = new StudentSubjectAverage();
                    p.StudentID = (int)(reader[0]);
                    p.SubjectID = (int)(reader[1]);
                    p.SemesterID = (int)(reader[2]);
                    p.Average = (int)(reader[3]);
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
        public ObservableCollection<StudentSubjectAverage> GetAllStudentSubjectAverageByStudentId()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentSubjectAverageByStudentId2", con);
                ObservableCollection<StudentSubjectAverage> result = new ObservableCollection<StudentSubjectAverage>();
                cmd.CommandType = CommandType.StoredProcedure;
                int teacherId;
                if (!int.TryParse(DALHelper.id.ToString(), out teacherId))
                {
                    return null;
                }
                SqlParameter paramTeacherId = new SqlParameter("@id_student", teacherId);
                cmd.Parameters.Add(paramTeacherId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentSubjectAverage p = new StudentSubjectAverage();
                    p.StudentID = (int)(reader[0]);
                    p.SubjectID = (int)(reader[1]);
                    p.SubjectName = reader[2].ToString();
                    p.SemesterID = (int)(reader[3]);
                    p.Average = (int)(reader[4]);
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
        public ObservableCollection<FinalAverage> GetFinalAverages()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetFinalAverages", con);
                ObservableCollection<FinalAverage> result = new ObservableCollection<FinalAverage>();
                cmd.CommandType = CommandType.StoredProcedure;
                

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FinalAverage p = new FinalAverage();
                    p.StudentID = (int)(reader[0]);
                    p.Name = reader.GetString(1);
                    p.Average = (int)(reader[2]);
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
        public int GetFinalAveragesForOneStudent()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetFinalAverages", con);
                ObservableCollection<FinalAverage> result = new ObservableCollection<FinalAverage>();
                cmd.CommandType = CommandType.StoredProcedure;
                int studentId;
                if (!int.TryParse(DALHelper.id.ToString(), out studentId))
                {
                   // return null;
                }
                int average=0;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    FinalAverage p = new FinalAverage();
                    p.StudentID = (int)(reader[0]);
                    p.Name = reader.GetString(1);
                    p.Average = (int)(reader[2]);
                    if (p.StudentID == studentId)
                    {
                       // result.Add(p);
                        average = p.Average;
                        break;
                        //return average;
                    }
                   
                }
                reader.Close();
                return average;

            }
            finally
            {
                con.Close();
            }
        }
        public void AddStudentSubjectAverage(StudentSubjectAverage studentSubjectAverage)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddStudentSubjectAverage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramClassId = new SqlParameter("@id_student", studentSubjectAverage.StudentID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", studentSubjectAverage.SubjectID);
                SqlParameter paramSemesterId = new SqlParameter("@id_semester", studentSubjectAverage.SemesterID);
                SqlParameter paramAverage = new SqlParameter("@average", studentSubjectAverage.Average);

                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);
                cmd.Parameters.Add(paramSemesterId);

                cmd.Parameters.Add(paramAverage);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }





    }
}
