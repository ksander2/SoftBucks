using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoftBucksBase.Models;
using SoftBucksBase.DAO;
using Softbucks.Models;
using Softbucks.Security;
using SoftBucksBase.BL;
using Microsoft.AspNet.Identity;


namespace Softbucks.Controllers
{
 
    public class HomeController : Controller
    {
        private UnitOfWork _UoW; //= new UnitOfWork();

        public HomeController()
        {
            _UoW = new UnitOfWork();
        }
        
        public ActionResult Index()
        {
            return View("Index",CreateMainViewModel());
        }

        private MainViewModel CreateMainViewModel()
        {

            string UserId = User.Identity.GetUserId();

            MainViewModel mvm = new MainViewModel();
            mvm.BeverageCollection = _UoW.BeverageDAO.getAll().ToList();
            mvm.CondimentCollection = _UoW.CondimentDAO.getAll().ToList();
            mvm.CountChecks = _UoW.CheckoutDAO.CalculateAllCostCheckoutsByUserId(UserId);
            mvm.CountBids = _UoW.BidDAO.GetAllByUserId(UserId).Count();
            return mvm;
        }
       
        [HttpPost]
        [ApplicationAuthorize]
        public ActionResult CreateCheckout(IEnumerable<int> ListIdComdiments, int bevId)
        {
            string UserId = User.Identity.GetUserId();

            SoftBucksBL Bl = new SoftBucksBL(_UoW);
            Bl.CreateCheckout(ListIdComdiments,bevId , UserId);

            int sumCost = _UoW.CheckoutDAO.CalculateAllCostCheckoutsByUserId(UserId);
            return Json(sumCost.ToString() + " р.");
        }

        [Authorize]
        public ActionResult MenuCheckouts()
        {
            string UserId = User.Identity.GetUserId();
            IEnumerable<Checkout> allChecks = _UoW.CheckoutDAO.GetAllByUserId(UserId);  
         
            return View(allChecks);
        }
        [Authorize]
        public ActionResult MenuBids()
        {
            string UserId = User.Identity.GetUserId();
            IEnumerable<Bid> allBids = _UoW.BidDAO.GetAllByUserId(UserId);

            return View("MenuBids",allBids);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateBid(string comment)
        {
            string UserId = User.Identity.GetUserId();
            var allChecks = _UoW.CheckoutDAO.GetAllByUserId(UserId);

            if (allChecks.Count() > 0)
            {
                SoftBucksBL Bl = new SoftBucksBL(_UoW);
                Bl.CreateBid(allChecks, UserId, comment);

              
                IEnumerable<Bid> allBids = _UoW.BidDAO.GetAllByUserId(UserId).ToList();
                return View("MenuBids", allBids);
            }
            else
            {
                ModelState.AddModelError("", "Выберете хоть одно кофе");
                return View("MenuCheckouts", allChecks);
            }
           
        }

      
        [Authorize]
        public ActionResult DeleteCheckout(int id)
        {
            string UserId = User.Identity.GetUserId();

            SoftBucksBL Bl = new SoftBucksBL(_UoW);
            Bl.DeleteCheckout(id);

            IEnumerable<Checkout> allChecks = _UoW.CheckoutDAO.GetAllByUserId(UserId); 

            return View("MenuCheckouts", allChecks);
        }
       
        [Authorize]
        public ActionResult DeleteBid(int id)
        {
            string UserId = User.Identity.GetUserId();

            SoftBucksBL Bl = new SoftBucksBL(_UoW);
            Bl.DeleteBid(id);

            IEnumerable<Bid> allBids = _UoW.BidDAO.GetAllByUserId(UserId);

            return View("MenuBids", allBids);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreatePayment(int? BidId)
        {
            Payment pay = new Payment();
            pay.BidId = BidId.Value;

            return PartialView("CreatePayment", pay);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreatePayment(Payment pay)
        {
            SoftBucksBL Bl = new SoftBucksBL(_UoW);
            Bl.CreatePayment(pay);
         
            string UserId = User.Identity.GetUserId();
            IEnumerable<Bid> allBids = _UoW.BidDAO.GetAllByUserId(UserId);
            return View("MenuBids", allBids);
        }
    }
}