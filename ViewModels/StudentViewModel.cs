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
    class StudentViewModel : BasePropertyChanged
    {
       private  StudentBLL studentBLL = new StudentBLL();
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
        public StudentViewModel()
        {
            StudentsList = studentBLL.GetAllStudents();
        }
        public string ErrorMessage
        {
            get
            {
                return studentBLL.ErrorMessage;
            }
            set
            {
                studentBLL.ErrorMessage = value;
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
                    addCommand = new RelayCommand<Student>(studentBLL.AddStudent);
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
                    updateCommand = new RelayCommand<Student>(studentBLL.ModifyStudent);
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
                    deleteCommand = new RelayCommand<Student>(studentBLL.DeleteStudent);
                }
                return deleteCommand;
            }
        }

    }
}

