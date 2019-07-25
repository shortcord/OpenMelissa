using System;

namespace OpenMelissa.Internal
{
    internal interface IMDEmail : IResultCode, IDisposable
    {
        bool SetLicenseString(string License);
        void SetPathToEmailFiles(string emailDataFiles);
        ProgramStatus InitializeDataFiles();
        string GetInitializeErrorString();
        string GetBuildNumber();
        string GetDatabaseDate();
        string GetDatabaseExpirationDate();
        string GetLicenseStringExpirationDate();
        bool VerifyEmail(string email);
        void SetCorrectSyntax(bool value);
        void SetUpdateDomain(bool value);
        void SetDatabaseLookup(bool value);
        void SetFuzzyLookup(bool value);
        void SetWSLookup(bool value);
        void SetWSMailboxLookup(MailboxLookupMode mailboxLookupmode);
        void SetMXLookup(bool value);
        void SetStandardizeCasing(bool value);
        string GetStatusCode();
        string GetErrorCode();
        string GetErrorString();
        uint GetChangeCode();
        string GetMailBoxName();
        string GetDomainName();
        string GetTopLevelDomain();
        string GetTopLevelDomainDescription();
        string GetEmailAddress();
        void SetReserved(string property, string value);
        string GetReserved(string property);
        void SetCachePath(string cachePath);
        void SetCacheUse(int cacheUse);
    }
}
