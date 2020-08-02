using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
    public class BookDto
    {
        public string Name { get; set; }
        public int Genre { get; set; }
        public double Price { get; set; }
        public int Pages { get; set; }
        public DateTime PublishedOn { get; set; }
    }
}
