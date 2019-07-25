using OpenMelissa.Configuration;
using OpenMelissa.Models;
using OpenMelissa;
using System;
using System.Runtime.InteropServices;

namespace OpenMelissa
{
    public sealed class ParseObject : IDisposable
    {
        readonly Internal.IMDParse ParseObj;
        readonly MelissaClientConfig Config;

        /// <summary>
        /// Build info for this object.
        /// </summary>
        public BuildInfo Version { get; internal set; }

        internal ParseObject(MelissaClientConfig config)
        {
            var arch = RuntimeInformation.OSArchitecture;
            string os = RuntimeInformation.OSDescription.ToLower();

            if (os.Contains("linux") 
                && arch == Architecture.X64 || arch == Architecture.X86)
            { // Linux
                ParseObj = new OpenMelissa.mdParseLinux();
            }
            else if (os.Contains("windows") 
                && arch == Architecture.X64 || arch == Architecture.X86)
            { // windows
                ParseObj = new OpenMelissa.mdParseWindows();
            }
            else
            {
                throw new PlatformNotSupportedException($"{RuntimeInformation.OSDescription} {arch} isn't supported currently");
            }

            Config = config;

            Setup();
        }

        void Setup()
        {
            ProgramStatus status = ParseObj.Initialize(Config.DatafilesRoot);

            if (status != ProgramStatus.ErrorNone)
            {
                throw new MelissaException("Failed to start",
                    new MelissaException($"Failed to initialize Parse Object | {status}"));
            }

            Version = new BuildInfo
            {
                BuildNumber = ParseObj.GetBuildNumber()
            };
        }

        ParsedResult GetResult()
        {
            return new ParsedResult()
            {
                City = ParseObj.GetCity(),
                State = ParseObj.GetState(),
                PostalCode = ParseObj.GetZip(),
                Plus4 = ParseObj.GetPlus4(),


                Range = ParseObj.GetRange(),
                PreDirection = ParseObj.GetPreDirection(),
                PostDirection = ParseObj.GetPostDirection(),
                StreetName = ParseObj.GetStreetName(),
                Suffix = ParseObj.GetSuffix(),
                SuiteName = ParseObj.GetSuiteName(),
                SuiteNumber = ParseObj.GetSuiteNumber(),
                PrivateMailboxName = ParseObj.GetPrivateMailboxName(),
                PrivateMailboxNumber = ParseObj.GetPrivateMailboxNumber(),
                LockBox = ParseObj.GetLockBox(),
                DeliveryInstallation = ParseObj.GetDeliveryInstallation(),
                Garbage = ParseObj.GetGarbage(),
                RouteService = ParseObj.GetRouteService()
            };
        }

        /// <summary>
        /// Parse an Canadian address.
        /// </summary>
        /// <param name="addressLine">Range, street name, and number if any.</param>
        /// <param name="lastLine">City, State, Country and/or PostalCode.</param>
        public ParsedResult ParseCanadian(string addressLine, string lastLine)
        {
            ParseObj.ParseCanadian(addressLine);
            ParseObj.LastLineParse(lastLine);

            return GetResult();
        }

        /// <summary>
        /// Parse an US address.
        /// </summary>
        /// <param name="addressLine">Range, street name, and number if any.</param>
        /// <param name="lastLine">City, State, Country and/or PostalCode.</param>
        public ParsedResult ParseUS(string addressLine, string lastLine)
        {
            ParseObj.Parse(addressLine);
            ParseObj.LastLineParse(lastLine);

            return GetResult();
        }

        public void Dispose()
        {
            ParseObj?.Dispose();
        }
    }
}
