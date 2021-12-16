using Microsoft.EntityFrameworkCore;
using PriceCalculation.Data;
using PriceCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.Repository
{
    public class CalculationPiecesLogoandPosition : ICalculationPiecesLogoandPosition
    {

        public OneLogoAndPosition calc(int Logoid, int posId, ApplicationDbContext _context)
        {

            var logo = _context.Logos
           .Include(x => x.Color)
           .Where(x => x.Id == Logoid)
           .FirstOrDefault();

            var position = _context.Positions
                .Where(x => x.Id == posId)
                .FirstOrDefault();

            var positionLogosList = _context.PositionLogos
                .Include(x => x.OrderPositionLogo)
                .Include(x => x.OrderPositionLogo.Order)
                .Include(x => x.OrderPositionLogo.Order.Textil)
                .Include(x => x.OrderPositionLogo.Order.TextilColor)
                .Include(x => x.OrderPositionLogo.User)
                .Include(x => x.Logo)
                .Include(x => x.Logo.Color)
                .Include(x => x.Position)
                .Where(x => x.Logo == logo)
                .Where(x => x.Position == position)
                .ToList();

            var neuePosLogoListe = positionLogosList.Where(x => x.Position == position).ToList();
            var neuePosLogoListe2 = positionLogosList.Where(x => x.Position == position).ToList();


            /*int posId = 1; *///Diese id ist die ID für die Position z.B. Br.Links

            var orderListe = new List<Order>();



            foreach (var item in positionLogosList)
            {
                if (item.Position.Id == posId)
                {
                    orderListe.Add(item.OrderPositionLogo.Order);
                }
            }

            int StückZahlTexitlien = 0;
            foreach (var item in orderListe)
            {
                StückZahlTexitlien += item.NumberOfPieces;
            }

            var onedataset = new OneLogoAndPosition
            {
                Logo = logo,
                Position = position,
                Pieces = StückZahlTexitlien,
                PositionLogoList = positionLogosList
            };


            if (StückZahlTexitlien == 0)
            {
                return null;
            }

            return onedataset;

        }


        public decimal priceOfPrint(PositionLogo order, int piecesOfTextilPositions, ApplicationDbContext _context)
        {
             var OneLogoandPositionPrice = PricefromDb(order,piecesOfTextilPositions,_context);

            var price = order.OrderPositionLogo.Order.NumberOfPieces  * PricefromDb(order, piecesOfTextilPositions, _context); ;

            return price;

        }

        public decimal PricefromDb(PositionLogo order, int piecesOfTextilPositions, ApplicationDbContext _context)
        {

            var priceTable = _context.PriceTable
                .Include(x => x.Range)
                .Include(x => x.Texil)
                .Include(x => x.NumberColors)
                .Where(x => x.Range.RangeFrom <= piecesOfTextilPositions)
                .Where(x => x.Range.RangeTo >= piecesOfTextilPositions)
                .Where(x => x.Texil == order.OrderPositionLogo.Order.Textil)
                .Where(x => x.NumberColors == order.Logo.Color)
                .FirstOrDefault();

            decimal price = priceTable.Price;


            return price;
        }


    }






}
