using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftBucksBase.Models;
using System.Data.Entity;

namespace SoftBucksBase.DAO
{
    public class PaymentDAO : AbstractDAO<Payment>
    {
          public PaymentDAO(SoftBucksContext context) : base(context)
        {
            _context = context;
        }

        public Payment FindById(int id)
        {
            return _context.Payments.FirstOrDefault(c => c.Id == id);
        }

        protected override void updateItem(Payment item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        protected override void creatItem(Payment item)
        {
            _context.Payments.Add(item);
        }

        protected override void deleteItem(Payment item)
        {
            _context.Payments.Remove(item);
        }

        public int GetNextId()
        {
            if (_context.Payments.Count() != 0)
            {
                return _context.Payments.Max<Payment>(x => x.Id) + 1;
            }
            else return 0;
        }

    }
}
