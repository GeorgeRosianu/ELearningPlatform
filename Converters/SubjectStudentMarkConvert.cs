using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using EducationPlatform.Models.EntityLayer;

namespace EducationPlatform.Converters
{
    class SubjectStudentMarkConvert :IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
            {
               
                int subjectId;
                if (!int.TryParse(values[0].ToString(), out subjectId))
                {
                    return null;
                }
                int studentId;
                if (!int.TryParse(values[1].ToString(), out studentId))
                {
                    return null;
                }
                int semesterId;
                if (!int.TryParse(values[2].ToString(), out semesterId))
                {
                    return null;
                }
                int mark;
                if (!int.TryParse(values[3].ToString(), out mark))
                {
                    return null;
                }

                int isThesis;
                if (!int.TryParse(values[5].ToString(), out isThesis))
                {
                    return null;
                }


                return new SubjectStudentMark()
                {
                    SubjectID=subjectId,
                    StudentID=studentId,
                    SemesterID=semesterId,
                    Mark=mark,
                    Date=values[4].ToString(),
                    IsThesis=isThesis
                };
            }
            else
            {
                return null;
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            //Person pers = value as Person;
            //object[] result = new object[2] { pers.Name, pers.Address };
            //return result;
            throw new NotImplementedException();
        }
    }
}
