using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laIdealShipping.Entities
{
    /// <summary>
    /// View Model For Shippings
    /// </summary>
    public class ShippingViewModel
    {
        [Key]
        public int VM_Id { get; set; }

        [Display(Name = "Next Departure")]
        public string VM_nextShippingDate { get; set; }
        [Display(Name = "Departure")]
        public bool VM_salida { get; set; }

        public ShippingStatus VM_Status { get; set; }
    }
}
