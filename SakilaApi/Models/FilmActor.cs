using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SakilaApi.Models
{
    [Table("film_actor")]
    public class FilmActor
    {
        [Column("film_id")]
        public int FilmId { get; set; }
        public Film Film { get; set; }
        [Column("actor_id")]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
