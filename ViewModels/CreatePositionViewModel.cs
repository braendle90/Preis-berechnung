using PriceCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.ViewModels
{
    public class CreatePositionViewModel
    {

        public int Id { get; set; }
        public int PositionId { get; set; }
        public int LogoId { get; set; }
        public int OrderID { get; set; }
        public List<Position> PositionList { get; set; }
        public List<Logo> LogoList { get; set; }
        public List<OrderPositionLogo> Opl { get; set; }

    }
}
