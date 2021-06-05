using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    class ClassMaster : BasePropertyChanged
    {
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
