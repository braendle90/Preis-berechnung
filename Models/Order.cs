using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PriceCalculation.Models
{
    public class Order
    {
        public int Id { get; set; }
        [DisplayName("Angebots Nummer")]
        public string OfferId { get; set; }

        [DisplayName("Stückzahl")]
        public int NumberOfPieces { get; set; }
        public bool isOrdered { get; set; }
        public Textil Textil { get; set; }
        public TextilColor TextilColor { get; set; }
    }
}
