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
    class SubjectBLL
    {
        public ObservableCollection<Subject> SubjectsList { get; set; }
        public string ErrorMessage { get; set; }

        SubjectDAL subjectDAL = new SubjectDAL();

        public ObservableCollection<Subject> GetAllSubjects()
        {
            return subjectDAL.GetAllSubjects();
        }

        public ObservableCollection<Subject> GetAllSubjectsByTeacherId()
        {
            return subjectDAL.GetAllSubjectsByTeacherId();
        }
        public void AddSubject(Subject subject)
        {
            if (String.IsNullOrEmpty(subject.Name))
            {
                throw new AgendaException("Numele materiei trebuie sa fie precizat");
            }
            subjectDAL.AddSubject(subject);
            SubjectsList.Add(subject);
        }
        public void ModifySubject(Subject subject)
        {
            if (subject == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
            if (String.IsNullOrEmpty(subject.Name))
            {
                throw new AgendaException("Trebuie precizat numele materiei");
            }
            subjectDAL.ModifySubject(subject);
        }

        public void DeleteSubject(Subject subject)
        {
            if (subject == null)
            {

                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
            
            subjectDAL.DeleteSubject(subject);
            SubjectsList.Remove(subject);
        }
    }
}

