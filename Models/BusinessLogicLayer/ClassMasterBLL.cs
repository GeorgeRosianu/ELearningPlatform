using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPlatform.Exceptions;
using EducationPlatform.Models.DataAccessLayer;
using EducationPlatform.Models.EntityLayer;

namespace EducationPlatform.Models.BusinessLogicLayer
{
    class ClassMasterBLL
    {
        public ObservableCollection<ClassMaster> ClassMastersList { get; set; }
        public string ErrorMessage { get; set; }

        ClassMasterDAL classMasterDAL = new ClassMasterDAL();

        public ObservableCollection<ClassMaster> GetAllClassMasters()
        {
            return classMasterDAL.GetAllClassMasters();
        }
        public void AddClassMaster(ClassMaster classMaster)
        {
           
            classMasterDAL.AddClassMaster(classMaster);
            ClassMastersList.Add(classMaster);
        }
        public void ModifyClassMaster(ClassMaster classMaster)
        {
            if (classMaster == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
           
            classMasterDAL.ModifyClassMaster(classMaster);
        }

        public void DeleteClassMaster(ClassMaster classMaster)
        {
            if (classMaster == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
          
            classMasterDAL.DeleteClassMaster(classMaster);
            ClassMastersList.Remove(classMaster);
        }
    }
}
