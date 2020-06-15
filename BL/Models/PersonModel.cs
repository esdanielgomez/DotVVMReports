using System;
using System.Collections.Generic;

namespace AppDemo.BL.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdPersonType { get; set; }
        public string NamePersonType { get; set; }
    }
}