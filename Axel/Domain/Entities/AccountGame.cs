using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AccountGame
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int GameId { get; set; }

        [Range(0, int.MaxValue)]
        public int HoursPlayed { get; set; } 
    }
}
