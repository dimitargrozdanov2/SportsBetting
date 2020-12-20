using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBetting.Data.Models
{
    public class Event : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double OddsForFirstTeam { get; set; }

        public double OddsForDraw { get; set; }

        public double OddsForSecondTeam { get; set; }

        public DateTime StartDate { get; set; }

    }
}
