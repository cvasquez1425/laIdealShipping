using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laIdealShipping.Entities
{
    public class Contact
    {
        public int contactId    { get; set; }

        [Display(Name="First Name")]
        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string firstName { get; set; }

        [Display(Name="Last Name")]
        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        public string lastName  { get; set; }

        [Display(Name="Phone")]
        [DataType(DataType.PhoneNumber)]
        public string phone        { get; set; }

        [Display(Name="E-mail")]
        [DataType(DataType.EmailAddress)]
        public string email     { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(500)]        
        [Display(Name="Comments")]
        public string comments  { get; set; }

        [Display(Name="Yes, email me updates")]
        public bool emailMeUpdate { get; set; }
    }
}
