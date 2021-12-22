using System.ComponentModel.DataAnnotations;

namespace WebForumSecurity_Blazor.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        [Required]
        public string Header { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
