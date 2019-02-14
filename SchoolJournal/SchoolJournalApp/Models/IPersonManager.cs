using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournalApp.Models
{
    interface IPersonManager
    {
        void Save(Person person);

        Person Get(int id);

        IList<Person> GetAll();
    }
}
