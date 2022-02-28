using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [ForeignKey("GameId")]
        public virtual ICollection<GameCategory> GameCategories { get; set; }

        [ForeignKey("GameId")]
        public virtual ICollection<AccountGame> AccountGames { get; set; }
    }
}
