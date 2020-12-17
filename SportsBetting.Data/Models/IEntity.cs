using System.ComponentModel.DataAnnotations;

namespace SportsBetting.Data.Models
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}
