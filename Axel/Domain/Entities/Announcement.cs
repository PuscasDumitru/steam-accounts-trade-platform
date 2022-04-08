using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string HtmlContent { get; set; }
        public Account Account { get; set; }

        [NotMapped]
        public int AccId { get; set; }

        [ForeignKey("AnnouncementId")]
        public ICollection<Screenshot> Screenshots { get; set; }

    }
}
