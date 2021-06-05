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
    class ClassSubjectDAL
    {
        public ObservableCollection<ClassSubject> GetAllClassSubjects()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClassSubjects", con);
                ObservableCollection<ClassSubject> result = new ObservableCollection<ClassSubject>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClassSubject p = new ClassSubject();
                    p.ClassID = (int)(reader[0]);//reader.GetInt(0);
                    p.SubjectID = (int)(reader[1]);//reader[1].ToString();
                    p.SubjectName = reader[2].ToString();

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
        public void AddClassSubject(ClassSubject classSubject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddClassSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramClassId = new SqlParameter("@id_class", classSubject.ClassID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", classSubject.SubjectID);

                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteClassSubject(ClassSubject classSubject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClassSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@classID", classSubject.ClassID);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyClassSubject(ClassSubject classSubject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyClassSubject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdClass = new SqlParameter("@classID", classSubject.ClassID);
                SqlParameter paramIdSubject = new SqlParameter("@id_subject", classSubject.SubjectID);

                cmd.Parameters.Add(paramIdClass);
                cmd.Parameters.Add(paramIdSubject);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

