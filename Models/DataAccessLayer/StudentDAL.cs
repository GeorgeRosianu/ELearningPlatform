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
    class StudentDAL
    {
        public ObservableCollection<Student> GetAllStudents()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudents", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student p = new Student();
                    p.StudentID = (int)(reader[0]);//reader.GetInt(0);
                    p.Name = reader.GetString(1);//reader[1].ToString();
                    p.BirthDate = reader.IsDBNull(2) ? null : reader[2].ToString();
                 
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
        public ObservableCollection<Student> GetAllStudentsByTeacherId()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentsByTeacherId", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                int teacherId;
                if (!int.TryParse(DALHelper.id.ToString(), out teacherId))
                {
                    return null;
                }
                SqlParameter paramId = new SqlParameter("@id_teacher", teacherId);
                cmd.Parameters.Add(paramId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student p = new Student();
                    p.StudentID = (int)(reader[0]);//reader.GetInt(0);
                    p.Name = reader.GetString(1);//reader[1].ToString();
                    p.BirthDate = reader.IsDBNull(2) ? null : reader[2].ToString();

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
        public ObservableCollection<Student> GetAllStudentsByClassMasterId()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentsByClassMasterId", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                int teacherId;
                if (!int.TryParse(DALHelper.id.ToString(), out teacherId))
                {
                    return null;
                }
                SqlParameter paramId = new SqlParameter("@id_teacher", teacherId);
                cmd.Parameters.Add(paramId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student p = new Student();
                    p.StudentID = (int)(reader[0]);//reader.GetInt(0);
                    p.Name = reader.GetString(1);//reader[1].ToString();
                    p.BirthDate = reader.IsDBNull(2) ? null : reader[2].ToString();

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
        public void AddStudent(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id_student", student.StudentID);
                SqlParameter paramNume = new SqlParameter("@student_name", student.Name);
                SqlParameter paramBirthDate;
                if (String.IsNullOrEmpty(student.BirthDate))
                {
                    paramBirthDate = new SqlParameter("@birth_date", DBNull.Value);
                }
                else
                {
                    paramBirthDate = new SqlParameter("@birth_date", student.BirthDate);
                }
              
                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramBirthDate);
             
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@studentID", student.StudentID);
                cmd.Parameters.Add(paramIdStudent);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyStudent(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdStudent = new SqlParameter("@studentID",student.StudentID);
                SqlParameter paramNume = new SqlParameter("@name", student.Name);
                SqlParameter paramBirthDate = new SqlParameter();
                paramBirthDate.ParameterName = "@birthdate";
             

                if (String.IsNullOrEmpty(student.BirthDate))
                {
                    paramBirthDate.Value = DBNull.Value;
                }
                else
                {
                    paramBirthDate.Value = student.BirthDate;
                }
                cmd.Parameters.Add(paramIdStudent);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramBirthDate);
             
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
