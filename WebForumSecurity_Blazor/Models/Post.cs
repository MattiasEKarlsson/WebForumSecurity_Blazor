namespace WebForumSecurity_Blazor.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
    }
}
