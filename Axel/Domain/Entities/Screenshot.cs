using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Screenshot
    {
        public int Id { get; set; }
        public int AnnouncementId { get; set; }

        [Required]
        public byte[] ScreenShot { get; set; }
    }
}
