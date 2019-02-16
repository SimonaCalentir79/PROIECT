using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournalInterfaces
{
    public interface IPersonsManager
    {
        void Save(Persons persons);

        Persons Get(int id);

        IList<Persons> GetAllPersons();
    }
}
