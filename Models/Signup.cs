using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacjaMetodyki.Models
{
    public class Signup
    {
        [Key]
        public int SignupId { get; set; }

        [Required]
        public int CourseDateId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime ActiveFrom { get; set; }

        [Required]
        public DateTime ExpiresIn { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public CourseDate CourseDate { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}
