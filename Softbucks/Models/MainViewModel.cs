using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftBucksBase.Models;
using SoftBucksBase.DAO;

namespace Softbucks.Models
{
    public class MainViewModel
    {
        public IEnumerable<Beverage> BeverageCollection {get; set; }

        public IEnumerable<Condiment> CondimentCollection { get; set; }

        public int CountChecks { get; set; }

        public int CountBids { get; set; }
    }
}