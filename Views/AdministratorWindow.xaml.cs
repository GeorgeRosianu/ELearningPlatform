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

namespace EducationPlatform.Views
{
    /// <summary>
    /// Interaction logic for AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : UserControl
    {
        public AdministratorWindow()
        {
            InitializeComponent();
        }

      

        private void BTN1_Click(object sender, RoutedEventArgs e)
        {
            ClassSubjectWindow classSubjectWindow = new ClassSubjectWindow();
            classSubjectWindow.Show();

        }

        private void BTN2_Click(object sender, RoutedEventArgs e)
        {
            TeacherSubjectClass teacherSubjectClass = new TeacherSubjectClass();
            teacherSubjectClass.Show();

        }

        private void BTN3_Click(object sender, RoutedEventArgs e)
        {
           StudentClass studentClass = new StudentClass();
            studentClass.Show();

        }

        private void Students_Click(object sender, RoutedEventArgs e)
        {
            StudentsWindow studentsWindow = new StudentsWindow();
            studentsWindow.Show();

        }

        private void Teachers_Click(object sender, RoutedEventArgs e)
        {
            TeachersWindow teachersWindow = new TeachersWindow();
            teachersWindow.Show();

        }

        private void Subjects_Click(object sender, RoutedEventArgs e)
        {
            SubjectsWindow subjectsWindow = new SubjectsWindow();
            subjectsWindow.Show();

        }

        private void Classes_Click(object sender, RoutedEventArgs e)
        {
            ClassesWindow classWindow = new ClassesWindow();
            classWindow.Show();
        }

        private void ClassMasters_Click(object sender, RoutedEventArgs e)
        {
            ClassMastersWindow classMastersWindow = new ClassMastersWindow();
            classMastersWindow.Show();

        }

        private void Thesis_Click(object sender, RoutedEventArgs e)
        {
            ThesisWindow thesisWindow = new ThesisWindow();
            thesisWindow.Show();
        }
    }
}
