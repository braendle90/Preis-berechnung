using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.Models
{
    public class OneLogoAndPosition
    {

        public int Id { get; set; }
        public Logo Logo { get; set; }
        public Position Position { get; set; }
        public int Pieces { get; set; }

        public List<PositionLogo> PositionLogoList { get; set; }
    }
}
