using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftBucksBase.Models;
using System.Data.Entity;

namespace SoftBucksBase.DAO
{
    public class CondimentDAO : AbstractDAO<Condiment>
    {
        public CondimentDAO(SoftBucksContext context) : base(context)
        {
            _context = context;
        }
       
        public Condiment FindById(int id)
        {
            return _context.Condiments.FirstOrDefault(c => c.Id == id);
        }

        protected override void updateItem(Condiment item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        protected override void creatItem(Condiment item)
        {
            _context.Condiments.Add(item);
        }

        protected override void deleteItem(Condiment item)
        {
            _context.Condiments.Remove(item);
        }

        public int GetNextId()
        {
            if (_context.Condiments.Count() != 0)
            {
                return _context.Condiments.Max<Condiment>(x => x.Id) + 1;
            }
            else return 0;
        }
    }
}
