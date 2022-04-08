using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects
{
    public class AnnouncementDto
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
