using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SportsBetting.Services.Dtos.EventDtos
{
    public class BaseEventDto
    {
        public string Name { get; set; }

        public double OddsForFirstTeam { get; set; }

        public double OddsForDraw { get; set; }

        public double OddsForSecondTeam { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MM yyyy HH:mm}")]
        public DateTime StartDate { get; set; }
    }
}
