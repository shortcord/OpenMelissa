using OpenMelissa.Configuration;
using OpenMelissa.Models;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace OpenMelissa
{
    /// <summary>
    /// The Address validation object
    /// </summary>
    public sealed class AddressObject : IDisposable
    {
        readonly Internal.IMDAddr AddressObj;
        readonly MelissaClientConfig Config;

        /// <summary>
        /// The database version info from Melissa's datafiles
        /// </summary>
        public BuildInfo Version { get; internal set; }

        internal AddressObject(MelissaClientConfig config)
        {
            Config = config;

            var arch = RuntimeInformation.OSArchitecture;
            string os = RuntimeInformation.OSDescription.ToLower();

            if (os.Contains("linux")
                && arch == Architecture.X64 || arch == Architecture.X86)
            { // Linux
                AddressObj = new mdAddrLinux();
            }
            else if (os.Contains("windows")
                && arch == Architecture.X64 || arch == Architecture.X86)
            { // windows
                AddressObj = new mdAddrWindows();
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

            AddressObj.SetLicenseString(Config.LicenseKey);

            if (Config.AddressObjectConfig.EnableUSData)
                AddressObj.SetPathToUSFiles(dataFilesRoot);

            if (Config.AddressObjectConfig.EnableCanadaData)
                AddressObj.SetPathToCanadaFiles(dataFilesRoot);

            if (Config.AddressObjectConfig.EnableDPVData)
                AddressObj.SetPathToDPVDataFiles(dataFilesRoot);

            if (Config.AddressObjectConfig.EnableLACSLink)
                AddressObj.SetPathToLACSLinkDataFiles(dataFilesRoot);

            if (Config.AddressObjectConfig.EnableSuiteFinder)
                AddressObj.SetPathToSuiteFinderDataFiles(dataFilesRoot);

            if (Config.AddressObjectConfig.EnableSuiteLink)
                AddressObj.SetPathToSuiteLinkDataFiles(dataFilesRoot);

            if (Config.AddressObjectConfig.EnableRBDI)
                AddressObj.SetPathToRBDIFiles(dataFilesRoot);

            if (Config.AddressObjectConfig.EnableDPVData &&
                Config.AddressObjectConfig.EnableLACSLink &&
                Config.AddressObjectConfig.EnableSuiteLink)
                AddressObj.SetCASSEnable(1);

            AddressObj.SetPathToAddrKeyDataFiles(dataFilesRoot);

            ProgramStatus status = AddressObj.InitializeDataFiles();

            if (status != ProgramStatus.ErrorNone)
            {
                throw new MelissaException("Failed to start",
                    new MelissaException($"Failed to initialize Datafiles | {status} {AddressObj.GetInitializeErrorString()}"));
            }

            Version = new BuildInfo
            {
                BuildNumber = AddressObj.GetBuildNumber(),
                DatabaseFileDate = AddressObj.GetDatabaseDate(),
                DatabaseExpirationDate = AddressObj.GetExpirationDate(),

                // only get RBDI if its enabled
                RBDIDatabaseDate = Config.AddressObjectConfig.EnableRBDI ? AddressObj.GetRBDIDatabaseDate() : null
            };
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or unmanaged resources.
        /// </summary>
        public void Dispose()
            => AddressObj?.Dispose();

        /// <summary>
        /// Clears the current propery state and sets the current address
        /// </summary>
        void SetAddress(Address address)
        {
            AddressObj.ClearProperties();

            AddressObj.SetCompany(address.Company ?? "");
            AddressObj.SetAddress(address.Address1 ?? "");
            AddressObj.SetAddress2(address.Address2 ?? "");
            AddressObj.SetSuite(address.Suite ?? "");
            AddressObj.SetCity(address.City ?? "");
            AddressObj.SetState(address.State ?? "");
            AddressObj.SetZip(address.PostalCode ?? "");
            AddressObj.SetPlus4(address.Plus4 ?? "");
            AddressObj.SetLastLine(address.LastLine ?? "");
            AddressObj.SetCountryCode(address.CountryCode ?? "");
            AddressObj.SetUrbanization(address.Urbanization ?? "");
        }

        /// <summary>
        /// Tries to verify the currently set address
        /// </summary>
        bool VerifyAddress()
            => AddressObj.VerifyAddress();

        /// <summary>
        /// Get the current address
        /// </summary>
        ValidatedAddress GetAddress(bool isValid)
        {
            var toReturn = new ValidatedAddress
            {
                IsValid = isValid,
                Address1 = AddressObj.GetAddress(),
                Address2 = AddressObj.GetAddress2(),
                Suite = AddressObj.GetSuite(),
                City = AddressObj.GetCity(),
                State = AddressObj.GetState(),
                PostalCode = AddressObj.GetZip(),
                Plus4 = AddressObj.GetPlus4(),
                CountryCode = AddressObj.GetCountryCode(),
                Urbanization = AddressObj.GetUrbanization(),
                Company = AddressObj.GetCompany()
            };

            // populate the last line
            toReturn.LastLine = $"{toReturn.City} {toReturn.State} {toReturn.PostalCode}-{toReturn.Plus4}";

            return toReturn;
        }

        /// <summary>
        /// Get the ELot order and number
        /// </summary>
        ELotOrder GetElotInfo()
        {
            return new ELotOrder
            {
                Number = AddressObj.GetELotNumber(),
                Order = AddressObj.GetELotOrder()
            };
        }

        /// <summary>
        /// Get the Suite Link codes
        /// </summary>
        SuiteLinkCode GetSuiteLinkCodes()
            => Config.AddressObjectConfig.EnableSuiteLink ? new SuiteLinkCode(AddressObj.GetSuiteLinkReturnCode()) : null;

        /// <summary>
        /// Get the RBDI status codes
        /// </summary>
        RBDIStatusCode GetRBDIStatusCodes()
            => Config.AddressObjectConfig.EnableRBDI ? new RBDIStatusCode(AddressObj.GetRBDI()) : null;

        /// <summary>
        /// Get the DPV status
        /// </summary>
       DPVStatus GetDPVStatus()
        {
            if (Config.AddressObjectConfig.EnableDPVData)
            {
                return new DPVStatus
                {
                    CheckDigit = AddressObj.GetDeliveryPointCheckDigit(),
                    Code = AddressObj.GetDeliveryPointCode(),
                    Footnotes = AddressObj.GetDPVFootnotes()
                };
            }

            return null;
        }

        /// <summary>
        /// <para>Validate a given address.</para>
        /// </summary>
        /// <param name="address">Address to validate</param>
        public ValidationResponse<ValidatedAddress> ValidateAddress(Address address)
        {
            ValidationResponse<ValidatedAddress> toReturn = null;

            SetAddress(address);

            bool isValid = VerifyAddress();

            var processedAddress = GetAddress(isValid);

            toReturn = new ValidationResponse<ValidatedAddress>
            {
                Data = processedAddress,
                IsValid = isValid,
                BuildInfo = Version,
                StatusCodes = AddressObj.GetParsedResultCodes()
            };

            // do USA specific logic
            if (processedAddress.CountryCode == "US")
            {
                processedAddress.ELot = GetElotInfo();
                processedAddress.SuiteLink = GetSuiteLinkCodes();
                processedAddress.RBDIStatusCode = GetRBDIStatusCodes();
                processedAddress.DPVStatus = GetDPVStatus();
            }

            return toReturn;
        }
    }
}
