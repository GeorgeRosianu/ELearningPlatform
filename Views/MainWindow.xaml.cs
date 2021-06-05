using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EducationPlatform.Models.DataAccessLayer;
using EducationPlatform.ViewModels;

namespace EducationPlatform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            DALHelper.id = IdBox.Text;

            if (ComboUser.SelectedIndex == 0)
            {
                DataContext = new AdministratorViewModel();

            }
            if (ComboUser.SelectedIndex == 1)
            {
                DataContext = new TeacherViewModel();

            }
            if (ComboUser.SelectedIndex == 2)
            {
                DataContext = new ClassMasterViewModel();

            }
            if (ComboUser.SelectedIndex == 3)
            {
                DataContext = new StudentViewModel();

            }

        }

        private void IdBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
