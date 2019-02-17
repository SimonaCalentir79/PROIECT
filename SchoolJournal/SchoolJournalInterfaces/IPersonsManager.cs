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
        IList<Persons> GetAllPersons();

        Persons Get(int id);

        void Save(Persons person);

        void Delete(int id);

        void Add(Persons person);
    }
}
