using System;
using System.Collections.Generic;

namespace AppDemo.DAL.Entities
{
    public partial class PersonType
    {
        public PersonType()
        {
            Person = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
