using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactListApplication.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fullname
        {
            get
            {
                return string.Format("{0} {1}", Surname, Name);
            }
        }

        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public Contact()
        {
            PhoneNumbers = new List<PhoneNumber>();
        }
    }
}