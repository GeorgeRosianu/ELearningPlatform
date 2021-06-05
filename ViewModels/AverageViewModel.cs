using System.Collections.ObjectModel;
using System.Windows.Input;
using EducationPlatform.Models.BusinessLogicLayer;
using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels.Commands;

namespace EducationPlatform.ViewModels
{
    class AverageViewModel : BasePropertyChanged
    {
        private SubjectStudentMarkBLL ssmBLL = new SubjectStudentMarkBLL();
        private StudentSubjectAverageBLL ssaBLL = new StudentSubjectAverageBLL();
        private float average;
        public float Average
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
        public ObservableCollection<SubjectStudentMark> SSMList
        {
            get
            {
                return ssmBLL.SSMList;
            }
            set
            {
                ssmBLL.SSMList = value;
                NotifyPropertyChanged("SMMList");

            }
        }


        private StudentSubjectBLL studentBLL = new StudentSubjectBLL();
        public ObservableCollection<StudentSubject> StudentSubjectsList
        {
            get
            {
                return studentBLL.StudentSubjectsList;
            }
            set
            {
                studentBLL.StudentSubjectsList = value;
            }
        }
        public AverageViewModel()
        {

            StudentSubjectsList = studentBLL.GetAllStudentSubjects();


        }
        public string ErrorMessage
        {
            get
            {
                return ssmBLL.ErrorMessage;
            }
            set
            {
                ssmBLL.ErrorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }
        public void GetMarks(StudentSubject ss)
        {
            SSMList = ssmBLL.GetAllSSMByStudentIdAndSubjectId(ss);
            NotifyPropertyChanged("SSMList");

            if (ssmBLL.GetMarkCount(ss) >= 3)
            {
                if (ssmBLL.VerifyIfClassHasThesis(ss) > 0)
                {
                    if (ssmBLL.GetThesisMark(ss) > 0)
                    {
                        Average = (ssmBLL.GetMarkAverage(ss) * 3 + ssmBLL.GetThesisMark(ss)) / 4;
                        NotifyPropertyChanged("Average");
                        ssaBLL.AddStudentSubjectAverage(new StudentSubjectAverage
                        {
                            SemesterID = 1,
                            StudentID = ss.StudentID,
                            SubjectID = ss.SubjectID,
                            Average = (int)Average
                        });

                    }
                    else
                    {
                        ErrorMessage = "Nu este trecuta teza!";
                        NotifyPropertyChanged("ErrorMessage");
                      

                    }

                }
                else
                {
                    Average = ssmBLL.GetAverage(ss);
                    NotifyPropertyChanged("Average");
                    ssaBLL.AddStudentSubjectAverage(new StudentSubjectAverage
                    {
                        SemesterID = 1,
                        StudentID=ss.StudentID,
                        SubjectID=ss.SubjectID,
                        Average=(int)Average
                    });


                }

            }
            else ErrorMessage = "Nu sunt suficiente note!";
            NotifyPropertyChanged("ErrorMessage");
          

        }

        private ICommand showCommand;
        public ICommand ShowCommand
        {
            get
            {
                if (showCommand == null)
                {


                    showCommand = new RelayCommand<StudentSubject>(this.GetMarks);
                }
                return showCommand;
            }
        }


    }
}
