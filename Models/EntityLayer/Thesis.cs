using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    class Thesis : BasePropertyChanged
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
    }
}
