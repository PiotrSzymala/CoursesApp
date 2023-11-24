using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacjaMetodyki.Models
{
    public class ForumPost
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(300)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AttachedMedia { get; set; }

        public User User { get; set; }

        [ForeignKey("CategoryId")]
        public ForumCategory ForumCategory { get; set; }
    }
}
