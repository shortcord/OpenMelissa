namespace OpenMelissa.Configuration
{
    public sealed class MelissaClientAddressConfig
    {
        public bool EnableUSData { get; set; }
        public bool EnableCanadaData { get; set; }
        public bool EnableDPVData { get; set; }
        public bool EnableLACSLink { get; set; }
        public bool EnableSuiteFinder { get; set; }
        public bool EnableSuiteLink { get; set; }
        public bool EnableRBDI { get; set; }
    }
}
