namespace OpenMelissa.Internal
{
    /// <summary>
    /// Interface to define that <see cref="GetResults()"/>, <see cref="GetResultCodeDescription(string, ResultCodeDescriptionOption)"/>,
    /// and <see cref="GetResultCodeDescription(string)"/> are implemented.
    /// </summary>
    internal interface IResultCode
    {
        /// <summary>
        /// Returns a comma-delimited string of four-character codes used for
        /// discribing the outcome of the verifying process.
        /// </summary>
        string GetResults();
        /// <summary>
        /// Get the Result Code description.
        /// </summary>
        /// <param name="resultCode">A four-character code, 
        /// if the whole result of <see cref="GetResults()"/> is passed, 
        /// then the first result's description is returned.</param>
        /// <param name="opt">Either return the short or long description.</param>
        string GetResultCodeDescription(string resultCode, ResultCodeDescriptionOption opt);
        /// <summary>
        /// Same as <see cref="GetResultCodeDescription(string, ResultCodeDescriptionOption)"/>.
        /// Removes the need of passing a <see cref="ResultCodeDescriptionOption"/>.
        /// Returns a long description.
        /// </summary>
        /// <param name="resultCode">A four-character code, 
        /// if the whole result of <see cref="GetResults()"/> is passed, 
        /// then the first result's description is returned.</param>
        string GetResultCodeDescription(string resultCode);
    }
}
