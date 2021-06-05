using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EducationPlatform.Models.BusinessLogicLayer;
using EducationPlatform.Models.DataAccessLayer;
using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels.Commands;
using Microsoft.Win32;

namespace EducationPlatform.ViewModels
{
    class TeacherWindowViewModel
    {
        private ClassBLL classBLL = new ClassBLL();
        private SubjectBLL subjectBLL = new SubjectBLL();
        private StudentBLL studentBLL = new StudentBLL();

        private MaterialBLL materialBLL = new MaterialBLL();
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
        public ObservableCollection<Material> MaterialsList
        {
            get
            {
                return materialBLL.MaterialsList;
            }
            set
            {
                materialBLL.MaterialsList = value;
            }
        }
        public ObservableCollection<Subject> SubjectsList
        {
            get
            {
                return subjectBLL.SubjectsList;
            }
            set
            {
                subjectBLL.SubjectsList = value;
            }
        }
        public ObservableCollection<Student> StudentsList
        {
            get
            {
                return studentBLL.StudentsList;
            }
            set
            {
                studentBLL.StudentsList = value;
            }
        }
        public TeacherWindowViewModel()
        {
            ClassesList = classBLL.GetAllClassesByTeacherId();
            SubjectsList = subjectBLL.GetAllSubjectsByTeacherId();
            StudentsList = studentBLL.GetAllStudentsByTeacherId();
            MaterialsList = materialBLL.GetAllMaterialsByTeacherId();

        }
        public void AddMaterial(Material param)
        {

            string path=null;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image files (*.pdf) | *.pdf";

            if (f.ShowDialog() == true)
            {

                path = f.FileName;


            }
            int teacherId;
            if (!int.TryParse(DALHelper.id.ToString(), out teacherId))
            {
               // return null;
            }

            materialBLL.AddMaterial(new Material
            {
                TeacherID = teacherId,
                Path = path
            }); ;
        }
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Material>(AddMaterial);
                }
                return addCommand;
            }
        }
    }
}
