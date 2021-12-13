using PriceCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.ViewModels
{
    public class GetLogoPositionOPLViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string TextilName { get; set; }
        public int LogoId { get; set; }
        public int PositionId { get; set; }
        public Logo Logo { get; set; }
        public List<Position> PositionList { get; set; }
        public List<Logo> LogoList { get; set; }

    }
}
