using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppEvolent.Models;

namespace WebAppEvolent.Service
{
    public class ContactRepository
    {

        //public Contact[] Get()
        //{
            
        //}

        public Contact[] GetAllContacts() {
            return new Contact[]
     {
        new Contact
        {
            Id = 1,
            Name = "Glenn Block"
        },
        new Contact
        {
            Id = 2,
            Name = "Dan Roth"
        }
     };
        }
    }
}