using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Screenshot
    {
        public int Id { get; set; }
        public int ContentId { get; set; }

        [Required]
        public byte[] ScreenShot { get; set; }
    }
}
