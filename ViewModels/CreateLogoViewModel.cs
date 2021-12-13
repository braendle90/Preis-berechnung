using PriceCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.ViewModels
{
    public class CreateLogoViewModel
    {

        public int Id { get; set; }
        public OrderPositionLogo opl { get; set; }
        public string OfferId { get; set; }
        public string LogoName { get; set; }
        public double LogoSurfaceSize { get; set; }
        public int ColorId { get; set; }
        public List<Color> ColorList { get; set; }

        public OrderPositionLogo OrderPositionLogo { get; set; }

    }
}
