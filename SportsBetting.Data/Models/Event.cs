using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBetting.Data.Models
{
    public class Event : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal OddsForFirstTeam { get; set; }

        public decimal OddsForDraw { get; set; }

        public decimal OddsForSecondTeam { get; set; }

        public DateTime StartDate { get; set; }

    }
}
