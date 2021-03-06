using System;

namespace SitkoCRM.Components.Storage
{
    public class S3StorageOptions : StorageOptions
    {
        public Uri Server { get; set; }
        public string Bucket { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
    }
}