using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Birthday { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
