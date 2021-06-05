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
    class ThesisDAL
    {
        public ObservableCollection<Thesis> GetAllThesis()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllThesis", con);
                ObservableCollection<Thesis> result = new ObservableCollection<Thesis>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Thesis t = new Thesis();
                    t.SubjectID = (int)reader[1];
                    t.ClassID = (int)reader[0];
                    t.SubjectName = reader[2].ToString();

                    
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
       
        public void AddThesis(Thesis thesis)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddThesis", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramClassId = new SqlParameter("@id_class", thesis.ClassID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", thesis.SubjectID);
                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteThesis(Thesis thesis)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteThesis", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramClassId = new SqlParameter("@id_class", thesis.ClassID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", thesis.SubjectID);
                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyThesis(Thesis thesis)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyThesis", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramClassId = new SqlParameter("@id_class", thesis.ClassID);
                SqlParameter paramSubjectId = new SqlParameter("@id_subject", thesis.SubjectID);
                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramSubjectId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
