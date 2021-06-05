using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using EducationPlatform.Models.EntityLayer;

namespace EducationPlatform.Converters
{
    class ThesisConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
            {
               
                int classId;
                if (!int.TryParse(values[0].ToString(), out classId))
                {
                    return null;
                }
                int subjectId;
                if (!int.TryParse(values[1].ToString(), out subjectId))
                {
                    return null;
                }
                return new Thesis()
                {
                  SubjectID=subjectId,
                  ClassID=classId


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
