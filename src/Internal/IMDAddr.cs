using System;

namespace OpenMelissa.Internal
{
    internal interface IMDAddr : IResultCode, IDisposable
    {
        ProgramStatus Initialize(string p1,string p2,string p3);
        ProgramStatus InitializeDataFiles();
        string GetInitializeErrorString();
        bool SetLicenseString(string p1);
        string GetBuildNumber();
        string GetDatabaseDate();
        string GetExpirationDate();
        string GetLicenseExpirationDate();
        string GetCanadianDatabaseDate();
        string GetCanadianExpirationDate();
        void SetPathToUSFiles(string p1);
        void SetPathToCanadaFiles(string p1);
        void SetPathToDPVDataFiles(string p1);
        void SetPathToLACSLinkDataFiles(string p1);
        void SetPathToSuiteLinkDataFiles(string p1);
        void SetPathToSuiteFinderDataFiles(string p1);
        void SetPathToRBDIFiles(string p1);
        string GetRBDIDatabaseDate();
        void SetPathToAddrKeyDataFiles(string p1);
        void ClearProperties();
        void ResetDPV();
        void SetCASSEnable(int p1);
        void SetUseUSPSPreferredCityNames(int p1);
        void SetDiacritics(DiacriticsMode p1);
        string GetStatusCode();
        string GetErrorCode();
        string GetErrorString();
        void SetPS3553_B1_ProcessorName(string p1);
        void SetPS3553_B4_ListName(string p1);
        void SetPS3553_D3_Name(string p1);
        void SetPS3553_D3_Company(string p1);
        void SetPS3553_D3_Address(string p1);
        void SetPS3553_D3_City(string p1);
        void SetPS3553_D3_State(string p1);
        void SetPS3553_D3_ZIP(string p1);
        string GetFormPS3553();
        bool SaveFormPS3553(string p1);
        void ResetFormPS3553();
        void ResetFormPS3553Counter();
        void SetStandardizationType(StandardizeMode mode);
        void SetSuiteParseMode(SuiteParseMode mode);
        void SetAliasMode(AliasPreserveMode mode);
        string GetFormSOA();
        void SaveFormSOA(string p1);
        void ResetFormSOA();
        void SetSOACustomerInfo(string customerName,string customerAddress);
        void SetSOACPCNumber(string CPCNumber);
        string GetSOACustomerInfo();
        string GetSOACPCNumber();
        int GetSOATotalRecords();
        float GetSOAAAPercentage();
        string GetSOAAAExpiryDate();
        string GetSOASoftwareInfo();
        string GetSOAErrorString();
        void SetCompany(string p1);
        void SetLastName(string p1);
        void SetAddress(string p1);
        void SetAddress2(string p1);
        void SetLastLine(string p1);
        void SetSuite(string p1);
        void SetCity(string p1);
        void SetState(string p1);
        void SetZip(string p1);
        void SetPlus4(string p1);
        void SetUrbanization(string p1);
        void SetParsedAddressRange(string p1);
        void SetParsedPreDirection(string p1);
        void SetParsedStreetName(string p1);
        void SetParsedSuffix(string p1);
        void SetParsedPostDirection(string p1);
        void SetParsedSuiteName(string p1);
        void SetParsedSuiteRange(string p1);
        void SetParsedRouteService(string p1);
        void SetParsedLockBox(string p1);
        void SetParsedDeliveryInstallation(string p1);
        void SetCountryCode(string p1);
        bool VerifyAddress();
        string GetCompany();
        string GetLastName();
        string GetAddress();
        string GetAddress2();
        string GetSuite();
        string GetCity();
        string GetCityAbbreviation();
        string GetState();
        string GetZip();
        string GetPlus4();
        string GetCarrierRoute();
        string GetDeliveryPointCode();
        string GetDeliveryPointCheckDigit();
        string GetCountyFips();
        string GetCountyName();
        string GetAddressTypeCode();
        string GetAddressTypeString();
        string GetUrbanization();
        string GetCongressionalDistrict();
        string GetLACS();
        string GetLACSLinkIndicator();
        string GetPrivateMailbox();
        string GetTimeZoneCode();
        string GetTimeZone();
        string GetMsa();
        string GetPmsa();
        string GetDefaultFlagIndicator();
        [Obsolete("Use IMDAddr.GetResults() instead.")]
        string GetSuiteStatus();
        string GetEWSFlag();
        string GetCMRA();
        string GetDsfNoStats();
        string GetDsfVacant();
        string GetDsfDNA();
        string GetCountryCode();
        string GetZipType();
        string GetFalseTable();
        string GetDPVFootnotes();
        string GetLACSLinkReturnCode();
        string GetSuiteLinkReturnCode();
        string GetRBDI();
        string GetELotNumber();
        string GetELotOrder();
        string GetAddressKey();
        string GetMelissaAddressKey();
        string GetMelissaAddressKeyBase();
        bool FindSuggestion();
        bool FindSuggestionNext();
        int GetPS3553_B6_TotalRecords();
        int GetPS3553_C1a_ZIP4Coded();
        int GetPS3553_C1c_DPBCAssigned();
        int GetPS3553_C1d_FiveDigitCoded();
        int GetPS3553_C1e_CRRTCoded();
        int GetPS3553_C1f_eLOTAssigned();
        int GetPS3553_E_HighRiseDefault();
        int GetPS3553_E_HighRiseExact();
        int GetPS3553_E_RuralRouteDefault();
        int GetPS3553_E_RuralRouteExact();
        int GetZip4HRDefault();
        int GetZip4HRExact();
        int GetZip4RRDefault();
        int GetZip4RRExact();
        int GetPS3553_E_LACSCount();
        int GetPS3553_E_EWSCount();
        int GetPS3553_E_DPVCount();
        int GetPS3553_X_POBoxCount();
        int GetPS3553_X_HCExactCount();
        int GetPS3553_X_FirmCount();
        int GetPS3553_X_GenDeliveryCount();
        int GetPS3553_X_MilitaryZipCount();
        int GetPS3553_X_NonDeliveryCount();
        int GetPS3553_X_StreetCount();
        int GetPS3553_X_HCDefaultCount();
        int GetPS3553_X_OtherCount();
        int GetPS3553_X_LacsLinkCodeACount();
        int GetPS3553_X_LacsLinkCode00Count();
        int GetPS3553_X_LacsLinkCode14Count();
        int GetPS3553_X_LacsLinkCode92Count();
        int GetPS3553_X_LacsLinkCode09Count();
        int GetPS3553_X_SuiteLinkCodeACount();
        int GetPS3553_X_SuiteLinkCode00Count();
        string GetParsedAddressRange();
        string GetParsedPreDirection();
        string GetParsedStreetName();
        string GetParsedSuffix();
        string GetParsedPostDirection();
        string GetParsedSuiteName();
        string GetParsedSuiteRange();
        string GetParsedPrivateMailboxName();
        string GetParsedPrivateMailboxNumber();
        string GetParsedGarbage();
        string GetParsedRouteService();
        string GetParsedLockBox();
        string GetParsedDeliveryInstallation();
        void SetReserved(string p1,string p2);
        string GetReserved(string p1);
    }
}