using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.Models
{
    public class PriceTable
    {

        public int Id { get; set; }
        public Textil Texil { get; set; }

        public Color NumberColors { get; set; }
        public RangeTable Range { get; set; }

        public decimal Price { get; set; }
    }
}
