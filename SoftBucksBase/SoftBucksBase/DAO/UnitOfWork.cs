using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftBucksBase.Models;

namespace SoftBucksBase.DAO
{
    public class UnitOfWork
    {
        private SoftBucksContext _context = new SoftBucksContext();

        private BeverageDAO _BeverageDAO;
        private CondimentDAO _CondimentDAO;
        private CheckoutDAO _CheckoutDAO;
        private BidDAO _BidDAO;
        private PaymentDAO _PaymentDAO;

        public UnitOfWork()
        {
            _BeverageDAO = new BeverageDAO(_context);
            _CondimentDAO = new CondimentDAO(_context);
            _CheckoutDAO = new CheckoutDAO(_context);
            _BidDAO = new BidDAO(_context);
            _PaymentDAO = new PaymentDAO(_context);
        }

        public BeverageDAO BeverageDAO
        {
            get { return _BeverageDAO; }
        }

        public CondimentDAO CondimentDAO
        {
            get { return _CondimentDAO; }
        }

        public CheckoutDAO CheckoutDAO
        {
            get { return _CheckoutDAO; }
        }

        public BidDAO BidDAO
        {
            get { return _BidDAO; }
        }

        public PaymentDAO PaymentDAO
        {
            get { return _PaymentDAO; }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
