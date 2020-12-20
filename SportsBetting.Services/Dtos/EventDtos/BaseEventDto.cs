using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SportsBetting.Services.Dtos.EventDtos
{
    public class BaseEventDto
    {
        public string Name { get; set; }

        public decimal OddsForFirstTeam { get; set; }

        public decimal OddsForDraw { get; set; }

        public decimal OddsForSecondTeam { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }
    }
}
