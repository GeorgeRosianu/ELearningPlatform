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
    class MaterialDAL
    {
        public ObservableCollection<Material> GetAllMaterialsByTeacherId()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllMaterialsByTeacherId", con);
                ObservableCollection<Material> result = new ObservableCollection<Material>();
                cmd.CommandType = CommandType.StoredProcedure;
                int teacherId;
                if (!int.TryParse(DALHelper.id.ToString(), out teacherId))
                {
                    return null;
                }
                SqlParameter paramTeacherId = new SqlParameter("@id_teacher", teacherId);
                cmd.Parameters.Add(paramTeacherId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Material t = new Material();
                    t.TeacherID = (int)(reader[0]);//reader.GetInt(0);
                    t.Path = reader.GetString(1);//reader[1].ToString();

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
        public ObservableCollection<Material> GetAllMaterials()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllMaterials", con);
                ObservableCollection<Material> result = new ObservableCollection<Material>();
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
                    Material t = new Material();
                    t.TeacherID = (int)(reader[0]);//reader.GetInt(0);
                    t.Path = reader.GetString(1);//reader[1].ToString();

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
        public void AddMaterial(Material material)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddMaterial", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id_teacher", material.TeacherID);
                SqlParameter paramPath = new SqlParameter("@path", material.Path);
                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramPath);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
