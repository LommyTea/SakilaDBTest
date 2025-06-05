using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SakilaApi.Models;
using System.Text.Json.Serialization;

public class Language
{
    [Column("language_id")]
    public int LanguageId { get; set; }

    [Column("name")]
    public string Name { get; set; }

    // Navigation property
    [JsonIgnore]
    public ICollection<Film> Films { get; set; }

}
