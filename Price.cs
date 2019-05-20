using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace The_Pizzatorium.Models
{
    public class Price
    {
        [Key]
        public int OrderId { get; set; }

        public string Prices { get; set; }
    }
}