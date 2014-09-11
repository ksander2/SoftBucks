using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBucksBase.Models
{
    public abstract class CondimentDecorator : AbstractBeverage
    {
        public CondimentDecorator()
        { }

        public abstract override string GetDescription();
    }
}
