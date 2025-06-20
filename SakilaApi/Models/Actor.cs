using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SakilaApi.Models;
namespace SakilaApi.Models
{
    [Table("actor")]
    public class Actor
    {
        [Key]
        [Column("actor_id")]
        public int ActorId { get; set; }

        [Column("first_name")]
        public string? FirstName { get; set; }

        [Column("last_name")]
        public string? LastName { get; set; }

        [Column("last_update")]
        public DateTime LastUpdate { get; set; }

        public List<FilmActor> FilmActors { get; set; } = new();
    }
}
