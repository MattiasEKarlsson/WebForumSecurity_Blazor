﻿namespace WebForumSecurity_Blazor.FileTypes
{
    public class Jpeg : FileType
    {
        public Jpeg()
        {
            
            AddExtensions("jpeg", "jpg");
            AddSignatures(
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }
            );
        }
    }
}