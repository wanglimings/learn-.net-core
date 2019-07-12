﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreLearn
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PublishedOn { get; set; }
        public  int AuthorId { get; set; }
        public  Author Author { get; set; }

    }
}
