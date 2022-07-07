using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContactListApplication.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string pNumber { get; set; }

        public int? ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}