using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using WebForumSecurity_Blazor.Models;

namespace WebForumSecurity_Blazor.DataAccess.Interfaces
{
    public interface IFileHandler
    {
        public Task UploadFile(ApplicationFile file);
        public Task<ApplicationFile> DownloadFile(Guid? id);
        public Task<IEnumerable<ApplicationFile>> GetAllFiles();
        public Task Delete(Guid id);
    }
}
