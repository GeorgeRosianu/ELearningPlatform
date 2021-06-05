using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    class StudentClass :BasePropertyChanged
    {
        private int classID;
        public int ClassID
        {
            get
            {
                return classID;
            }
            set
            {
                classID = value;
                NotifyPropertyChanged("ClassID");
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
        private String studentName;
        public String StudentName
        {
            get
            {
                return studentName;
            }
            set
            {
                studentName = value;
                NotifyPropertyChanged("StudentName");
            }
        }

    }
}
