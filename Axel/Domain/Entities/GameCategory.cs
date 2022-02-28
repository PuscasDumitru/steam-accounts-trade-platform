using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GameCategory
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int CategoryId { get; set; }

    }
}
