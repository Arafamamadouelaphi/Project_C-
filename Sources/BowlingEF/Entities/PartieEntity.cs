using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingEF.Entities
{
    /// <summary>
    /// Classe de gestion des parties
    /// </summary>
    public class PartieEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public JoueurEntity Joueur { get; set; }

        [ForeignKey("JoueurId")]
        [Required]
        public long JoueurId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public ICollection<FrameEntity> Frames { get; set; }
        [Required]
        public int? Score { get; set; }
        
        public PartieEntity()
        {
            Frames = new List<FrameEntity>();
        }
    }
}
