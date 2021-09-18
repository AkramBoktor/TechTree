using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechTreeMVCWebApplication.Entities
{
    public class CategoryItem
    {
        private DateTime _releaseDate = DateTime.MinValue;
        public int Id { get; set; }

        [Required]
        [StringLength(200,MinimumLength =2)]
        public string Title { get; set; }

        public string Description { get; set; }
       
        public int CategoryId { get; set; }
        
        public int MediaTypeId { get; set; }

        //Make list to admin and not mapped to Our database
        [NotMapped]
        public virtual ICollection<SelectListItem> MediaTypes { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime DateTimeItemReleased {
            get {

                return (  _releaseDate == DateTime.MinValue ) ? DateTime.Now : _releaseDate;
                    
                 } 
            set 
            {
                _releaseDate = value;
            } 
        }

        //one to one releationship between content and category item
        [NotMapped]
        public int contentId { get; set; }
    }
}
