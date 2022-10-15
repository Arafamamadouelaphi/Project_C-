using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BowlingEF.Entities
{
    /// <summary>
    /// Classe de gestion des Joueurs
    /// </summary>
    public class JoueurEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Pseudo { get; set; }
    }
}