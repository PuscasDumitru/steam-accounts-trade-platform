using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public int SteamLevel { get; set; }
        public string SteamLink { get; set; }
        public int BansCount { get; set; }
        public double Price { get; set; }
        public int YearCreated { get; set; }
        public DateTime DateTimeAdded { get; set; }

        [NotMapped]
        public int AnnouncementId { get; set; }

        [ForeignKey("AccountId")]
        public virtual ICollection<AccountGame> AccountGames { get; set; }
    }
}
