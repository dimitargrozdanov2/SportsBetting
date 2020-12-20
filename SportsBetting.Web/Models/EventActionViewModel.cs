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

        [RegularExpression("^[^0-9]+$", ErrorMessage = "Name cannot contain numbers")]
        [Required, MinLength(10), MaxLength(150)]
        public string Name { get; set; }

        [Required, Range(1.01, 50)]
        public decimal OddsForFirstTeam { get; set; }

        [Required, Range(1.01, 50)]
        public decimal OddsForDraw { get; set; }

        [Required, Range(1.01, 50)]
        public decimal OddsForSecondTeam { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }
    }
}
