using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftBucksBase.Models;
using System.Data.Entity;

namespace SoftBucksBase.DAO
{
    public class BeverageDAO: AbstractDAO<Beverage>
    {
        public BeverageDAO(SoftBucksContext context): base(context)
        {
            _context = context;
        }
       
        public Beverage FindById(int id)
        {

            return _context.Beverages.FirstOrDefault(c => c.Id == id);
        }

        protected override void updateItem(Beverage item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        protected override void creatItem(Beverage item)
        {
            _context.Beverages.Add(item);
        }

        protected override void deleteItem(Beverage item)
        {
            _context.Beverages.Remove(item);
        }

        public int GetNextId()
        {
            if (_context.Beverages.Count() != 0)
            {
                return _context.Beverages.Max<Beverage>(x => x.Id) + 1;
            }
            else return 0;
        }
    }
}
