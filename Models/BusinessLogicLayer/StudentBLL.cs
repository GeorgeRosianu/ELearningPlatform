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
    class StudentBLL
    {
        public ObservableCollection<Student> StudentsList { get; set; }
        public string ErrorMessage { get; set; }

        StudentDAL studentDAL = new StudentDAL();

        public ObservableCollection<Student> GetAllStudents()
        {
            return studentDAL.GetAllStudents();
        }
        public ObservableCollection<Student> GetAllStudentsByTeacherId()
        {
            return studentDAL.GetAllStudentsByTeacherId();
        }
        public ObservableCollection<Student> GetAllStudentsByClassMasterId()
        {
            return studentDAL.GetAllStudentsByClassMasterId();
        }
        public void AddStudent(Student student)
        {
            if (String.IsNullOrEmpty(student.Name))
            {
                throw new AgendaException("Numele studentului trebuie sa fie precizat");
            }
            studentDAL.AddStudent(student);
            StudentsList.Add(student);
        }
        public void ModifyStudent(Student student)
        {
            if (student == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
            if (String.IsNullOrEmpty(student.Name))
            {
                throw new AgendaException("Trebuie precizat numele studentului");
            }
            studentDAL.ModifyStudent(student);
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
          
           studentDAL.DeleteStudent(student);
            StudentsList.Remove(student);
        }
    }

}

