using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinmarket.Models
{
    public class Listing
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryID { get; set; }
        public int ListingID { get; set; }

        public Category Category { get; set; }
    }
}
