using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
     class Material : BasePropertyChanged
    {
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

        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
                NotifyPropertyChanged("Path");
            }
        }
    }
}
