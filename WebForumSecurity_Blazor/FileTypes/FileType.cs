namespace WebForumSecurity_Blazor.FileTypes
{
    public abstract class FileType
    {
        

        public List<string> Extensions { get; }
            = new List<string>();

        public List<byte[]> Signatures { get; }
            = new List<byte[]>();

        public int SignatureLength => Signatures.Max(m => m.Length);

        public FileType AddSignatures(params byte[][] bytes)
        {
            Signatures.AddRange(bytes);
            return this;
        }

        public FileType AddExtensions(params string[] extensions)
        {
            Extensions.AddRange(extensions);
            return this;
        }

        public bool Verify(Stream stream)
        {
            stream.Position = 0;
            var reader = new BinaryReader(stream);
            var headerBytes = reader.ReadBytes(SignatureLength);
            if (Signatures.Any(signature =>headerBytes.Take(signature.Length).SequenceEqual(signature)))
            {
                return true;
            }
            else return false;
            
        }
    }

    public class FileTypeVerifyResult
    {
        public bool IsVerified { get; set; }
    }
}
