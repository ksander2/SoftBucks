using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBucksBase.Models
{
    public class Coffee: AbstractBeverage
    {
        public Coffee(Beverage Beverage)
        {
            _BevBase = Beverage;
        }
        private Beverage _BevBase;
  
        public override int Cost()
        {
            return _BevBase.Cost;
        }

        public override string GetDescription()
        {
            return _BevBase.Name;
        }
    }
}
