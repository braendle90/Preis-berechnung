using PriceCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.ViewModels
{
    public class CalculationTableViewModel
    {

        public int Id { get; set; }
        public string OfferId { get; set; }
        public List<PositionLogo> PostionLogoListe { get; set; }
    }
}
