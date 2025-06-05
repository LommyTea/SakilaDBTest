using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SakilaApi.Models;

namespace SakilaApi.Models
{
    public class Film
    {
        [Column("film_id")]
        public int FilmId { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        [Column("release_year")]
        public int? ReleaseYear { get; set; }
        [Column("language_id")]
        public int LanguageId { get; set; }
        [Column("original_language_id")]
        public int? OriginalLanguageId { get; set; }
        [Column("rental_duration")]
        public int RentalDuration { get; set; }
        public int? Length { get; set; }
        [Column("replacement_cost")]
        public decimal ReplacementCost { get; set; }

        public string? Rating { get; set; }
        [Column("special_features")]
        public string? SpecialFeatures { get; set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; set; }

        public List<FilmActor> FilmActors { get; set; } = new();

        public Language Language { get; set; }


    }
}
