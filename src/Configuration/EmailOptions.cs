using OpenMelissa;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMelissa.Configuration
{
    public sealed class EmailOptions
    {
        /// <summary>
        /// Enable or disable the use of a cache.
        /// Defaults to true.
        /// <para>
        /// The cached is used to store domains that have already been checked.
        /// This speeds up processing of domains.
        /// </para>
        /// </summary>
        public bool UseCache { get; set; } = true;

        /// <summary>
        /// The location of the cache, if null then it defaults to the platform's temporary directory.
        /// </summary>
        public string CacheLocation { get; set; } = null;

        /// <summary>
        /// <see cref="EmailObject"/> will attempt to correct the syntax of any given email address.
        /// Defaults to true.
        /// <para>
        /// This includes removal of excess or illegal characters, correction of misspelled TLDs, and enforcing RFC 5322 "strict definitions".
        /// </para>
        /// </summary>
        public bool CorrectSyntax { get; set; } = true;

        /// <summary>
        /// <see cref="EmailObject"/> will attempt to validate any email addresses using its own database of known valid and invalid domain names.
        /// Defaults to true.
        /// </summary>
        public bool UseDatabaseLookup { get; set; } = true;

        /// <summary>
        /// <see cref="EmailObject"/> will attempt to validate any email addresses using a fuzzy matching algorithm, 
        /// this is slower than a normal database lookup but potentially more accurate if the domain name contains a common or transposed typo.
        /// Defaults to false.
        /// </summary>
        public bool UseLocalFuzzyLookup { get; set; } = false;

        /// <summary>
        /// <see cref="EmailObject"/> will attempt to validate any email addresses using Melissa's online database.
        /// This is slower than a normal database lookup but potentially more accurate if the domain name is either obscure, new, or no longer valid.
        /// Defaults to false.
        /// </summary>
        public bool UseWebserviceLookup { get; set; } = false;

        /// <summary>
        /// Used with <see cref="UseWebserviceLookup"/>, sets the type of lookup when the service is contacted.
        /// Default is <see cref="MailboxLookupMode.MailboxNone"/>.
        /// </summary>
        public MailboxLookupMode MailboxLookupMode { get; set; } = MailboxLookupMode.MailboxNone;

        /// <summary>
        /// <see cref="EmailObject"/> will attempt to locate a MX or A record for the domain on the email address.
        /// This is slower than a normal database lookup but potentially more accurate if the domain name is either obscure or new.
        /// Default is false.
        /// </summary>
        public bool EnableMXLookup { get; set; } = false;

        /// <summary>
        /// <see cref="EmailObject"/> will enforce all lowercase letters for all email addresses.
        /// This does not affect the validation of an email address since they are case-insensitive.
        /// Defaults to true.
        /// </summary>
        public bool StandardizeCasing { get; set; } = true;

        /// <summary>
        /// <see cref="EmailObject"/> will attempt to update the domain name of an email address.
        /// Defaults to true.
        /// </summary>
        public bool UpdateDomain { get; set; } = true;

        /// <summary>
        /// Default options.
        /// </summary>
        public static EmailOptions Default
            => new EmailOptions
            {
                UseCache = true,
                CacheLocation = null,
                CorrectSyntax = true,
                EnableMXLookup = false,
                MailboxLookupMode = MailboxLookupMode.MailboxNone,
                StandardizeCasing = true,
                UpdateDomain = true,
                UseDatabaseLookup = true,
                UseLocalFuzzyLookup = false,
                UseWebserviceLookup = false
            };
    }
}
