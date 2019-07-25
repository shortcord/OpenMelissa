namespace OpenMelissa
{
    public struct BuildInfo
    {
        public string BuildNumber { get; internal set; }
        public string DataBaseFileDate { get; internal set; }
        public string DatabaseExpirationDate { get; internal set; }
        public string RBDIDatabaseDate { get; internal set; }

        public override string ToString()
        {
            return $"Build Number: {BuildNumber} | Built: {DataBaseFileDate}; Expiration: {DatabaseExpirationDate}";
        }
    }
}
