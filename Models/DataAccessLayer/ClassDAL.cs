using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using EducationPlatform.Models.EntityLayer;

namespace EducationPlatform.Models.DataAccessLayer
{
    class ClassDAL
    {
        public ObservableCollection<Class> GetAllClasses()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClasses", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Class p = new Class();
                    p.ClassID = (int)(reader[0]);
                    p.ClassMasterID = (int)(reader[1]);
                    p.Specialization = reader[2].ToString();
                    p.StudyYear = (int)reader[3];
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
        public ObservableCollection<Class> GetAllClassesByTeacherId()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClassesByTeacherId", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();
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
                    Class p = new Class();
                    p.ClassID = (int)(reader[0]);
                    p.ClassMasterID = (int)(reader[1]);
                    p.Specialization = reader[2].ToString();
                    p.StudyYear = (int)reader[3];
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
        public void AddClass(Class currentClass)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramclassId = new SqlParameter("@id_class", currentClass.ClassID);
                SqlParameter paramClassMasterId = new SqlParameter("@id_class_master", currentClass.ClassMasterID);
                SqlParameter paramSpecialization= new SqlParameter("@specialization", currentClass.Specialization);
                SqlParameter paramStudyYear = new SqlParameter("@study_year", currentClass.StudyYear);

                cmd.Parameters.Add(paramclassId);
                cmd.Parameters.Add(paramClassMasterId);
                cmd.Parameters.Add(paramSpecialization);
                cmd.Parameters.Add(paramStudyYear);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteClass(Class currentClass)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdClass = new SqlParameter("@id_class", currentClass.ClassID);
                cmd.Parameters.Add(paramIdClass);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyClass(Class currentClass)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyClass", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramClassId = new SqlParameter("@id_class", currentClass.ClassID);
                SqlParameter paramClassMasterId = new SqlParameter("@id_class_master", currentClass.ClassMasterID);
                SqlParameter paramSpecialization = new SqlParameter("@specialization", currentClass.Specialization);
                SqlParameter paramStudyYear = new SqlParameter("@study_year", currentClass.StudyYear);


                cmd.Parameters.Add(paramClassId);
                cmd.Parameters.Add(paramClassMasterId);
                cmd.Parameters.Add(paramSpecialization);
                cmd.Parameters.Add(paramStudyYear);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
