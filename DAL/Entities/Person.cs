using System;
using System.Collections.Generic;

namespace AppDemo.DAL.Entities
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdPersonType { get; set; }

        public virtual PersonType IdPersonTypeNavigation { get; set; }
    }
}
