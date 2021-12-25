using WebForumSecurity_Blazor.FileTypes;

namespace WebForumSecurity_Blazor.Verify
{
    public class FileTypeVerifier
    {
        public FileTypeVerifyResult Unknown = new FileTypeVerifyResult
        {
            IsVerified = false
        };

         public FileTypeVerifier()
        {
            Types = new List<FileType>
                {
                    new Jpeg(),
                    new Png(),
                    
                }
                .OrderByDescending(x => x.SignatureLength)
                .ToList();
        }

        public IEnumerable<FileType> Types { get; set; }

        public  FileTypeVerifyResult What(Stream path)
        {
            using var file = path;
            FileTypeVerifyResult result = null;

            foreach (var fileType in Types)
            {
                result = fileType.Verify(file);
                if (result.IsVerified)
                    break;
            }

            return result?.IsVerified == true
                   ? result
                   : Unknown;
        }
    }
}
