using PriceCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.ViewModels
{
    public class ListOfPositionLogoViewModel
    {

        public int Id { get; set; }

        public OrderPositionLogo OrderPositionLogo { get; set; }

        public List<PositionLogo> PositionsLogos { get; set; }
    }
}
