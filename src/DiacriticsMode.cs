namespace OpenMelissa
{
    /// <summary>
    /// Enum to controll diacritic characters in French words for addresses located in Quebec.
    /// </summary>
    public enum DiacriticsMode {
        /// <summary>
        /// Return data with diacritic characters if already present, otherwise don't.
        /// </summary>
        Auto = 0,
        /// <summary>
        /// Always return diacritic characters.
        /// </summary>
        On = 1,
        /// <summary>
        /// Don't return diacritic characters.
        /// </summary>
        Off = 2
    }
}