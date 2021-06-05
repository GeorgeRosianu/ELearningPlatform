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
    class AbsenceBLL
    {
        public ObservableCollection<Absence> AbsencesList { get; set; }
        public string ErrorMessage { get; set; }

        AbsenceDAL absenceDAL = new AbsenceDAL();
        public int absences;
        public int nemotivatedAbsences;

        public ObservableCollection<Absence> GetAllAbsences()
        {
            return absenceDAL.GetAllAbsences();
        }
        public ObservableCollection<Absence> GetAllAbsencesByClassMasterId()
        {
            return absenceDAL.GetAllAbsencesByClassMasterId();
        }
        public ObservableCollection<Absence> GetAllAbsencesByStudentId(Student ss)
        {
            return absenceDAL.GetAllAbsencesByStudentId(ss);
        }
        public ObservableCollection<Absence> GetAllAbsencesByStudentId()
        {
            return absenceDAL.GetAllAbsencesByStudentId();
        }
        public ObservableCollection<Absence> GetAllNemotivatedAbsencesByClassMasterId()
        {
            return absenceDAL.GetAllNemotivatedAbsencesByClassMasterId();
        }
        
        public void AddAbsence(Absence absence)
        {
           
            absenceDAL.AddAbsence(absence);
            AbsencesList.Add(absence);
        }

        public int GetAbsences()
        {
            return absenceDAL.GetAbsences();
        }
        public int GetNemotivatedAbsences()
        {
            return absenceDAL.GetNemotivatedAbsences();
        }
        public int GetNumberOfAbsences()
        {
            return absenceDAL.GetNumberOfAbsences();
        }
        public void ModifyAbsence(Absence absence)
        {
           
            absenceDAL.ModifyAbsence(absence);
        }

        public void DeleteAbsence(Absence absence)
        {
            if (absence == null)
            {

               
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
            
            absenceDAL.DeleteAbsence(absence);
            AbsencesList.Remove(absence);
        }
    }
}
