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
    class SubjectStudentMarkBLL
    {
        public ObservableCollection<SubjectStudentMark> SSMList { get; set; }
        public string ErrorMessage { get; set; }

        SubjectStudentMarkDAL ssmDAL = new SubjectStudentMarkDAL();

        public ObservableCollection<SubjectStudentMark> GetAllSSM()
        {
            return ssmDAL.GetAllSSM();
        }
        public ObservableCollection<SubjectStudentMark> GetAllSSMByStudentId()
        {
            return ssmDAL.GetAllSSMByStudentId();
        }
        public int GetAverage(StudentSubject studentSubject)
        {
            return ssmDAL.GetAverage(studentSubject);
        }
        public int GetMarkCount(StudentSubject studentSubject)
        {
            return ssmDAL.GetMarkCount(studentSubject);
        }
        public int VerifyIfClassHasThesis(StudentSubject studentSubject)
        {
            return ssmDAL.VerifyIfClassHasThesis(studentSubject);

        }
        public int GetThesisMark(StudentSubject studentSubject)
        {
            return ssmDAL.GetThesisMark(studentSubject);

        }
        public int GetMarkSum(StudentSubject studentSubject)
        {
            return ssmDAL.GetMarkSum(studentSubject);

        }
        public int GetMarkAverage(StudentSubject studentSubject)
        {
            return ssmDAL.GetMarkAverage(studentSubject);

        }

        public ObservableCollection<SubjectStudentMark> GetAllSSMByStudentIdAndSubjectId(StudentSubject studentSubject)
        {
            return ssmDAL.GetAllSSMByStudentIdAndSubjectId(studentSubject);
        }

        public void AddSSM(SubjectStudentMark subjectStudentMark)
        {

            ssmDAL.AddSSM(subjectStudentMark);
            SSMList.Add(subjectStudentMark);



        }

        public void DeleteSSM(SubjectStudentMark subjectStudentMark)
        {
            if (subjectStudentMark == null)
            {
                throw new AgendaException("Trebuie precizata o persoana!");
            }
          
            ssmDAL.DeleteSSM(subjectStudentMark);
            SSMList.Remove(subjectStudentMark);
        }
    }
}
