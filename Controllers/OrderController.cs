using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PriceCalculation.Data;
using PriceCalculation.Models;
using PriceCalculation.Repository;
using PriceCalculation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICalculationPiecesLogoandPosition _calcRepo;

        public OrderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ICalculationPiecesLogoandPosition calcRepo)
        {
            this._context = context;
            this._userManager = userManager;
            this._calcRepo = calcRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {

            string guid = Guid.NewGuid().ToString();

            var textilcolor = _context.TextilColors.ToList();
            var textilList = _context.Textils.ToList();

            //OrderPositionLogo opl = new OrderPositionLogo(); //wird nciht gebraucht

            OrderViewModel orderViewModel = new OrderViewModel
            {
                TextilColorList = textilcolor,
                TextilList = textilList,
                OfferId = guid
            };

            return View("CreateOrderList", orderViewModel);
        }

        [HttpPost]
        //public IActionResult CreateOrder([Bind("NumberOfPieces,TextilId,TextilColorId, OfferId")] OrderViewModel model)
        public async Task<IActionResult> CreateOrder([FromBody] List<OrderViewModel> modelList)
        {
            string OfferId = modelList[0].OfferId;

            string redirectOfferId = "/?guid=" + OfferId;


            var oplList = new List<OrderPositionLogo>();

            foreach (var model in modelList)
            {


                var user = await _userManager.GetUserAsync(User);

                Textil textil = _context.Textils.Find(model.TextilId);
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

                OrderPositionLogo opl = new OrderPositionLogo
                {
                    Order = order,
                    User = user
                };

                oplList.Add(opl);


            }
            _context.AddRange(oplList);
            _context.SaveChanges();


            return Json(new { redirectToUrl = Url.Action("ShowLogo", "Order"), guid = redirectOfferId });



        }

        [HttpGet]
        public IActionResult ShowLogo(string guid)
        {

            var db = _context.Colors.ToList();

            var model = new CreateLogoViewModel
            {
                OfferId = guid,
                ColorList = db,
            };

            return View("ShowLogoList", model);
        }

        [HttpPost]
        public IActionResult CreateLogo([Bind("OfferId,LogoName,LogoSurfaceSize,ColorId")] List<CreateLogoViewModel> modelList)
        //public IActionResult CreateLogo([FromBody] List<CreateLogoViewModel> modelList)
        {
            var logoList = new List<Logo>();
            var positionList = _context.Positions.ToList();

            string OfferId = modelList[0].OfferId;

            var opl = _context.OrderPositionLogos
                .Include(x => x.Order)
                .Include(t => t.Order.Textil)
                .Include(t => t.Order.TextilColor)
                .Where(x => x.Order.OfferId == OfferId)
                .ToList();



            foreach (var model in modelList)
            {


                Color color = _context.Colors.Find(model.ColorId);



                Logo logo = new Logo
                {
                    LogoName = model.LogoName,
                    LogoSurfaceSize = model.LogoSurfaceSize,
                    Color = color
                };
                _context.Add(logo);
                _context.SaveChanges();


                logoList.Add(logo);

            }

            var cpvm = new CreatePositionViewModel
            {
                LogoList = logoList,
                Opl = opl,
                PositionList = positionList

            };




            var listezumversenden = new List<GetLogoPositionOPLViewModel>();
            int count = 0;
            foreach (var item in opl)
            {
                var glpoplvm = new GetLogoPositionOPLViewModel
                {
                    OrderId = item.Order.Id,
                    PositionList = positionList,
                    LogoList = logoList,
                    TextilName = item.Order.Textil.TextilName,
                };
                count++;
                listezumversenden.Add(glpoplvm);
            }




            return View("PositionViewList", listezumversenden);

            //return Json(new { redirectToUrl = Url.Action("PositionView", "Order"), guid = glpoplvm });
        }

        [HttpPost]
        public IActionResult PositionView([Bind("OrderId", "LogoList", "PositionList")] GetLogoPositionOPLViewModel model)
        {
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> PositionViewCreate([Bind("PositionId, LogoId, OrderId")] List<GetLogoPositionOPLViewModel> model)
        {

            var positionLogoList = new List<PositionLogo>();

            string OfferId = "";

            foreach (var item in model)
            {

                var pos = _context.Positions.Find(item.PositionId);
                var logo = _context.Logos.Find(item.LogoId);
                var order = _context.Orders.Find(item.OrderId);
                var orderposlogo = _context.OrderPositionLogos
                    .Include(t => t.Order.Textil)
                    .Include(t => t.Order.TextilColor)
                    .Where(x => x.Order.Id == order.Id)
                    .FirstOrDefault();

                PositionLogo positionLogo = new PositionLogo
                {
                    Logo = logo,
                    Position = pos,
                    OrderPositionLogo = orderposlogo
                };

                OfferId = order.OfferId;

                positionLogoList.Add(positionLogo);
            }

            await _context.AddRangeAsync(positionLogoList);
            await _context.SaveChangesAsync();



            return RedirectToAction("ShowTable", new { offerId = OfferId });
        }


        public async Task<IActionResult> ShowTable(string Offerid)
        {
            var user = await _userManager.GetUserAsync(User);

            var PositonLogoList = _context.PositionLogos
                .Include(x => x.Logo)
                .Include(x => x.Position)
                .Include(x => x.OrderPositionLogo).Include(x => x.OrderPositionLogo.Order)
                .Where(x => x.OrderPositionLogo.User == user)
                .Where(x => x.OrderPositionLogo.Order.OfferId == Offerid).ToList();

            var opl = _context.OrderPositionLogos
                .Include(x => x.Order)
                .Include(x => x.Order.Textil)
                .Include(x => x.Order.TextilColor)
                .Include(x => x.User)
                .Where(x => x.Order.OfferId == Offerid).ToList();
            

            // Preisberechnung

            var ListofLogosWithDupes = new List<int>();
            var ListofPositionsWithDupes = new List<int>();

            //Create Alist of all LogoId and PositionID
            foreach (var item in PositonLogoList)
            {
                ListofLogosWithDupes.Add(item.Logo.Id);
                ListofPositionsWithDupes.Add(item.Position.Id);
            }


            //Distinct that Logo and Positon List
            var ListofLogosDistinct = ListofLogosWithDupes.Distinct().ToList();
            var ListofPositionsDistinct = ListofPositionsWithDupes.Distinct().ToList();


            var oneLogoPositionPieces = new List<OneLogoAndPosition>();

            foreach (var logoid in ListofLogosDistinct)
            {
                foreach (var positionId in ListofPositionsDistinct)
                {
                    var notNullReturnModel = _calcRepo.calc(logoid, positionId,_context);

                    if (notNullReturnModel != null)
                    {
                        oneLogoPositionPieces.Add(notNullReturnModel);
                    }
                }

            }

           



            var list = new List<TestViewModel>();

            foreach (var item in opl)
            {

                var listPositionLogo = new List<ShowPriceModel>();
                var listOfPositionLogoViews = new TestViewModel();

                foreach (var data in PositonLogoList)
                {


                     var fillModel = oneLogoPositionPieces
                        .Where(x => x.Logo == data.Logo )
                        .Where(x => x.Position == data.Position)
                        .FirstOrDefault();

                    var showPriceModel = new ShowPriceModel
                    {
                        Logo = data.Logo,
                        Position = data.Position,
                        OrderPositionLogo = data.OrderPositionLogo,
                        PiecesofTextilWithThisLogo = fillModel.Pieces,
                        PricePerPices = _calcRepo.priceOfPrint(data, fillModel.Pieces,_context),

                    };

               

                    if (item.Id == data.OrderPositionLogo.Id)
                    {
                        listPositionLogo.Add(showPriceModel);
                        listOfPositionLogoViews.OrderPositionLogo = item;
                        listOfPositionLogoViews.ShowPriceModel = listPositionLogo;
                    }

                }
                list.Add(listOfPositionLogoViews);
            }



            return View("ShowTableTeetView",list);
        }


    }
}
