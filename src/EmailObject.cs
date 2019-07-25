using System;
using System.IO;
using System.Runtime.InteropServices;
using OpenMelissa.Configuration;
using OpenMelissa.Models;

namespace OpenMelissa
{
    public sealed class EmailObject : IDisposable
    {
        readonly Internal.IMDEmail EmailObj;
        readonly MelissaClientConfig Config;

        public BuildInfo Version { get; internal set; }

        internal EmailObject(MelissaClientConfig config)
        {
            Config = config;

            var arch = RuntimeInformation.OSArchitecture;
            string os = RuntimeInformation.OSDescription.ToLower();

            if (os.Contains("linux")
                && arch == Architecture.X64 || arch == Architecture.X86)
            { // Linux
                EmailObj = new mdEmailLinux();
            }
            else if (os.Contains("windows")
                && arch == Architecture.X64 || arch == Architecture.X86)
            { // windows
                EmailObj = new mdEmailWindows();
            }
            else
            {
                throw new PlatformNotSupportedException($"{RuntimeInformation.OSDescription} {arch} isn't supported currently");
            }

            Setup();
        }

        void Setup()
        {
            string dataFilesRoot = new DirectoryInfo(Config.DatafilesRoot).FullName;

            EmailObj.SetPathToEmailFiles(dataFilesRoot);
            EmailObj.SetLicenseString(Config.LicenseKey);

            ProgramStatus status = EmailObj.InitializeDataFiles();

            if (status != ProgramStatus.ErrorNone)
            {
                throw new MelissaException("Failed to start",
                    new MelissaException($"Failed to initialize Datafiles | {status} {EmailObj.GetInitializeErrorString()}"));
            }

            Version = new BuildInfo
            {
                BuildNumber = EmailObj.GetBuildNumber(),
                DataBaseFileDate = EmailObj.GetDatabaseDate(),
                DatabaseExpirationDate = EmailObj.GetDatabaseExpirationDate()
            };
        }

        public void SetOptions(EmailOptions options)
        {
            EmailObj.SetCacheUse(options.UseCache ? 1 : 0);
            EmailObj.SetCachePath(options.CacheLocation);
            EmailObj.SetCorrectSyntax(options.CorrectSyntax);
            EmailObj.SetDatabaseLookup(options.UseDatabaseLookup);
            EmailObj.SetFuzzyLookup(options.UseLocalFuzzyLookup);
            EmailObj.SetWSLookup(options.UseWebserviceLookup);
            EmailObj.SetWSMailboxLookup(options.MailboxLookupMode);
            EmailObj.SetMXLookup(options.EnableMXLookup);
            EmailObj.SetStandardizeCasing(options.StandardizeCasing);
            EmailObj.SetUpdateDomain(options.UpdateDomain);
        }

        ValidatedEmailAddress GetEmailAddress()
        {
            var tld = EmailObj.GetTopLevelDomain();
            var domain = EmailObj.GetDomainName();

            return new ValidatedEmailAddress
            {
                Mailbox = EmailObj.GetMailBoxName(),
                Domain = $"{domain}.{tld}",
                Address = EmailObj.GetEmailAddress(),
                TLD = EmailObj.GetTopLevelDomain(),
                TLDType = EmailObj.GetTopLevelDomainDescription()
            };
        }

        public ValidationResponse<ValidatedEmailAddress> VerifyEmail(EmailAddress emailAddress)
        {
            var toReturn = new ValidationResponse<ValidatedEmailAddress>
            {
                IsValid = EmailObj.VerifyEmail(emailAddress.Address),
                StatusCodes = EmailObj.GetParsedResultCodes(),
                Data = GetEmailAddress(),
                BuildInfo = Version
            };

            return toReturn;
        }

        public void Dispose()
        {
            EmailObj?.Dispose();
        }
    }
}
