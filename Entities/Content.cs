using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        //one to one releationship between content and category item
        [NotMapped]
        public int CatItemId { get; set; }

        //one to many releationship between category and categry item
        [NotMapped]
        public int CategoryId { get; set; }
    }
}
