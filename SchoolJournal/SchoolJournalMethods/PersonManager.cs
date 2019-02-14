using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournalApp.Models.Person;

namespace SchoolJournalMethods
{
    public class PersonManager : IPersonManager
    {
        Person IPersonManager.Get(int id)
        {
            throw new NotImplementedException();
        }

        IList<Person> IPersonManager.GetAll()
        {
            throw new NotImplementedException();
        }

        void IPersonManager.Save(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
