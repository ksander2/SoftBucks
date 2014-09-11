using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBucksBase.Models
{
    public class Additive: CondimentDecorator
    {
        public Additive(AbstractBeverage Coffee, Condiment CondimentBase)
        {
            _Coffee = Coffee;
            _CondBase = CondimentBase;
        }

        private AbstractBeverage _Coffee;
        private Condiment _CondBase;

    

        public override int Cost()
        {
            return _CondBase.Cost + _Coffee.Cost();
        }

        public override string GetDescription()
        {
            return  _Coffee.GetDescription()+" " +_CondBase.Name;
        }
    }
}
