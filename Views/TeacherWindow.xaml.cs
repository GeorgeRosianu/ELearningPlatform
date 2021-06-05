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
    /// Interaction logic for TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : UserControl
    {
        public TeacherWindow()
        {
            InitializeComponent();
        }

        private void AddAbsenceButton_Click(object sender, RoutedEventArgs e)
        {
            AbsenceWindow absenceWindow = new AbsenceWindow();
            absenceWindow.Show();

        }
        private void AddMarkButton_Click(object sender, RoutedEventArgs e)
        {
            MarkWindow markWindow = new MarkWindow();
            markWindow.Show();

        }
        private void AddAverageButton_Click(object sender, RoutedEventArgs e)
        {
            AverageWindow averageWindow = new AverageWindow();
            averageWindow.Show();

        }
    }
}
