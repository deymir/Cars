using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars.Models
{
    public class VechileMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual List<VechileModel> Models { get; set; }
    }
}