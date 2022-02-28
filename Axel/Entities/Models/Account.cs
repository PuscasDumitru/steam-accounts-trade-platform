using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Account
    {
        [NotMapped]
        const int STEAM_RELEASE_YEAR = 2003;
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Steam level cannot be less than 0")]
        public int SteamLevel { get; set; }
        
        [Required]
        [StringLength(150, ErrorMessage = "This link is too long")]
        public string SteamLink { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Account's bans count cannot be less than 0")]
        public int BansCount { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be less than 0")]
        public double Price { get; set; }

        [Required]
        [Range(STEAM_RELEASE_YEAR, int.MaxValue, ErrorMessage = "That's impossible, steam was released in 2003")]
        public int YearCreated { get; set; }

        [Required]
        public DateTime DateTimeAdded { get; set; }

        [ForeignKey("AccountId")]
        public virtual ICollection<AccountGame> AccountGames { get; set; }
    }
}
