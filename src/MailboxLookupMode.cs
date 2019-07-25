namespace OpenMelissa
{
    public enum MailboxLookupMode {
        /// <summary>
        /// Domain and TLD checking only.
        /// </summary>
        MailboxNone = 0,
        /// <summary>
        /// Quick validation against a database of known email addresses.
        /// </summary>
        MailboxExpress = 1,
        /// <summary>
        /// Real-Time, live Validation of an Email Address.
        /// </summary>
        MailboxPremium = 2
    }
}