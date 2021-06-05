using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EducationPlatform.Models.BusinessLogicLayer;
using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels.Commands;

namespace EducationPlatform.ViewModels
{
    class SubjectStudentMarkViewModel : BasePropertyChanged
    {
        private SubjectStudentMarkBLL ssmBLL = new SubjectStudentMarkBLL();

        public ObservableCollection<SubjectStudentMark> SSMList
        {
            get
            {
                return ssmBLL.SSMList;
            }
            set
            {
                ssmBLL.SSMList = value;
            }
        }
        public SubjectStudentMarkViewModel()
        {
            SSMList = ssmBLL.GetAllSSM();
        }
        public string ErrorMessage
        {
            get
            {
                return ssmBLL.ErrorMessage;
            }
            set
            {
                ssmBLL.ErrorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<SubjectStudentMark>(ssmBLL.AddSSM);
                }
                return addCommand;
            }
        }

   

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<SubjectStudentMark>(ssmBLL.DeleteSSM);
                }
                return deleteCommand;
            }
        }
    }
}
