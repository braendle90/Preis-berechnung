using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.Models
{
    public class ShowPriceModel
    {


        public Position Position { get; set; }
        public Logo Logo { get; set; }
        public OrderPositionLogo OrderPositionLogo { get; set; }

        public decimal PricePerPices { get; set; }

        public int PiecesofTextilWithThisLogo { get; set; }
    }
}
