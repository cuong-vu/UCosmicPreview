using System;
using System.Security.Cryptography.X509Certificates;

namespace UCosmic.Impl
{
    // ReSharper disable ClassNeverInstantiated.Global
    public class PublicSamlCertificateStorage : IStoreSamlCertificates
    // ReSharper restore ClassNeverInstantiated.Global
    {
        private const string PrivateKey = "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";

        public X509Certificate2 GetSigningCertificate() { return GetCertificate(); }
        public X509Certificate2 GetEncryptionCertificate() { return GetCertificate(); }

        private static X509Certificate2 GetCertificate()
        {
            var certificate = new X509Certificate2(Convert.FromBase64String(PrivateKey),
                string.Empty, X509KeyStorageFlags.PersistKeySet);
            return certificate;
        }
    }
}