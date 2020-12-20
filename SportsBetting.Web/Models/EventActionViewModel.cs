using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsBetting.Web.Models
{
    public class EventActionViewModel
    {
        public int Id { get; set; }

        [RegularExpression("^[A-Za-z]+[ -:][A-Za-z]+$", ErrorMessage = "Name cannot contain only one space or dash")]
        
        [Required, MinLength(10), MaxLength(150)]
        public string Name { get; set; }

        [Required, Range(1, 50)]
        public double OddsForFirstTeam { get; set; }

        [Required, Range(1, 50)]
        public double OddsForDraw { get; set; }

        [Required, Range(1, 50)]
        public double OddsForSecondTeam { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }
    }
}
