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
    class ClassSubjectViewModel :BasePropertyChanged
    {
        private ClassSubjectBLL classSubjectBLL = new ClassSubjectBLL();
        public ObservableCollection<ClassSubject> ClassSubjectsList
        {
            get
            {
                return classSubjectBLL.ClassSubjectsList;
            }
            set
            {
                classSubjectBLL.ClassSubjectsList = value;
            }
        }
        public ClassSubjectViewModel()
        {
            ClassSubjectsList = classSubjectBLL.GetAllClassSubjects();
        }
        public string ErrorMessage
        {
            get
            {
                return classSubjectBLL.ErrorMessage;
            }
            set
            {
                classSubjectBLL.ErrorMessage = value;
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
                    addCommand = new RelayCommand<ClassSubject>(classSubjectBLL.AddClassSubject);
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
                    updateCommand = new RelayCommand<ClassSubject>(classSubjectBLL.ModifyClassSubject);
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
                    deleteCommand = new RelayCommand<ClassSubject>(classSubjectBLL.DeleteClassSubject);
                }
                return deleteCommand;
            }
        }
    }
}

