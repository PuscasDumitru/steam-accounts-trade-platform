using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Account Account { get; set; }

        [ForeignKey("ContentId")]
        public ICollection<Screenshot> Screenshots { get; set; }

    }
}
