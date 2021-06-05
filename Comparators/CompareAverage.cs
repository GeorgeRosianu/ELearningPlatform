using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPlatform.Models.EntityLayer;

namespace EducationPlatform.Comparators
{
    class CompareAverage : IComparer<FinalAverage>
    {
        public int Compare(FinalAverage x, FinalAverage y)
        {
            return x.Average.CompareTo(y.Average);
        }
    }
}
