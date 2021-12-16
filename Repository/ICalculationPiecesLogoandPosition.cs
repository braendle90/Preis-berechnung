using PriceCalculation.Data;
using PriceCalculation.Models;

namespace PriceCalculation.Repository
{
    public interface ICalculationPiecesLogoandPosition
    {
        OneLogoAndPosition calc(int Logoid, int posId, ApplicationDbContext _context);
        decimal PricefromDb(PositionLogo order, int piecesOfTextilPositions, ApplicationDbContext _context);
        decimal priceOfPrint(PositionLogo order, int piecesOfTextilPositions, ApplicationDbContext _context);
    }
}