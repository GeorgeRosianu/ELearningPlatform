using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    class SubjectStudentMark : BasePropertyChanged
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

        private int mark;
        public int Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
                NotifyPropertyChanged("Mark");
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
        private int isThesis;
       

        public int IsThesis
        {
            get
            {
                return isThesis;
            }
            set
            {
                isThesis = value;
                NotifyPropertyChanged("IsThesis");
            }
        }

    }
}
