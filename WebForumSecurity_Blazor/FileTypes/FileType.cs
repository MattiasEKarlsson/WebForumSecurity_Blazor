namespace WebForumSecurity_Blazor.FileTypes
{
    public abstract class FileType
    {
        public string Description { get; set; }
        public string Name { get; set; }

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

        public FileTypeVerifyResult Verify(Stream stream)
        {
            stream.Position = 0;
            var reader = new BinaryReader(stream);
            var headerBytes = reader.ReadBytes(SignatureLength);

            return new FileTypeVerifyResult
            {
                IsVerified = Signatures.Any(signature =>
                    headerBytes.Take(signature.Length)
                        .SequenceEqual(signature)
                )
            };
        }
    }

    public class FileTypeVerifyResult
    {
        public bool IsVerified { get; set; }
    }
}
