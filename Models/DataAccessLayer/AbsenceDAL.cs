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
    class AbsenceDAL
    {
        public ObservableCollection<Absence> GetAllAbsences()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllAbsencesByTeacherId", con);
                ObservableCollection<Absence> result = new ObservableCollection<Absence>();
                int teacherId;
                if (!int.TryParse(DALHelper.id.ToString(), out teacherId))
                {
                    return null;
                }
                SqlParameter paramTeacherId = new SqlParameter("@id_teacher", teacherId);
                cmd.Parameters.Add(paramTeacherId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Absence t = new Absence();
                    t.SubjectID = (int)(reader[0]);
                    t.StudentID = (int)(reader[1]);
                    t.SemesterID = (int)(reader[2]);
                    t.TeacherID = (int)(reader[3]);
                    t.Date = reader.GetString(4);
                    t.State = reader.GetString(5);
              
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
        public ObservableCollection<Absence> GetAllAbsencesByClassMasterId()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllAbsencesByClassMasterId", con);
                ObservableCollection<Absence> result = new ObservableCollection<Absence>();
                int classMasterId;
                if (!int.TryParse(DALHelper.id.ToString(), out classMasterId))
                {
                    return null;
                }
                SqlParameter paramClassMasterId = new SqlParameter("@id_class_master", classMasterId);
                cmd.Parameters.Add(paramClassMasterId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Absence t = new Absence();
                    t.SubjectID = (int)(reader[0]);
                    t.StudentID = (int)(reader[1]);
                    t.SemesterID = (int)(reader[2]);
                    t.TeacherID = (int)(reader[3]);
                    t.Date = reader.GetString(4);
                    t.State = reader.GetString(5);

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
        public ObservableCollection<Absence> GetAllAbsencesByStudentId(Student ss)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllAbsencesByStudentId", con);
                ObservableCollection<Absence> result = new ObservableCollection<Absence>();
               
                SqlParameter paramStudentId = new SqlParameter("@id_student", ss.StudentID);
                cmd.Parameters.Add(paramStudentId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Absence t = new Absence();
                    t.SubjectID = (int)(reader[0]);
                    t.StudentID = (int)(reader[1]);
                    t.SemesterID = (int)(reader[2]);
                    t.TeacherID = (int)(reader[3]);
                    t.Date = reader.GetString(4);
                    t.State = reader.GetString(5);

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
        public ObservableCollection<Absence> GetAllAbsencesByStudentId()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllAbsencesByStudentId2", con);
                ObservableCollection<Absence> result = new ObservableCollection<Absence>();
                int studentId;
                if (!int.TryParse(DALHelper.id.ToString(), out studentId))
                {
                    return null;
                }
                SqlParameter paramStudentId = new SqlParameter("@id_student", studentId);
                cmd.Parameters.Add(paramStudentId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Absence t = new Absence();
                    t.SubjectID = (int)(reader[0]);
                    t.StudentID = (int)(reader[1]);
                    t.SemesterID = (int)(reader[2]);
                    t.TeacherID = (int)(reader[3]);
                    t.Date = reader.GetString(4);
                    t.State = reader.GetString(5);

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
        public ObservableCollection<Absence> GetAllNemotivatedAbsencesByClassMasterId()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllNemotivatedAbsencesByClassMasterId", con);
                ObservableCollection<Absence> result = new ObservableCollection<Absence>();
                int classMasterId;
                if (!int.TryParse(DALHelper.id.ToString(), out classMasterId))
                {
                    return null;
                }
                SqlParameter paramClassMasterId = new SqlParameter("@id_class_master", classMasterId);
                cmd.Parameters.Add(paramClassMasterId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Absence t = new Absence();
                    t.SubjectID = (int)(reader[0]);
                    t.StudentID = (int)(reader[1]);
                    t.SemesterID = (int)(reader[2]);
                    t.TeacherID = (int)(reader[3]);
                    t.Date = reader.GetString(4);
                    t.State = reader.GetString(5);

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
        public int GetAbsences()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAbsences", con);
                int result=0;
                int classMasterId;
                if (!int.TryParse(DALHelper.id.ToString(), out classMasterId))
                {
                    return 0;
                }
                SqlParameter paramClassMasterId = new SqlParameter("@id_class_master", classMasterId);
                cmd.Parameters.Add(paramClassMasterId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   
                   result = (int)(reader[0]);
                    
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public int GetNemotivatedAbsences()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetNemotivatedAbsences", con);
                int result = 0;
                int classMasterId;
                if (!int.TryParse(DALHelper.id.ToString(), out classMasterId))
                {
                    return 0;
                }
                SqlParameter paramClassMasterId = new SqlParameter("@id_class_master", classMasterId);
                cmd.Parameters.Add(paramClassMasterId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    result = (int)(reader[0]);

                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public int GetNumberOfAbsences()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetNumberOfAbsences", con);
                int result = 0;
                int classMasterId;
                if (!int.TryParse(DALHelper.id.ToString(), out classMasterId))
                {
                    return 0;
                }
                SqlParameter paramTeacherId = new SqlParameter("@id_class_master", classMasterId);
                cmd.Parameters.Add(paramTeacherId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    result = (int)(reader[0]);

                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public void AddAbsence(Absence absence)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddAbsence", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@id_subject", absence.SubjectID);
                SqlParameter paramIdStudent = new SqlParameter("@id_student", absence.StudentID);
                SqlParameter paramIdSemester = new SqlParameter("@id_semester", absence.SemesterID);
                SqlParameter paramIdTeacher = new SqlParameter("@id_teacher", absence.TeacherID);
                SqlParameter paramDate = new SqlParameter("@date", absence.Date);
                SqlParameter paramState = new SqlParameter("@state", absence.State);

                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramIdSemester);
                cmd.Parameters.Add(paramIdTeacher);
                cmd.Parameters.Add(paramDate);
                cmd.Parameters.Add(paramState);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAbsence(Absence absence)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteAbsence", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@id_subject", absence.SubjectID);
                SqlParameter paramIdStudent = new SqlParameter("@id_student", absence.StudentID);
                SqlParameter paramIdSemester = new SqlParameter("@id_semester", absence.SemesterID);
                SqlParameter paramIdTeacher = new SqlParameter("@id_teacher", absence.TeacherID);
                SqlParameter paramDate = new SqlParameter("@date", absence.Date);
                SqlParameter paramState = new SqlParameter("@state", absence.State);
                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramIdSemester);
                cmd.Parameters.Add(paramIdTeacher);
                cmd.Parameters.Add(paramDate);
                cmd.Parameters.Add(paramState);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyAbsence(Absence absence)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyAbsence", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@id_subject", absence.SubjectID);
                SqlParameter paramIdStudent = new SqlParameter("@id_student", absence.StudentID);
                SqlParameter paramIdSemester = new SqlParameter("@id_semester", absence.SemesterID);
                SqlParameter paramIdTeacher = new SqlParameter("@id_teacher", absence.TeacherID);
                SqlParameter paramDate = new SqlParameter("@date", absence.Date);
                SqlParameter paramState = new SqlParameter("@state", absence.State);

                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramIdSemester);
                cmd.Parameters.Add(paramIdTeacher);
                cmd.Parameters.Add(paramDate);
                cmd.Parameters.Add(paramState);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
