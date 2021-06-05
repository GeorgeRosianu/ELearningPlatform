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
    class TeacherSubjectClassViewModel : BasePropertyChanged
    {
        private TeacherSubjectClassBLL teacherSubjectClassBLL = new TeacherSubjectClassBLL();
        public ObservableCollection<TeacherSubjectClass> TeacherSubjectClassList
        {
            get
            {
                return teacherSubjectClassBLL.TeacherSubjectClassList;
            }
            set
            {
                teacherSubjectClassBLL.TeacherSubjectClassList = value;
            }
        }
       
        public TeacherSubjectClassViewModel()
        {
            TeacherSubjectClassList = teacherSubjectClassBLL.GetAllTeacherSubjectClass();

        }
        public string ErrorMessage
        {
            get
            {
                return teacherSubjectClassBLL.ErrorMessage;
            }
            set
            {
                teacherSubjectClassBLL.ErrorMessage = value;
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
                    addCommand = new RelayCommand<TeacherSubjectClass>(teacherSubjectClassBLL.AddTeacherSubjectClass);
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
                    updateCommand = new RelayCommand<TeacherSubjectClass>(teacherSubjectClassBLL.ModifyTeacherSubjectClass);
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
                    deleteCommand = new RelayCommand<TeacherSubjectClass>(teacherSubjectClassBLL.DeleteTeacherSubjectClass);
                }
                return deleteCommand;
            }
        }
    }
}

