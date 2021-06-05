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
    class TeacherBLL
    {
        public ObservableCollection<Teacher> TeachersList { get; set; }
        public string ErrorMessage { get; set; }

        TeacherDAL teacherDAL = new TeacherDAL();

        public ObservableCollection<Teacher> GetAllTeachers()
        {
            return teacherDAL.GetAllTeachers();
        }
        public void AddTeacher(Teacher teacher)
        {
            if (String.IsNullOrEmpty(teacher.Name))
            {
                //ErrorMessage = "Numele persoanei trebuie sa fie precizat";
                throw new AgendaException("Numele profesorului trebuie sa fie precizat");
            }
            teacherDAL.AddTeacher(teacher);
            TeachersList.Add(teacher);
        }
        public void ModifyTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new AgendaException("Trebuie selectat un profesor");
            }
            if (String.IsNullOrEmpty(teacher.Name))
            {
                throw new AgendaException("Trebuie precizat numele profesorului");
            }
            teacherDAL.ModifyTeacher(teacher);
        }

        public void DeleteTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
           
            teacherDAL.DeleteTeacher(teacher);
            TeachersList.Remove(teacher);
        }
    }

}

