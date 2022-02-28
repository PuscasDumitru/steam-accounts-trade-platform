using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category
    {
        public int Id { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ICollection<GameCategory> GameCategories { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

    }
}
