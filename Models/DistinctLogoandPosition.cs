using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.Models
{
    public class DistinctLogoandPosition
    {
        public int Id { get; set; }
        public List<int> LogoId { get; set; }
        public List<int> PositionId { get; set; }

    }
}
