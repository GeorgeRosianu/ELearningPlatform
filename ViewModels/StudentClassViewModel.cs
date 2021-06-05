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
    class StudentClassViewModel : BasePropertyChanged
    {

        private StudentClassBLL studentClassBLL = new StudentClassBLL();
        public ObservableCollection<StudentClass> StudentClassList
        {
            get
            {
                return studentClassBLL.StudentClassList;
            }
            set
            {
                studentClassBLL.StudentClassList = value;
            }
        }
        public StudentClassViewModel()
        {
            StudentClassList = studentClassBLL.GetAllStudentClass();
        }
        public string ErrorMessage
        {
            get
            {
                return studentClassBLL.ErrorMessage;
            }
            set
            {
                studentClassBLL.ErrorMessage = value;
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
                    addCommand = new RelayCommand<StudentClass>(studentClassBLL.AddClassSubject);
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
                    updateCommand = new RelayCommand<StudentClass>(studentClassBLL.ModifyStudentClass);
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
                    deleteCommand = new RelayCommand<StudentClass>(studentClassBLL.DeleteStudentClass);
                }
                return deleteCommand;
            }
        }

    }
}
