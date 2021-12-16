using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PriceCalculation.Data;
using PriceCalculation.Models;
using PriceCalculation.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.Controllers
{
    public class HomeController : Controller
    {


        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateOffer()
        {
            string guid = Guid.NewGuid().ToString();
            var textilList = _context.Textils.ToList();
            var positionList = _context.Positions.ToList();
            var colorList = _context.Colors.ToList();
            var model = new CreateNewOfferViewModel
            {
                TextilList = textilList,
                PositionList = positionList,
                ColorList = colorList,
                OfferId = guid.ToString(),
                
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOffer([Bind("NumberOfPieces,TextilColorId,TextilId,PositionId,ColorId,LogoName,LogoSurfaceSize, OfferId")] CreateNewOfferViewModel model)
        {

            Textil textil = _context.Textils.Find(model.TextilId);
            Position position = _context.Positions.Find(model.PositionId);
            Color color = _context.Colors.Find(model.ColorId);
            TextilColor textilColor = _context.TextilColors.Find(model.TextilColorId);

            Order order = new Order
            {
                NumberOfPieces = model.NumberOfPieces,
                OfferId = model.OfferId,
                Textil = textil,
                TextilColor = textilColor
            };
            _context.Add(order);
            _context.SaveChanges();

            var user = await _userManager.GetUserAsync(User);

            OrderPositionLogo opl = new OrderPositionLogo
            {
                User = user,
                Order = order,
            };
            _context.Add(opl);
            _context.SaveChanges();
            Logo logo = new Logo
            {
                LogoName = model.LogoName,
                LogoSurfaceSize =model.LogoSurfaceSize,
                Color = color
            };
            _context.Add(logo);
            _context.SaveChanges();
            PositionLogo pl = new PositionLogo
            {
                Position = position,
                Logo = logo,
                OrderPositionLogo = opl
            };
            _context.Add(pl);
            _context.SaveChanges();

            return View(nameof(Index));
        }

        public async Task<IActionResult> OverView()
        {
            var user = await _userManager.GetUserAsync(User);

            var liste = _context.OrderPositionLogos
                .Include(x => x.Order)
                .Include(x => x.User)
                .Include(x => x.Order.Textil)
                .Include(x => x.Order.TextilColor)
                .Where(x => x.User == user)
                .AsEnumerable()
                .GroupBy(x => x.Order.OfferId)
                .Select(grp => new ShowTableVieModel
                {
                    OfferId = grp.Key, OrderPostionLogoListe = grp.ToList()
                })
                .ToList();

            var test = new List<OrderPositionLogo>();


            var nodupes = liste.Distinct().ToList();
            //IEnumerable<IGrouping<string, TestViewModel>> ganzneueList = liste;

            //var groupedlist = liste
            //    .AsEnumerable()
            //    .GroupBy(x => x.Order.OfferId)
            //    .Select(x => x)
            //    .ToList();


            return View(liste);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> testOp(string Offerid)
        {


            var user = await _userManager.GetUserAsync(User);

            var oplListe = await _context.OrderPositionLogos
                .Include(x => x.User)
                .Include(x => x.Order)
                .Where(x=> x.Order.OfferId == Offerid)
                .ToListAsync();

            foreach (var item in oplListe)
            {
               var TextilName =  item.Order.Textil.TextilName;
                var pl = _context.PositionLogos
                     .Include(x => x.Position)
                     .Include(x => x.Logo)
                     .Include(x => x.OrderPositionLogo)
                     .Where(x => x.OrderPositionLogo.Order.OfferId == Offerid)
                     .ToList();

                foreach (var entry in pl)
                {
                    var colorName = entry.Logo.Color.ColorName;
                    var posName = entry.Position.PositionName;
                    var logoName = entry.Logo.LogoName;
                }
            }




            return View("index");
        }
    }
}
