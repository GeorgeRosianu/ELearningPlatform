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
    class StudentSubjectAverageViewModel : BasePropertyChanged
    {
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
        private StudentSubjectAverageBLL studentSubjectAverageBLL = new StudentSubjectAverageBLL();

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
        public void GetMarks(Student ss)
        {
            StudentSubjectAverageList = studentSubjectAverageBLL.GetAllStudentSubjectAverageByStudentId(ss);
            NotifyPropertyChanged("StudentSubjectAverageList");
        }
        public StudentSubjectAverageViewModel()
        {
            StudentsList = studentBLL.GetAllStudentsByClassMasterId();
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
    }
}
