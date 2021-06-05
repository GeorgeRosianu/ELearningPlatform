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
    class SubjectViewModel : BasePropertyChanged
    {
      private  SubjectBLL subjectBLL = new SubjectBLL();
        public ObservableCollection<Subject> SubjectsList
        {
            get
            {
                return subjectBLL.SubjectsList;
            }
            set
            {
                subjectBLL.SubjectsList = value;
            }
        }
        public SubjectViewModel()
        {
            SubjectsList = subjectBLL.GetAllSubjects();
        }
        public string ErrorMessage
        {
            get
            {
                return subjectBLL.ErrorMessage;
            }
            set
            {
                subjectBLL.ErrorMessage = value;
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
                    addCommand = new RelayCommand<Subject>(subjectBLL.AddSubject);
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
                    updateCommand = new RelayCommand<Subject>(subjectBLL.ModifySubject);
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
                    deleteCommand = new RelayCommand<Subject>(subjectBLL.DeleteSubject);
                }
                return deleteCommand;
            }
        }

    }
}
