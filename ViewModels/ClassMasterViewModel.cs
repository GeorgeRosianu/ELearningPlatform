using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPlatform.Comparators;
using EducationPlatform.Models.BusinessLogicLayer;
using EducationPlatform.Models.EntityLayer;

namespace EducationPlatform.ViewModels
{
    class ClassMasterViewModel : BasePropertyChanged
    {
        private StudentBLL studentBLL = new StudentBLL();
        private AbsenceBLL absenceBLL = new AbsenceBLL();
        private StudentSubjectAverageBLL ssaBLL = new StudentSubjectAverageBLL();
        public ObservableCollection<FinalAverage> GeneralAverageList
        {
            get
            {
                return ssaBLL.FinalAverageList;
            }
            set
            {
                ssaBLL.FinalAverageList = value;
            }
        }
        public ObservableCollection<Student> StudentsList
        {
            get
            {
                return studentBLL.StudentsList;
            }
            set
            {
                studentBLL.StudentsList = value;
            }
        }
        public ObservableCollection<CorigentStudent> CorigentsList
        {
            get
            {
                return ssaBLL.StudentSubjectAverageCorigList;
            }
            set
            {
                ssaBLL.StudentSubjectAverageCorigList = value;

            }
        }
        public ObservableCollection<StudentAbsence> StudentiExmatriculati
        {
            get
            {
                return ssaBLL.StudentiExmatriculati;
            }
            set
            {
                ssaBLL.StudentiExmatriculati = value;

            }
        }
        public ObservableCollection<Student> Repetenti
        {
            get
            {
                return ssaBLL.Repetenti;
            }
            set
            {
                ssaBLL.Repetenti = value;

            }
        }

        public ClassMasterViewModel()
        {
            StudentsList = studentBLL.GetAllStudentsByClassMasterId();

            GeneralAverageList = ssaBLL.GetFinalAverages();
            CompareAverage cg = new CompareAverage();

            GeneralAverageList.ToList().Sort(cg);

            TotalAbsences = absenceBLL.GetAbsences().ToString();
            TotalNemotivatedAbsences = absenceBLL.GetNemotivatedAbsences().ToString();
            CorigentsList = ssaBLL.GetAllStudentSubjectAverageCorigList();
            StudentiExmatriculati = ssaBLL.GetAllExmatriculatiStudenti();

        }
        public String TotalAbsences
        {
            get
            {
                return absenceBLL.absences.ToString();
            }
            set
            {
                absenceBLL.absences = Int32.Parse(value);
            }
        }
        public String TotalNemotivatedAbsences
        {
            get
            {
                return absenceBLL.nemotivatedAbsences.ToString();
            }
            set
            {
                absenceBLL.nemotivatedAbsences = Int32.Parse(value);
            }
        }
        public String First
        {
            get
            {
                return GeneralAverageList[0].Name;
            }
            set
            {
                First = value;
            }
        }
        public String Second
        {
            get
            {
                return GeneralAverageList[1].Name;
            }
            set
            {
                Second = value;
            }
        }
        public String Third
        {
            get
            {
                return GeneralAverageList[2].Name;
            }
            set
            {
                Third = value;
            }
        }
        public String Fourth
        {
            get
            {
                return GeneralAverageList[3].Name;
            }
            set
            {
                Fourth = value;
            }
        }
        public String Fifth
        {
            get
            {
                return GeneralAverageList[4].Name;
            }
            set
            {
                Fifth = value;
            }
        }
        public String Sixth
        {
            get
            {
                return GeneralAverageList[5].Name;
            }
            set
            {
                Sixth = value;
            }
        }



    }
}
