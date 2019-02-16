﻿using SchoolJournalDataAccess;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournalBusinessLogic
{
    public class PersonsManager : IPersonsManager
    {
        private static SchoolJournalEntities db;

        private IList<Persons> personsList = new List<Persons>();

        public PersonsManager()
        {
            db = new SchoolJournalEntities();
        }

        public IList<Persons> GetAllPersons()
        {
            return db.Persons.Select(p => p).ToList(); 
        }

        public Persons Get(int id)
        {
            foreach (var pers in db.Persons.Select(p => p).ToList())
                if (pers.PersonID == id)
                    return pers;
            return null;
        }

        public void Save(Persons persons)
        {
            throw new NotImplementedException();
        }
    }
}