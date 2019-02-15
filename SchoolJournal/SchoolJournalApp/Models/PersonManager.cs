using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SchoolJournalDBAccess;

namespace SchoolJournalApp.Models
{
    public class PersonManager : IPersonManager
    {
        private static IList<Person> CreateList(string connName)
        {
            SqlConnection conn = DBAccess.OpenConnection(connName);
            SqlDataReader personsReader = DBAccess.GetObjectFromReader(conn,"select PersonID, PersonName,PersonEmail,PersonPhone,PersonAddress from Persons");

            IList<Person> personList = new List<Person>();
            while (personsReader.Read())
            {
                personList.Add(new Person
                {
                    PersonID = (int)personsReader[0],
                    PersonName = (personsReader[1] == DBNull.Value) ? string.Empty : (string)personsReader[1],
                    PersonEmail = (personsReader[2] == DBNull.Value) ? string.Empty : (string)personsReader[2],
                    PersonPhone = (personsReader[3] == DBNull.Value) ? string.Empty : (string)personsReader[3],
                    PersonAddress = (personsReader[4] == DBNull.Value) ? string.Empty : (string)personsReader[4]
                    //PersonName = (string)personsReader[1],
                    //PersonEmail = (string)personsReader[2],
                    //PersonPhone = (string)personsReader[3],
                    //PersonAddress = (string)personsReader[4]
                });
            }
            DBAccess.CloseConnection(conn);
            return personList;
        }

        public static IList<Person> personList = CreateList(DBAccess.ConexiuneCurenta);

        internal static int AddPerson(string connName, string personName, string personEmail, string personPhone, string personAddress)
        {
            SqlConnection connection = DBAccess.OpenConnection(connName);

            SqlParameter personNameParam = DBAccess.newParam("personNameParam", personName);
            SqlParameter personEmailParam = DBAccess.newParam("personEmailParam", personEmail);
            SqlParameter personPhoneParam = DBAccess.newParam("personPhoneParam", personPhone);
            SqlParameter personAddressParam = DBAccess.newParam("personAddressParam", personAddress);

            SqlCommand addNewPerson = new SqlCommand(
                    "insert into Persons(PersonName,PersonEmail,PersonPhone,PersonAddress) values(@personNameParam,@personEmailParam,@personPhoneParam,@personAddressParam)"+
                    "select cast(SCOPE_IDENTITY() as int)");

            addNewPerson.Connection = connection;

            addNewPerson.Parameters.Add(personNameParam);
            addNewPerson.Parameters.Add(personEmailParam);
            addNewPerson.Parameters.Add(personPhoneParam);
            addNewPerson.Parameters.Add(personAddressParam);

            return (int)addNewPerson.ExecuteScalar();
        }

        public void Save(Person person)
        {
            //personList.Add(person);
            var newPerson = new Person(DBAccess.ConexiuneCurenta, person.PersonName, person.PersonEmail, person.PersonPhone, person.PersonAddress);
        }

        public Person Get(int id)
        {
            foreach (var pers in personList)
                if (pers.PersonID == id)
                    return pers;
            return null;
        }

        public IList<Person> GetAll()
        {
            return personList;
        }
    }
}