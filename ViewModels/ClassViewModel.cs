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
    class ClassViewModel :BasePropertyChanged
    {
        private ClassBLL classBLL = new ClassBLL();
        public ObservableCollection<Class> ClassesList
        {
            get
            {
                return classBLL.ClassesList;
            }
            set
            {
                classBLL.ClassesList = value;
            }
        }
        public ClassViewModel()
        {
            ClassesList = classBLL.GetAllClasses();
        }
        public string ErrorMessage
        {
            get
            {
                return classBLL.ErrorMessage;
            }
            set
            {
                classBLL.ErrorMessage = value;
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
                    addCommand = new RelayCommand<Class>(classBLL.AddClass);
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Class>(classBLL.ModifyClass);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Class>(classBLL.DeleteClass);
                }
                return deleteCommand;
            }
        }
    }
}
