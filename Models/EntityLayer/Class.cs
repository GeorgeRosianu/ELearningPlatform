using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    class Class : BasePropertyChanged
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
        private int classMasterID;
        public int ClassMasterID
        {
            get
            {
                return classMasterID;
            }
            set
            {
                classMasterID = value;
                NotifyPropertyChanged("ClassMasterID");
            }
        }

        private string specialization;
        public string Specialization
        {
            get
            {
                return specialization;
            }
            set
            {
                specialization = value;
                NotifyPropertyChanged("Specialization");
            }
        }
        private int studyYear;
        public int StudyYear
        {
            get
            {
                return studyYear;
            }
            set
            {
                studyYear = value;
                NotifyPropertyChanged("StudyYear");
            }
        }
    }
}
