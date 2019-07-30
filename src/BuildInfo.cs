namespace OpenMelissa
{
    /// <summary>
    /// Information regarding Build numbers and dates for datafiles.
    /// </summary>
    public struct BuildInfo
    {
        /// <summary>
        /// The Build number for the loaded datafiles.
        /// </summary>
        public string BuildNumber { get; internal set; }
        /// <summary>
        /// The date that the loaded datafiles were built.
        /// </summary>
        public string DatabaseFileDate { get; internal set; }
        /// <summary>
        /// The date that the loaded datafiles will exipre, this does not account for the license length.
        /// </summary>
        public string DatabaseExpirationDate { get; internal set; }
        /// <summary>
        /// The date that the loaded RBDI database was build.
        /// </summary>
        public string RBDIDatabaseDate { get; internal set; }

        public override string ToString()
        {
            return $"Build Number: {BuildNumber} | Built: {DatabaseFileDate}; Expiration: {DatabaseExpirationDate} | RBDI Date {RBDIDatabaseDate}";
        }
    }
}
