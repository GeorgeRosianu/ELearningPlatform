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
    class ClassSubjectBLL
    {
        public ObservableCollection<ClassSubject> ClassSubjectsList { get; set; }
        public string ErrorMessage { get; set; }

        ClassSubjectDAL classSubjectDAL = new ClassSubjectDAL();

        public ObservableCollection<ClassSubject> GetAllClassSubjects()
        {
            return classSubjectDAL.GetAllClassSubjects();
        }
        public void AddClassSubject(ClassSubject classSubject)
        {

            classSubjectDAL.AddClassSubject(classSubject);
            ClassSubjectsList.Add(classSubject);
        }
        public void ModifyClassSubject(ClassSubject classSubject)
        {
            if (classSubject == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }

            classSubjectDAL.ModifyClassSubject(classSubject);
        }

        public void DeleteClassSubject(ClassSubject classSubject)
        {
            if (classSubject == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
           
            classSubjectDAL.DeleteClassSubject(classSubject);
            ClassSubjectsList.Remove(classSubject);
        }
    }
}
