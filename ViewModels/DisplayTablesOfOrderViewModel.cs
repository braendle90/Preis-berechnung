using PriceCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.ViewModels
{
    public class DisplayTablesOfOrderViewModel
    {
        public int Id { get; set; }

        public List<ListOfPositionLogoViewModel> ListOfPositionLogoViews { get; set; }


    }
}
