using PriceCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.ViewModels
{
    public class ShowTableVieModel
    {

        public int Id { get; set; }
        public string OfferId { get; set; }
        public List<OrderPositionLogo> OrderPostionLogoListe { get; set; }
    }
}
