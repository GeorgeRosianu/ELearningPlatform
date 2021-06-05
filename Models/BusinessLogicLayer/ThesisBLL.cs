using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPlatform.Exceptions;
using EducationPlatform.Models.DataAccessLayer;
using EducationPlatform.Models.EntityLayer;

namespace EducationPlatform.Models.BusinessLogicLayer
{
    class ThesisBLL
    {
        public ObservableCollection<Thesis> ThesisList { get; set; }
        public string ErrorMessage { get; set; }

        ThesisDAL thesisDAL = new ThesisDAL();

        public ObservableCollection<Thesis> GetAllThesis()
        {
            return thesisDAL.GetAllThesis();
        }

       
        public void AddThesis(Thesis thesis)
        {

            thesisDAL.AddThesis(thesis);
            ThesisList.Add(thesis);
        }
        public void ModifyThesis(Thesis thesis)
        {
            if (thesis == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
           
            thesisDAL.ModifyThesis(thesis);
        }

        public void DeleteThesis(Thesis thesis)
        {
            if (thesis == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare!");
            }
           
            thesisDAL.DeleteThesis(thesis);
            ThesisList.Remove(thesis);
        }
    }
}
