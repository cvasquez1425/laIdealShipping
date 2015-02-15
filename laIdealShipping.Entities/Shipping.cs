using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laIdealShipping.Entities
{
    /// <summary>
    /// I'll write some classes that represent the entities that I want to store in the database, and the EF will make that happen. Code First no design surface, just C# code
    /// </summary>
    public class Shipping
    {
        public int Id { get; set; }

        [Display(Name = "Next Departure")]
        [DataType(DataType.Date)]
        public DateTime nextShippingDate { get; set; }
        [Display(Name="Departure")]
        public bool salida { get; set; }

        public ShippingStatus Status { get; set; }
    }
}
