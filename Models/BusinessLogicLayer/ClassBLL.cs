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
    class ClassBLL
    {
        public ObservableCollection<Class> ClassesList { get; set; }
        public string ErrorMessage { get; set; }

        ClassDAL classDAL = new ClassDAL();

        public ObservableCollection<Class> GetAllClasses()
        {
            return classDAL.GetAllClasses();
        }
        public ObservableCollection<Class> GetAllClassesByTeacherId()
        {
            return classDAL.GetAllClassesByTeacherId();
        }
        public void AddClass(Class currentClass)

        {

            classDAL.AddClass(currentClass);
            ClassesList.Add(currentClass);
        }
        public void ModifyClass(Class currentClass)
        {
            if (currentClass == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }

            classDAL.ModifyClass(currentClass);
        }
    

        public void DeleteClass(Class currentClass)
        {
            if (currentClass == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
           
            classDAL.DeleteClass(currentClass);
            ClassesList.Remove(currentClass);
        }
    
   } 
}
