using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EducationPlatform.Models.BusinessLogicLayer;
using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels.Commands;

namespace EducationPlatform.ViewModels
{
    class AbsenceViewModel : BasePropertyChanged
    {
        private AbsenceBLL absenceBLL = new AbsenceBLL();
        private AbsenceBLL absenceBLL2 = new AbsenceBLL();
        private AbsenceBLL absenceBLL3 = new AbsenceBLL();
        private AbsenceBLL absenceBLL4 = new AbsenceBLL();

        private StudentBLL studentBLL = new StudentBLL();
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
        private int totalAbsences;
        public int TotalAbsences
        {
            get
            {
                return totalAbsences;
            }
            set
            {
                totalAbsences = value;
                NotifyPropertyChanged("TotalAbsences");
            }
        }
        private int totalNemotivatedAbsences;
        public int TotalNemotivatedAbsences
        {
            get
            {
                return totalNemotivatedAbsences;
            }
            set
            {
                totalNemotivatedAbsences = value;
                NotifyPropertyChanged("TotalNemotivatedAbsences");
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
        public ObservableCollection<Absence> StudentAbsencesList
        {
            get
            {
                return absenceBLL4.AbsencesList;
            }
            set
            {
                absenceBLL4.AbsencesList = value;
            }
        }
        public ObservableCollection<Absence> NemotivatedAbsencesList
        {
            get
            {
                return absenceBLL3.AbsencesList;
            }
            set
            {
                absenceBLL3.AbsencesList = value;
            }
        }

        public ObservableCollection<Absence> AbsencesListTwo
        {
            get
            {
                return absenceBLL2.AbsencesList;
            }
            set
            {
                absenceBLL2.AbsencesList = value;
            }
        }
        public AbsenceViewModel()
        {
            StudentsList = studentBLL.GetAllStudentsByClassMasterId();

            AbsencesList = absenceBLL.GetAllAbsences();
            TotalAbsences = absenceBLL.GetNumberOfAbsences();
            AbsencesListTwo = absenceBLL2.GetAllAbsencesByClassMasterId();
            NemotivatedAbsencesList = absenceBLL3.GetAllNemotivatedAbsencesByClassMasterId();
  
            TotalNemotivatedAbsences = absenceBLL3.GetNemotivatedAbsences();
        }
        public void GetMarks(Student ss)
        {
            StudentAbsencesList = absenceBLL4.GetAllAbsencesByStudentId(ss);
            NotifyPropertyChanged("StudentAbsencesList");
        }
        public string ErrorMessage
        {
            get
            {
                return absenceBLL.ErrorMessage;
            }
            set
            {
                absenceBLL.ErrorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Absence>(absenceBLL.AddAbsence);
                }
                return addCommand;
            }
        }
        private ICommand showCommand;
        public ICommand ShowCommand
        {
            get
            {
                if (showCommand == null)
                {


                    showCommand = new RelayCommand<Student>(this.GetMarks);
                }
                return showCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Absence>(absenceBLL.ModifyAbsence);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Absence>(absenceBLL.DeleteAbsence);
                }
                return deleteCommand;
            }
        }
    }
}
