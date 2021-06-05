using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPlatform.Exceptions;
using EducationPlatform.Models.DataAccessLayer;
using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels;

namespace EducationPlatform.Models.BusinessLogicLayer
{
    class StudentSubjectAverageBLL
    {
        public ObservableCollection<StudentSubjectAverage> StudentSubjectAverageList { get; set; }
        public ObservableCollection<CorigentStudent> StudentSubjectAverageCorigList { get; set; }
        public ObservableCollection<StudentAbsence> StudentiExmatriculati { get; set; }
        public ObservableCollection<Student> Repetenti { get; set; }


        public ObservableCollection<FinalAverage> FinalAverageList { get; set; }

        public string ErrorMessage { get; set; }

        StudentSubjectAverageDAL studentSubjectAverageDAL = new StudentSubjectAverageDAL();

        public ObservableCollection<StudentSubjectAverage> GetAllStudentSubjectAverage()
        {
            return studentSubjectAverageDAL.GetAllStudentSubjectAverage();
        }
        public ObservableCollection<CorigentStudent> GetAllStudentSubjectAverageCorigList()
        {
            return studentSubjectAverageDAL.GetAllCorigentStudent();
        }
        public ObservableCollection<StudentAbsence> GetAllExmatriculatiStudenti()
        {
            return studentSubjectAverageDAL.GetAllExmatriculatiStudenti();
        }
        public ObservableCollection<FinalAverage> GetFinalAverages()
        {
            return studentSubjectAverageDAL.GetFinalAverages();
        }
        public ObservableCollection<Student> GetRepetenti()
        {
            return studentSubjectAverageDAL.GetRepetenti();
        }
        public ObservableCollection<StudentSubjectAverage> GetAllStudentSubjectAverageByStudentId(Student s)
        {
            return studentSubjectAverageDAL.GetAllStudentSubjectAverageByStudentId(s);
        }
        public ObservableCollection<StudentSubjectAverage> GetAllStudentSubjectAverageByStudentId()
        {
            return studentSubjectAverageDAL.GetAllStudentSubjectAverageByStudentId();
        }
        public int GetFinalAveragesForOneStudent()
        {
            return studentSubjectAverageDAL.GetFinalAveragesForOneStudent();
        }

        public void AddStudentSubjectAverage(StudentSubjectAverage studentSubjectAverage)
        {

            studentSubjectAverageDAL.AddStudentSubjectAverage(studentSubjectAverage);
            //StudentSubjectAverageList.Add(studentSubjectAverage);
        }
       
       
    }
}

