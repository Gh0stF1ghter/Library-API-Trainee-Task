﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new Collection<Book>();
    }
}
