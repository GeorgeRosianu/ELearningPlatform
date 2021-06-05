using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using EducationPlatform.Models.EntityLayer;

namespace EducationPlatform.Converters
{
    class ClassConvert : IMultiValueConverter
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
                int classMasterId;
                if (!int.TryParse(values[1].ToString(), out classMasterId))
                {
                    return null;

                }
                int studyYear;
                if (!int.TryParse(values[3].ToString(), out studyYear))
                {
                    return null;
                }

                return new Class()
                {
                    ClassID = classId,
                    ClassMasterID = classMasterId,
                    Specialization = values[2].ToString(),
                    StudyYear = studyYear
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
