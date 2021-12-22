using Microsoft.EntityFrameworkCore;
using System.Web;
using WebForumSecurity_Blazor.DataAccess.Interfaces;
using WebForumSecurity_Blazor.Models;

namespace WebForumSecurity_Blazor.DataAccess
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _db;
        public List<string> allowedTags { get; set; }

        public PostRepository(ApplicationDbContext db)
        {
            _db = db;
            allowedTags = new List<string>() { "<b>", "</b>", "<h2>", "</h2>" };
        }

        public async Task CreatePost(Post post)
        {
            
                post.Id = Guid.NewGuid();
                post.TimeStamp = DateTime.Now;
                string encodedContent = HttpUtility.HtmlEncode(post.Content);

                foreach (var tag in allowedTags)
                {
                    string encodedTag = HttpUtility.HtmlEncode(tag);
                    encodedContent = encodedContent.Replace(encodedTag, tag);
                }
                post.Content = encodedContent;
                _db.Add(post);
                await _db.SaveChangesAsync();
            
            
        }

        public async Task DeletePost(Guid postId)
        {
            var postDetails = await _db.Posts.FindAsync(postId);
            if (postDetails != null)
            {
                _db.Posts.Remove(postDetails);
                 await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            var lastPosts = await _db.Posts.OrderByDescending(p => p.TimeStamp).Take(5).ToListAsync();
            return lastPosts;
            
        }

        public Task<Post> GetPost(int postId)
        {
            throw new NotImplementedException();
        }
    }
}
