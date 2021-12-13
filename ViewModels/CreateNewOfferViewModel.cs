using PriceCalculation.Models;
using System.Collections.Generic;

namespace PriceCalculation.ViewModels
{
    public class CreateNewOfferViewModel
    {
        public int Id { get; set; }
        public string OfferId { get; set; }
        public int NumberOfPieces { get; set; }
        public int TextilId { get; set; }
        public string TextilName { get; set; }
        public List<Textil> TextilList { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public List<Position> PositionList { get; set; }
        public int ColorId { get; set; }

        public int TextilColorId { get; set; }
        public string ColorName { get; set; }
        public List<Color> ColorList { get; set; }
        public string LogoName { get; set; }
        public double LogoSurfaceSize { get; set; }
        

    }
}
