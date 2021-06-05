using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPlatform.Models.DataAccessLayer;
using EducationPlatform.Models.EntityLayer;

namespace EducationPlatform.Models.BusinessLogicLayer
{
    class MaterialBLL
    {
        public ObservableCollection<Material> MaterialsList { get; set; }
        public string ErrorMessage { get; set; }

        MaterialDAL materialDAL = new MaterialDAL();

        public ObservableCollection<Material> GetAllMaterialsByTeacherId()
        {
            return materialDAL.GetAllMaterialsByTeacherId();
        }
        public ObservableCollection<Material> GetAllMaterials()
        {
            return materialDAL.GetAllMaterials();
        }
        public void AddMaterial(Material material)
        {

            materialDAL.AddMaterial(material);
            MaterialsList.Add(material);
        }
       
    }
}

