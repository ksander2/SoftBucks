using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftBucksBase.DAO;
using SoftBucksBase.Models;

namespace SoftBucksBase.BL
{
    public class SoftBucksBL
    {
        private UnitOfWork _UoW;

        public SoftBucksBL(UnitOfWork uow)
        {
            _UoW = uow;
        }

        public void CreatePayment(Payment pay)
        {
            Bid tempBid = _UoW.BidDAO.FindById(pay.BidId);
            pay.Id = _UoW.PaymentDAO.GetNextId();

            if (pay.Value >= tempBid.Cost)
            {
                pay.Date = DateTime.Now;
                _UoW.PaymentDAO.create(pay);
                tempBid.StatusId = 1;

                _UoW.BidDAO.update(tempBid);
                _UoW.Commit();
            }
        }

        public void DeleteBid(int id)
        {
            _UoW.BidDAO.delete(_UoW.BidDAO.FindById(id));
            _UoW.Commit();
        }

        public void DeleteCheckout(int id)
        {
            _UoW.CheckoutDAO.delete(_UoW.CheckoutDAO.FindById(id));
            _UoW.Commit();
        }

        public void CreateBid(IEnumerable<Checkout> allChecks, string UserId, string comment)
        {
            Bid bid = new Bid();
            int sum = 0;
            foreach (Checkout item in allChecks)
            {
                sum += item.AllCost;
                item.IsActive = false;
            }

            bid.Cost = sum;
            bid.Date = DateTime.Now;
            bid.Id = _UoW.BidDAO.GetNextId();
            bid.UserId = UserId;
            bid.Comment = comment;
            bid.StatusId = 0;
           
            _UoW.BidDAO.create(bid);
            _UoW.Commit();
        }

        public void CreateCheckout(IEnumerable<int> ListIdComdiments, int bevId, string UserId)
        {
            Beverage bev = _UoW.BeverageDAO.FindById(bevId);
            List<Condiment> CondList = new List<Condiment>();
           
            // Использую шаблон проектирования "Декоратор"
            AbstractBeverage tempCofee = new Coffee(bev);

            if (ListIdComdiments != null)
            {
                foreach (int i in ListIdComdiments)
                {
                    Condiment con = _UoW.CondimentDAO.FindById(i);

                    tempCofee = new Additive(tempCofee, con);
                }
            }

            int sumCost = tempCofee.Cost();

            Checkout check = new Checkout();
            check.Description = tempCofee.GetDescription();
            check.AllCost = tempCofee.Cost();
            check.IsActive = true;
            check.Id = _UoW.CheckoutDAO.GetNextId();
            check.UserId = UserId;


            _UoW.CheckoutDAO.create(check);
            _UoW.Commit();
        }
    }
}