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
    class SubjectDAL
    {

        public ObservableCollection<Subject> GetAllSubjects()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjects", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Subject s = new Subject();
                    s.SubjectID = (int)(reader[0]);
                    s.Name = reader.GetString(1);

                    result.Add(s);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<Subject> GetAllSubjectsByTeacherId()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjectsByTeacherId", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();
                cmd.CommandType = CommandType.StoredProcedure;
                int subjectId;
                if (!int.TryParse(DALHelper.id.ToString(), out subjectId))
                {
                    return null;
                }
                SqlParameter paramTeacherId = new SqlParameter("@id_teacher", subjectId);
                cmd.Parameters.Add(paramTeacherId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Subject s = new Subject();
                    s.SubjectID = (int)reader[0];
                    s.Name = reader.GetString(1);

                    result.Add(s);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        
        public void AddSubject(Subject subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id_subject", subject.SubjectID);
                SqlParameter paramNume = new SqlParameter("@subject_name", subject.Name);
                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramNume);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSubject(Subject subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@subjectID", subject.SubjectID);
                cmd.Parameters.Add(paramIdSubject);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifySubject(Subject subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifySubject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdSubject = new SqlParameter("@subjectID",subject.SubjectID);
                SqlParameter paramNume = new SqlParameter("@name", subject.Name);

                cmd.Parameters.Add(paramIdSubject);
                cmd.Parameters.Add(paramNume);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

