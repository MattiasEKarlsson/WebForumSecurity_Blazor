using Microsoft.AspNetCore.Components.Forms;
using WebForumSecurity_Blazor.Models;

namespace WebForumSecurity_Blazor.DataAccess.Interfaces
{
    public interface IFileHandler
    {
        public Task UploadFile(ApplicationFile file);
        public Task DownloadFile(Guid id);
        public Task<IEnumerable<ApplicationFile>> GetAllFiles();
    }
}
