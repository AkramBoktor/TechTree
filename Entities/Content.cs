using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTreeMVCWebApplication.Entities
{
    public class Content
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        public string HtmlContent { get; set; }
        public string VideoLink { get; set; }

        public CategoryItem CategoryItem { get; set; }

    }
}
