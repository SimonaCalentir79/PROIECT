﻿using SchoolJournalDataAccess;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public IList<Persons> GetByName(string name)
        {
            return db.Persons.Where(p => p.PersonName.Contains(name) || name == null).ToList();
        }

        public IList<Persons> GetByAddress(string address)
        {
            return db.Persons.Where(p => p.PersonAddress.Contains(address) || address == null).ToList();
        }

        public Persons Get(int id)
        {
            return db.Persons.Find(id);
        }

        public void Save(Persons person)
        {
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Persons person = this.Get(id);
            db.Persons.Remove(person);
            db.SaveChanges();
        }

        public void Add(Persons person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }
    }
}
