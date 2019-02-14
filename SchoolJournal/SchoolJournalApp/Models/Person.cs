using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolJournalApp.Models
{
    public class Person
    {
        internal Person() { }

        public Person(string connName, string Name, string Email, string Phone, string Address)
        {
            this.PersonID = PersonManager.AddPerson(connName, Name, Email, Phone, Address);
        }

        public int PersonID { get; set; }

        [Required]
        [DisplayName("Name ")]
        public string PersonName { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("E-mail ")]
        public string PersonEmail { get; set; }

        [Required]
        [Phone]
        [DisplayName("Phone ")]
        public string PersonPhone { get; set; }

        [Required]
        [DisplayName("Address ")]
        public string PersonAddress { get; set; }
    }
}