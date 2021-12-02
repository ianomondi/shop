using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Onlineshop.Models
{
    public class ProductTypes
    {
        public int Id { get; set; }

        [Display(Name ="Product Type")]
        public string ProductType { get; set; }
    }
}
