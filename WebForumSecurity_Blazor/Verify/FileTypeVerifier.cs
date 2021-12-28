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

        public  bool What(Stream path)
        {
            
            bool result = false;

            foreach (var fileType in Types)
            {
                result = fileType.Verify(path);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }   
            }
            return false;
            
        }
    }
}
