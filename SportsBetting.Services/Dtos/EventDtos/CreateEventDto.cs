using System;
using System.ComponentModel.DataAnnotations;

namespace SportsBetting.Services.Dtos.EventDtos
{
    public class CreateEventDto
    {
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy HH:mm}")]
        public DateTime StartDate { get; set; }
    }
}
