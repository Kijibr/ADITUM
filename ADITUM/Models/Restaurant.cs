using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADITUM.Models
{
    public class Restaurant
    {
        [Display(Name = "Restaurante: ")]
        public string RestaurantName { get; set; }
        
        [Display(Name = "Horário: ")]
        public string OpenHours { get; set; }
    }
}
