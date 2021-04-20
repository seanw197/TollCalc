using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TollCalc.Models
{

    public class Vehicle 
    {
        public string Type { get; set; }
        public bool HasTag { get; set; }

        public double Toll { get; set; }
        public IEnumerable<SelectListItem> VeList { get; set; }
    }
   
}
