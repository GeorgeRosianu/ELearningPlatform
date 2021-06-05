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
    class StudentSubjectBLL
    {
        public ObservableCollection<StudentSubject> StudentSubjectsList { get; set; }
        public string ErrorMessage { get; set; }

       StudentSubjectDAL studentSubjectDAL = new StudentSubjectDAL();

        public ObservableCollection<StudentSubject> GetAllStudentSubjects()
        {
            return studentSubjectDAL.GetAllStudentSubjects();
        }
        public void AddClassSubject(StudentSubject studentSubject)
        {

            studentSubjectDAL.AddStudentSubject(studentSubject);
            StudentSubjectsList.Add(studentSubject);
        }
        public void ModifyClassSubject(StudentSubject studentSubject)
        {
            if (studentSubject == null)
            {
                throw new AgendaException("Trebuie selectata o persoana");
            }

            studentSubjectDAL.ModifyStudentSubject(studentSubject);
        }

        public void DeleteClassSubject(StudentSubject studentSubject)
        {
            if (studentSubject == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
           
            studentSubjectDAL.DeleteStudentSubject(studentSubject);
            StudentSubjectsList.Remove(studentSubject);
        }
    }
}
