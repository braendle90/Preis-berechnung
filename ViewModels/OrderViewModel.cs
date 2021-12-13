using PriceCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string OfferId { get; set; }

        public int NumberOfPieces { get; set; }

        public int TextilColorId { get; set; }
        public List<TextilColor> TextilColorList { get; set; }
        public int TextilId { get; set; }
        
        public List<Textil> TextilList { get; set; }


    }
}
