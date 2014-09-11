using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBucksBase.Models
{
    public abstract class AbstractBeverage
    {
    

        public virtual string GetDescription()
        {
            return "Unknown Beverage";
        }

        public abstract int Cost();
    }
}
