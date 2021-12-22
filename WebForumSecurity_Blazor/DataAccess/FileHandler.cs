using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using WebForumSecurity_Blazor.DataAccess.Interfaces;
using WebForumSecurity_Blazor.Models;

namespace WebForumSecurity_Blazor.DataAccess
{
    public class FileHandler : IFileHandler
    {
        private readonly ApplicationDbContext _db;
        
        private readonly string[] permittedExtensions = { ".jpg", ".txt" };

        public FileHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task DownloadFile(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationFile>> GetAllFiles()
        {
            IEnumerable<ApplicationFile> list = await _db.File.ToListAsync();
            return list;
        }

        public async Task UploadFile(ApplicationFile file)
        {
            _db.Add(file);
            await _db.SaveChangesAsync();
        }
    }
}
