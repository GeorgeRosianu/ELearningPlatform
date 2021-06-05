using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    class TeacherSubjectClass :BasePropertyChanged
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
        private String teacherName;
        public String TeacherName
        {
            get
            {
                return teacherName;
            }
            set
            {
                teacherName = value;
                NotifyPropertyChanged("TeacherName");
            }
        }
    }
}
