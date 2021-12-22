using WebForumSecurity_Blazor.Models;

namespace WebForumSecurity_Blazor.DataAccess.Interfaces
{
    public interface IPostRepository
    {
        public  Task CreatePost(Post post);
        public Task<Post> GetPost(int postId);
        public Task DeletePost(Guid postId);
        public Task<IEnumerable<Post>> GetAllPosts();
        
    }
}
