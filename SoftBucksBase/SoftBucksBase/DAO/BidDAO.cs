using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftBucksBase.Models;
using System.Data.Entity;



namespace SoftBucksBase.DAO
{
   public class BidDAO : AbstractDAO<Bid>
    {

        public BidDAO(SoftBucksContext context)
            : base(context)
        {
            _context = context;
        }

        public Bid FindById(int id)
        {

            return _context.Bids.FirstOrDefault(c => c.Id == id);
        }
        
        public IEnumerable<Bid> GetAllByUserId(string UserId)
        {
            return _context.Bids.Where(x => x.UserId == UserId).Include(x =>x.StatusBid);
        }
           

        protected override void updateItem(Bid item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        protected override void creatItem(Bid item)
        {
            _context.Bids.Add(item);
        }

        protected override void deleteItem(Bid item)
        {
            _context.Bids.Remove(item);
        }

        public int GetNextId()
        {
            if (_context.Bids.Count() != 0)
            {
                return _context.Bids.Max<Bid>(x => x.Id) + 1;
            }
            else return 0;
        }
    }
}
