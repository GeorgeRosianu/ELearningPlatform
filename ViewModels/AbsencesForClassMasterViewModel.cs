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
    class AbsencesForClassMasterViewModel : BasePropertyChanged
    {
        private AbsenceBLL absenceBLL = new AbsenceBLL();
       
     
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
      
        public AbsencesForClassMasterViewModel()
        {
            AbsencesList = absenceBLL.GetAllAbsencesByClassMasterId();
          
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
