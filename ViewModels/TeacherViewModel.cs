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
    class TeacherViewModel : BasePropertyChanged
    {
       private TeacherBLL teacherBLL = new TeacherBLL();
        
        public ObservableCollection<Teacher> TeachersList
        {
            get
            {
                return teacherBLL.TeachersList;
            }
            set
            {
                teacherBLL.TeachersList = value;
            }
        }
        public TeacherViewModel()
        {
            TeachersList = teacherBLL.GetAllTeachers();
        }
        public string ErrorMessage
        {
            get
            {
                return teacherBLL.ErrorMessage;
            }
            set
            {
                teacherBLL.ErrorMessage = value;
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
                    addCommand = new RelayCommand<Teacher>(teacherBLL.AddTeacher);
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
                    updateCommand = new RelayCommand<Teacher>(teacherBLL.ModifyTeacher);
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
                    deleteCommand = new RelayCommand<Teacher>(teacherBLL.DeleteTeacher);
                }
                return deleteCommand;
            }
        }

    }
}

