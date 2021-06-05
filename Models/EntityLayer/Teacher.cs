using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    class Teacher : BasePropertyChanged
    {
        private int? teacherID;
        public int? TeacherID
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

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("TeacherName");
            }
        }
    }
}
