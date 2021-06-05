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
    class TeacherSubjectClassBLL
    {
        public ObservableCollection<TeacherSubjectClass> TeacherSubjectClassList { get; set; }
        public string ErrorMessage { get; set; }

        TeacherSubjectClassDAL teacherSubjectClassDAL = new TeacherSubjectClassDAL();

        public ObservableCollection<TeacherSubjectClass> GetAllTeacherSubjectClass()
        {
            return teacherSubjectClassDAL.GetAllTeacherSubjectClass();
        }
        public void AddTeacherSubjectClass(TeacherSubjectClass teacherSubjectClass)
        {

            teacherSubjectClassDAL.AddTeacherSubjectClass(teacherSubjectClass);
            TeacherSubjectClassList.Add(teacherSubjectClass);
        }
        public void ModifyTeacherSubjectClass(TeacherSubjectClass teacherSubjectClass)
        {
            if (teacherSubjectClass == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }

            teacherSubjectClassDAL.ModifyTeacherSubjectClass(teacherSubjectClass);
        }

        public void DeleteTeacherSubjectClass(TeacherSubjectClass teacherSubjectClass)
        {
            if (teacherSubjectClass == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
         
            teacherSubjectClassDAL.DeleteTeacherSubjectClass(teacherSubjectClass);
            TeacherSubjectClassList.Remove(teacherSubjectClass);
        }
    }
}
