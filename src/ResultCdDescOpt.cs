namespace OpenMelissa
{
    /// <summary>
    /// Used with <see cref="Internal.IResultCode.GetResultCodeDescription(string, ResultCodeDescriptionOption)"/>.
    /// </summary>
    public enum ResultCodeDescriptionOption {
        /// <summary>
        /// Default, Return a long description of the result code.
        /// </summary>
        ResultCodeDescriptionLong = 0,
        /// <summary>
        /// Return a short description of the result code.
        /// </summary>
        ResultCodeDescriptionShort = 1
    }
}