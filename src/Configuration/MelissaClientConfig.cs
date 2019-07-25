namespace OpenMelissa.Configuration
{
    public sealed class MelissaClientConfig
    {
        public string LicenseKey { get; set; }
        public string DatafilesRoot { get; set; }
        public MelissaClientAddressConfig AddressObjectConfig { get; set; }
    }
}
