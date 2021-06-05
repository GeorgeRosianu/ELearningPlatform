using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    class Absence : BasePropertyChanged
    {
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
        private int teacherID;
        public int TeacherID
        {
            get
            {
                return teacherID;
            }
            set
            {
                teacherID = value;
                NotifyPropertyChanged("TeacherID");
            }
        }

        private string date;
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                NotifyPropertyChanged("Date");
            }
        }
        private string state;
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                NotifyPropertyChanged("State");
            }
        }
    }
}
