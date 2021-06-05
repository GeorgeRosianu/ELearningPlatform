using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    class StudentAbsence :BasePropertyChanged
    {
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
                NotifyPropertyChanged("Name");
            }
        }
        private int absences;
        public int Absences
        {
            get
            {
                return absences;
            }
            set
            {
                absences = value;
                NotifyPropertyChanged("Absences");
            }
        }

    }
}
