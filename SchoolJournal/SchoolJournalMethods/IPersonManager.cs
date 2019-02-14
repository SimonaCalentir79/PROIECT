using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournalApp.Models.Person;

namespace SchoolJournalMethods
{
    interface IPersonManager
    {
        void Save(Person person);
        Person Get(int id);
        IList<Person> GetAll();
    }
}
