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
    class ThesisViewModel : BasePropertyChanged
    {
        private ThesisBLL thesisBLL = new ThesisBLL();
        public ObservableCollection<Thesis> ThesisList
        {
            get
            {
                return thesisBLL.ThesisList;
            }
            set
            {
                thesisBLL.ThesisList = value;
            }
        }
        public ThesisViewModel()
        {
            ThesisList = thesisBLL.GetAllThesis();
        }
        public string ErrorMessage
        {
            get
            {
                return thesisBLL.ErrorMessage;
            }
            set
            {
                thesisBLL.ErrorMessage = value;
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
                    addCommand = new RelayCommand<Thesis>(thesisBLL.AddThesis);
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
                    updateCommand = new RelayCommand<Thesis>(thesisBLL.ModifyThesis);
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
                    deleteCommand = new RelayCommand<Thesis>(thesisBLL.DeleteThesis);
                }
                return deleteCommand;
            }
        }
    }
}
