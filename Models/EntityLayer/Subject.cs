using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    class Subject : BasePropertyChanged

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
                NotifyPropertyChanged("SubjectName");
            }
        }
    }
}
