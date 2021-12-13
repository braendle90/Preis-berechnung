using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.Models
{
    public class TextilColor
    {

        public int Id { get; set; }
        [DisplayName("Textil Farbe")]
        public string TextilColorName { get; set; }
    }
}
