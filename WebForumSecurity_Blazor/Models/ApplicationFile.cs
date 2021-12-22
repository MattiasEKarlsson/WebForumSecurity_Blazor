using Microsoft.AspNetCore.Components.Forms;

namespace WebForumSecurity_Blazor.Models
{
    public class ApplicationFile
    {

        public Guid Id { get; set; }
        public string UntrustedName { get; set; }
        public DateTime TimeStamp { get; set; }
        public long? Size { get; set; }
        public byte[] Data { get; set; }
    }
}
