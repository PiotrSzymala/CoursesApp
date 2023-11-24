using System.ComponentModel.DataAnnotations;

namespace AplikacjaMetodyki.Models
{
    public class SignupMessage
    {
        [Key]
        public int SignupMessageId { get; set; }

        [Required]
        public string Message { get; set; }

        public Course Course { get; set; }
    }
}
