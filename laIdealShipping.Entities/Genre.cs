using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laIdealShipping.Entities
{
    /// <summary>
    /// When you work with enum you do not get some sort of lookup table that contains ID and Description, there are some pros and cons
    /// the PROS ONE less JOIN to do when I need book information, the CONS is that I WILL not have a table in the database that says enum value 4 has a Description
    /// of "Science Fiction", instead will have to do inside the application.
    /// </summary>
    public enum Genre
    {
        [Display(Name="Non Fiction")]
        NonFiction,
        Romance,
        Action,
        [Display(Name="Science Fiction")]
        ScienceFiction
    }
}
