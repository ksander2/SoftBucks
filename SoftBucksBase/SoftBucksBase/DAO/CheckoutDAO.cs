using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftBucksBase.Models;
using System.Data.Entity;

namespace SoftBucksBase.DAO
{
    public class CheckoutDAO : AbstractDAO<Checkout>
    {

        public CheckoutDAO(SoftBucksContext context)
            : base(context)
        {
            _context = context;
        }
       
        public Checkout FindById(int id)
        {

            return _context.Checkouts.FirstOrDefault(c => c.Id == id);
        }

        public int CountByUserId(string UserId)
        {

            return _context.Checkouts.Where(x => x.IsActive==true && x.UserId ==UserId).Count();
        }

        public IEnumerable<Checkout> GetAllByUserId(string UserId)
        {
            return _context.Checkouts.Where(x => x.IsActive == true && x.UserId == UserId);
        }

        public int CalculateAllCostCheckoutsByUserId(string UserId)
        {
       
            int sumCost = 0;
            var allChecks =  _context.Checkouts.Where(x => x.IsActive == true && x.UserId == UserId).ToList();
            foreach (Checkout item in allChecks)
            {
                sumCost += item.AllCost;

            }
            return sumCost;
        }

        protected override void updateItem(Checkout item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        protected override void creatItem(Checkout item)
        {
            _context.Checkouts.Add(item);
        }

        protected override void deleteItem(Checkout item)
        {
            _context.Checkouts.Remove(item);
        }

        public int GetNextId()
        {
            if (_context.Checkouts.Count() != 0)
            {
                return _context.Checkouts.Max<Checkout>(x => x.Id) + 1;
            }
            else return 0;
        }
    }
}
