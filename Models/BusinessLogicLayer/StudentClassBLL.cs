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
    class StudentClassBLL
    {
        public ObservableCollection<StudentClass> StudentClassList { get; set; }
        public string ErrorMessage { get; set; }

        StudentClassDAL studentClassDAL = new StudentClassDAL();

        public ObservableCollection<StudentClass> GetAllStudentClass()
        {
            return studentClassDAL.GetAllStudentClass();
        }
        public void AddClassSubject(StudentClass studentClass)
        {

            studentClassDAL.AddStudentClass(studentClass);
            StudentClassList.Add(studentClass);
        }
        public void ModifyStudentClass(StudentClass studentClass)
        {
            if (studentClass == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }

            studentClassDAL.ModifyStudentClass(studentClass);
        }

        public void DeleteStudentClass(StudentClass studentClass)
        {
            if (studentClass == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
          
            studentClassDAL.DeleteStudentClass(studentClass);
            StudentClassList.Remove(studentClass);
        }
    }
}
