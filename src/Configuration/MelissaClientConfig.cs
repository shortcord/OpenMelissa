namespace OpenMelissa.Configuration
{
    /// <summary>
    /// <see cref="MelissaClient"/> configuration options.
    /// </summary>
    public sealed class MelissaClientConfig
    {
        /// <summary>
        /// The LicenseKey given by Melissa, defaults to DEMO if nothing is set.
        /// </summary>
        public string LicenseKey { get; set; } = "DEMO";
        /// <summary>
        /// The directory that holds the datafiles from Melissa.
        /// </summary>
        public string DatafilesRoot { get; set; }
        /// <summary>
        /// Options for features used by the <see cref="AddressObject"/>.
        /// </summary>
        public MelissaClientAddressConfig AddressObjectConfig { get; set; }
    }
}
