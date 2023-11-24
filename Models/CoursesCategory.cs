﻿using System.ComponentModel.DataAnnotations;

namespace AplikacjaMetodyki.Models
{
    public class CoursesCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryTitle { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
