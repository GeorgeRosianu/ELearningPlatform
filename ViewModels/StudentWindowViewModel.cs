using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPlatform.Models.BusinessLogicLayer;
using EducationPlatform.Models.EntityLayer;

namespace EducationPlatform.ViewModels
{
    class StudentWindowViewModel : BasePropertyChanged
    {
        private SubjectStudentMarkBLL ssmBLL = new SubjectStudentMarkBLL();
        private AbsenceBLL absenceBLL = new AbsenceBLL();
        private StudentSubjectAverageBLL studentSubjectAverageBLL = new StudentSubjectAverageBLL();
        private MaterialBLL materialBLL = new MaterialBLL();

        public ObservableCollection<SubjectStudentMark> SSMList
        {
            get
            {
                return ssmBLL.SSMList;
            }
            set
            {
                ssmBLL.SSMList = value;
            }
        }
        public ObservableCollection<Absence> AbsencesList
        {
            get
            {
                return absenceBLL.AbsencesList;
            }
            set
            {
                absenceBLL.AbsencesList = value;
            }
        }
        public ObservableCollection<Material> MaterialsList
        {
            get
            {
                return materialBLL.MaterialsList;
            }
            set
            {
                materialBLL.MaterialsList = value;
            }
        }
        public ObservableCollection<StudentSubjectAverage> StudentSubjectAverageList
        {
            get
            {
                return studentSubjectAverageBLL.StudentSubjectAverageList;
            }
            set
            {
                studentSubjectAverageBLL.StudentSubjectAverageList = value;
            }
        }
        private int average;
        public int Average
        {
            get
            {
                return average;
            }
            set
            {
                average = value;
                NotifyPropertyChanged("Average");

            }
        }
        public StudentWindowViewModel()
        {
            SSMList = ssmBLL.GetAllSSMByStudentId();
            AbsencesList = absenceBLL.GetAllAbsencesByStudentId();
            StudentSubjectAverageList = studentSubjectAverageBLL.GetAllStudentSubjectAverageByStudentId();
            Average = studentSubjectAverageBLL.GetFinalAveragesForOneStudent();
            MaterialsList = materialBLL.GetAllMaterials();

        }
    }
}
