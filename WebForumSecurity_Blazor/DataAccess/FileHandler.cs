using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using WebForumSecurity_Blazor.DataAccess.Interfaces;
using WebForumSecurity_Blazor.Models;
using System.IO;
using Microsoft.JSInterop;



namespace WebForumSecurity_Blazor.DataAccess
{
    public class FileHandler : IFileHandler
    {
        private readonly ApplicationDbContext _db;
        
        private readonly string[] permittedExtensions = { ".jpg" };

        public FileHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ApplicationFile> DownloadFile(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var applicationFile = await _db.File
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationFile==null)
            {
                return null;
            }
            return applicationFile;
           
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

        public async Task Delete(Guid id)
        {
            
            var file =  await _db.File.FirstOrDefaultAsync(f => f.Id == id);
             _db.Remove(file);
            await _db.SaveChangesAsync();
        }

        
    }
}
