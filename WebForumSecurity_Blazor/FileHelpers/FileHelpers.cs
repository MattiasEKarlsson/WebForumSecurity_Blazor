

namespace WebForumSecurity_Blazor.Verify
{
    public class FileHelpers
    {
        private static readonly Dictionary<string, List<byte[]>> _fileSignature = new Dictionary<string, List<byte[]>>
        {
            { ".jpeg", new List<byte[]>
        {
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
        }
            },
                { ".jpg", new List<byte[]>
        {
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
        }
            },
                    { ".png", new List<byte[]>
        {
            new byte[] {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A}
        }
            },
        };

        public bool CheckIfValid(Stream file, string ext)
        {
            var reader = new BinaryReader(file);
            var signatures = _fileSignature[ext];
            var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

            if (signatures.Any(signature => headerBytes.Take(signature.Length).SequenceEqual(signature)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string ChangeName(string name)
        {
            int lenth = name.Count() / 2 - 1;
            var newName = name.Insert(lenth, Path.GetRandomFileName());
            return newName;
        }

    }
}
