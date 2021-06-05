using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    class StudentSubjectAverage : BasePropertyChanged
    {
        private int studentID;
        public int StudentID
        {
            get
            {
                return studentID;
            }
            set
            {
                studentID = value;
                NotifyPropertyChanged("StudentID");
            }
        }
        private int subjectID;
        public int SubjectID
        {
            get
            {
                return subjectID;
            }
            set
            {
                subjectID = value;
                NotifyPropertyChanged("SubjectID");
            }
        }
        private String subjectName;
        public String SubjectName
        {
            get
            {
                return subjectName;
            }
            set
            {
                subjectName = value;
                NotifyPropertyChanged("SubjectName");
            }
        }
        private int semesterID;
        public int SemesterID
        {
            get
            {
                return semesterID;
            }
            set
            {
                semesterID = value;
                NotifyPropertyChanged("SemesterID");
            }
        }
        private int average;
        public int Average
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
    }
}
