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

        public string Name { get; set; }

        public decimal OddsForFirstTeam { get; set; }

        public decimal OddsForDraw { get; set; }

        public decimal OddsForSecondTeam { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }
    }
}
