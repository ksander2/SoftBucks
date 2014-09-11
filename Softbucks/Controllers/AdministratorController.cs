using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoftBucksBase.Models;
using SoftBucksBase.DAO;
using Microsoft.AspNet.Identity;



namespace Softbucks.Controllers
{
    public class AdministratorController : Controller
    {
        private UnitOfWork _UoW = new UnitOfWork();
        
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();    
        }

        public ActionResult GetDataBeverage ()
        {     
            IEnumerable<Beverage> bev = _UoW.BeverageDAO.getAll().ToList();
            return Json(bev, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataCondiment()
        {
            IEnumerable<Condiment> Condiments = _UoW.CondimentDAO.getAll().ToList();
            return Json(Condiments, JsonRequestBehavior.AllowGet);
        }

        #region CRUDBeverage
        [HttpPost]
        public void CreateBeverage(Beverage bev)
        {
            bev.Id = _UoW.BeverageDAO.GetNextId();
            _UoW.BeverageDAO.create(bev);
            _UoW.Commit();     
        }

        [HttpPost]
        public void DeleteBeverage(int id)
        {
            Beverage tempBev = _UoW.BeverageDAO.FindById(id);
            _UoW.BeverageDAO.delete(tempBev);
            _UoW.Commit();
        }

        [HttpPost]
        public void EditBeverage(Beverage bev)
        {
            _UoW.BeverageDAO.update(bev);
            _UoW.Commit();
        }
        #endregion

        #region CRUDCondiment
        [HttpPost]
        public void CreateCondiment(Condiment condiment)
        {
            condiment.Id = _UoW.CondimentDAO.GetNextId();
            _UoW.CondimentDAO.create(condiment);
            _UoW.Commit();
        }

        [HttpPost]
        public void DeleteCondiment(int id)
        {
            Condiment tempCondiment = _UoW.CondimentDAO.FindById(id);
            _UoW.CondimentDAO.delete(tempCondiment);
            _UoW.Commit();
        }

        [HttpPost]
        public void EditCondiment(Condiment condiment)
        {
            _UoW.CondimentDAO.update(condiment);
            _UoW.Commit();
        }
        #endregion
        protected override void Dispose(bool disposing)
        {
            _UoW.Dispose();
            base.Dispose(disposing);
        }
    }
}