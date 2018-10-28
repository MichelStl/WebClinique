using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinique2000.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Required, StringLength(20, MinimumLength = 4)]
        [DisplayName("Articles")]
        public string Title { get; set; }

        [Required, StringLength(60, MinimumLength = 6)]
        [DisplayName("Aperçus")]
        public string OverView { get; set; }
        public string Content { get; set; }
        [DisplayName("Date de sortie")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string ImgFilePath { get; set; }

    }
}
