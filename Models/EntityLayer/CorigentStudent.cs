using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPlatform.Models.EntityLayer;

namespace EducationPlatform.ViewModels
{
    class CorigentStudent : BasePropertyChanged
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
        private string subject;
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
                NotifyPropertyChanged("Subject");
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
