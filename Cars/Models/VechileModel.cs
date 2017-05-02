using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cars.Models
{
    public class VechileModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Abrv { get; set; }
        
        public int MakeId { get; set; }
        [ForeignKey("MakeId")]
        public VechileMake VechileMake { get; set; }
        
    }
}