using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    class FinalAverage : BasePropertyChanged
    {
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

        private int average;
        public int Average
        {
            get
            {
                return average;
            }
            set
            {
                average = value;
                NotifyPropertyChanged("Average");
            }
        }

       
    }
}
