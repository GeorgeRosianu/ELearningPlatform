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
    class CMasterViewModel : BasePropertyChanged
    {
        private ClassMasterBLL classMasterBLL = new ClassMasterBLL();
        public ObservableCollection<ClassMaster> ClassMastersList
        {
            get
            {
                return classMasterBLL.ClassMastersList;
            }
            set
            {
                classMasterBLL.ClassMastersList = value;
            }
        }
        public CMasterViewModel()
        {
            ClassMastersList = classMasterBLL.GetAllClassMasters();
        }
        public string ErrorMessage
        {
            get
            {
                return classMasterBLL.ErrorMessage;
            }
            set
            {
                classMasterBLL.ErrorMessage = value;
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
                    addCommand = new RelayCommand<ClassMaster>(classMasterBLL.AddClassMaster);
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
                    updateCommand = new RelayCommand<ClassMaster>(classMasterBLL.ModifyClassMaster);
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
                    deleteCommand = new RelayCommand<ClassMaster>(classMasterBLL.DeleteClassMaster);
                }
                return deleteCommand;
            }
        }
    }
}
