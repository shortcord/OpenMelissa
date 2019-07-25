using OpenMelissa.Internal;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace OpenMelissa
{
    internal class mdAddrLinux : IDisposable, IMDAddr
    {
        private readonly IntPtr i;

        [SuppressUnmanagedCodeSecurity]
		private class NativeMethods {
			const string LibName = "libmdAddr";

			[DllImport(LibName, EntryPoint = "mdAddrCreate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrCreate();
			[DllImport(LibName, EntryPoint = "mdAddrDestroy", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrDestroy(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrInitialize", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrInitialize(IntPtr i, string p1, string p2, string p3);
			[DllImport(LibName, EntryPoint = "mdAddrInitializeDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrInitializeDataFiles(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetInitializeErrorString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetInitializeErrorString(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrSetLicenseString", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrSetLicenseString(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrGetBuildNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetBuildNumber(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetDatabaseDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDatabaseDate(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetExpirationDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetExpirationDate(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetLicenseExpirationDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetLicenseExpirationDate(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetCanadianDatabaseDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCanadianDatabaseDate(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetCanadianExpirationDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCanadianExpirationDate(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrSetPathToUSFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToUSFiles(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPathToCanadaFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToCanadaFiles(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPathToDPVDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToDPVDataFiles(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPathToLACSLinkDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToLACSLinkDataFiles(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPathToSuiteLinkDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToSuiteLinkDataFiles(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPathToSuiteFinderDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToSuiteFinderDataFiles(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPathToRBDIFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToRBDIFiles(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrGetRBDIDatabaseDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetRBDIDatabaseDate(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrSetPathToAddrKeyDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPathToAddrKeyDataFiles(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrClearProperties", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrClearProperties(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrResetDPV", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrResetDPV(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrSetCASSEnable", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetCASSEnable(IntPtr i, Int32 p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetUseUSPSPreferredCityNames", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetUseUSPSPreferredCityNames(IntPtr i, Int32 p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetDiacritics", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetDiacritics(IntPtr i, Int32 p1);
			[DllImport(LibName, EntryPoint = "mdAddrGetStatusCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetStatusCode(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetErrorCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetErrorCode(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetErrorString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetErrorString(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetResults", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetResults(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetResultCodeDescription", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetResultCodeDescription(IntPtr i, string resultCode, Int32 opt);
			[DllImport(LibName, EntryPoint = "mdAddrSetPS3553_B1_ProcessorName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_B1_ProcessorName(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPS3553_B4_ListName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_B4_ListName(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPS3553_D3_Name", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_D3_Name(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPS3553_D3_Company", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_D3_Company(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPS3553_D3_Address", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_D3_Address(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPS3553_D3_City", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_D3_City(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPS3553_D3_State", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_D3_State(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPS3553_D3_ZIP", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPS3553_D3_ZIP(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrGetFormPS3553", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetFormPS3553(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrSaveFormPS3553", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrSaveFormPS3553(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrResetFormPS3553", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrResetFormPS3553(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrResetFormPS3553Counter", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrResetFormPS3553Counter(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrSetStandardizationType", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetStandardizationType(IntPtr i, Int32 mode);
			[DllImport(LibName, EntryPoint = "mdAddrSetSuiteParseMode", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetSuiteParseMode(IntPtr i, Int32 mode);
			[DllImport(LibName, EntryPoint = "mdAddrSetAliasMode", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetAliasMode(IntPtr i, Int32 mode);
			[DllImport(LibName, EntryPoint = "mdAddrGetFormSOA", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetFormSOA(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrSaveFormSOA", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSaveFormSOA(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrResetFormSOA", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrResetFormSOA(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrSetSOACustomerInfo", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetSOACustomerInfo(IntPtr i, string customerName, string customerAddress);
			[DllImport(LibName, EntryPoint = "mdAddrSetSOACPCNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetSOACPCNumber(IntPtr i, string CPCNumber);
			[DllImport(LibName, EntryPoint = "mdAddrGetSOACustomerInfo", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSOACustomerInfo(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetSOACPCNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSOACPCNumber(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetSOATotalRecords", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetSOATotalRecords(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetSOAAAPercentage", CallingConvention = CallingConvention.Cdecl)]
			public static extern float mdAddrGetSOAAAPercentage(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetSOAAAExpiryDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSOAAAExpiryDate(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetSOASoftwareInfo", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSOASoftwareInfo(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetSOAErrorString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSOAErrorString(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrSetCompany", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetCompany(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetLastName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetLastName(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetAddress", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetAddress(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetAddress2", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetAddress2(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetLastLine", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetLastLine(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetSuite", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetSuite(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetCity", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetCity(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetState", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetState(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetZip", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetZip(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetPlus4", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetPlus4(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetUrbanization", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetUrbanization(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetParsedAddressRange", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedAddressRange(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetParsedPreDirection", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedPreDirection(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetParsedStreetName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedStreetName(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetParsedSuffix", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedSuffix(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetParsedPostDirection", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedPostDirection(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetParsedSuiteName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedSuiteName(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetParsedSuiteRange", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedSuiteRange(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetParsedRouteService", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedRouteService(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetParsedLockBox", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedLockBox(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetParsedDeliveryInstallation", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetParsedDeliveryInstallation(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrSetCountryCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetCountryCode(IntPtr i, string p1);
			[DllImport(LibName, EntryPoint = "mdAddrVerifyAddress", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrVerifyAddress(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetCompany", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCompany(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetLastName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetLastName(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetAddress", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetAddress(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetAddress2", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetAddress2(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetSuite", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSuite(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetCity", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCity(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetCityAbbreviation", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCityAbbreviation(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetState", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetState(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetZip", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetZip(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPlus4", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetPlus4(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetCarrierRoute", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCarrierRoute(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetDeliveryPointCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDeliveryPointCode(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetDeliveryPointCheckDigit", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDeliveryPointCheckDigit(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetCountyFips", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCountyFips(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetCountyName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCountyName(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetAddressTypeCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetAddressTypeCode(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetAddressTypeString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetAddressTypeString(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetUrbanization", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetUrbanization(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetCongressionalDistrict", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCongressionalDistrict(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetLACS", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetLACS(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetLACSLinkIndicator", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetLACSLinkIndicator(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPrivateMailbox", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetPrivateMailbox(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetTimeZoneCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetTimeZoneCode(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetTimeZone", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetTimeZone(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetMsa", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetMsa(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPmsa", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetPmsa(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetDefaultFlagIndicator", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDefaultFlagIndicator(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetSuiteStatus", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSuiteStatus(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetEWSFlag", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetEWSFlag(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetCMRA", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCMRA(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetDsfNoStats", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDsfNoStats(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetDsfVacant", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDsfVacant(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetDsfDNA", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDsfDNA(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetCountryCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetCountryCode(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetZipType", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetZipType(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetFalseTable", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetFalseTable(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetDPVFootnotes", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetDPVFootnotes(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetLACSLinkReturnCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetLACSLinkReturnCode(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetSuiteLinkReturnCode", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetSuiteLinkReturnCode(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetRBDI", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetRBDI(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetELotNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetELotNumber(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetELotOrder", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetELotOrder(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetAddressKey", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetAddressKey(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetMelissaAddressKey", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetMelissaAddressKey(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetMelissaAddressKeyBase", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetMelissaAddressKeyBase(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrFindSuggestion", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrFindSuggestion(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrFindSuggestionNext", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrFindSuggestionNext(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_B6_TotalRecords", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_B6_TotalRecords(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_C1a_ZIP4Coded", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_C1a_ZIP4Coded(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_C1c_DPBCAssigned", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_C1c_DPBCAssigned(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_C1d_FiveDigitCoded", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_C1d_FiveDigitCoded(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_C1e_CRRTCoded", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_C1e_CRRTCoded(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_C1f_eLOTAssigned", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_C1f_eLOTAssigned(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_E_HighRiseDefault", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_HighRiseDefault(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_E_HighRiseExact", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_HighRiseExact(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_E_RuralRouteDefault", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_RuralRouteDefault(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_E_RuralRouteExact", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_RuralRouteExact(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetZip4HRDefault", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetZip4HRDefault(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetZip4HRExact", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetZip4HRExact(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetZip4RRDefault", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetZip4RRDefault(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetZip4RRExact", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetZip4RRExact(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_E_LACSCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_LACSCount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_E_EWSCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_EWSCount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_E_DPVCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_E_DPVCount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_POBoxCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_POBoxCount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_HCExactCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_HCExactCount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_FirmCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_FirmCount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_GenDeliveryCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_GenDeliveryCount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_MilitaryZipCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_MilitaryZipCount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_NonDeliveryCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_NonDeliveryCount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_StreetCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_StreetCount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_HCDefaultCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_HCDefaultCount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_OtherCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_OtherCount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_LacsLinkCodeACount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_LacsLinkCodeACount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_LacsLinkCode00Count", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_LacsLinkCode00Count(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_LacsLinkCode14Count", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_LacsLinkCode14Count(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_LacsLinkCode92Count", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_LacsLinkCode92Count(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_LacsLinkCode09Count", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_LacsLinkCode09Count(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_SuiteLinkCodeACount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_SuiteLinkCodeACount(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetPS3553_X_SuiteLinkCode00Count", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdAddrGetPS3553_X_SuiteLinkCode00Count(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetParsedAddressRange", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedAddressRange(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetParsedPreDirection", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedPreDirection(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetParsedStreetName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedStreetName(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetParsedSuffix", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedSuffix(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetParsedPostDirection", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedPostDirection(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetParsedSuiteName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedSuiteName(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetParsedSuiteRange", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedSuiteRange(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetParsedPrivateMailboxName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedPrivateMailboxName(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetParsedPrivateMailboxNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedPrivateMailboxNumber(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetParsedGarbage", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedGarbage(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetParsedRouteService", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedRouteService(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetParsedLockBox", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedLockBox(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrGetParsedDeliveryInstallation", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetParsedDeliveryInstallation(IntPtr i);
			[DllImport(LibName, EntryPoint = "mdAddrSetReserved", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdAddrSetReserved(IntPtr i, string p1, string p2);
			[DllImport(LibName, EntryPoint = "mdAddrGetReserved", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdAddrGetReserved(IntPtr i, string p1);
		}

		public mdAddrLinux() {
			i = NativeMethods.mdAddrCreate();
		}

		public virtual void Dispose() {
			lock (this) {
				NativeMethods.mdAddrDestroy(i);
				GC.SuppressFinalize(this);
			}
		}

		public ProgramStatus Initialize(string p1, string p2, string p3) {
			return (ProgramStatus)NativeMethods.mdAddrInitialize(i, p1, p2, p3);
		}

		public ProgramStatus InitializeDataFiles() {
			return (ProgramStatus)NativeMethods.mdAddrInitializeDataFiles(i);
		}

		public string GetInitializeErrorString() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetInitializeErrorString(i));
		}

		public bool SetLicenseString(string p1) {
			return (NativeMethods.mdAddrSetLicenseString(i, p1) != 0);
		}

		public string GetBuildNumber() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetBuildNumber(i));
		}

		public string GetDatabaseDate() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetDatabaseDate(i));
		}

		public string GetExpirationDate() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetExpirationDate(i));
		}

		public string GetLicenseExpirationDate() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetLicenseExpirationDate(i));
		}

		public string GetCanadianDatabaseDate() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetCanadianDatabaseDate(i));
		}

		public string GetCanadianExpirationDate() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetCanadianExpirationDate(i));
		}

		public void SetPathToUSFiles(string p1) {
			NativeMethods.mdAddrSetPathToUSFiles(i, p1);
		}

		public void SetPathToCanadaFiles(string p1) {
			NativeMethods.mdAddrSetPathToCanadaFiles(i, p1);
		}

		public void SetPathToDPVDataFiles(string p1) {
			NativeMethods.mdAddrSetPathToDPVDataFiles(i, p1);
		}

		public void SetPathToLACSLinkDataFiles(string p1) {
			NativeMethods.mdAddrSetPathToLACSLinkDataFiles(i, p1);
		}

		public void SetPathToSuiteLinkDataFiles(string p1) {
			NativeMethods.mdAddrSetPathToSuiteLinkDataFiles(i, p1);
		}

		public void SetPathToSuiteFinderDataFiles(string p1) {
			NativeMethods.mdAddrSetPathToSuiteFinderDataFiles(i, p1);
		}

		public void SetPathToRBDIFiles(string p1) {
			NativeMethods.mdAddrSetPathToRBDIFiles(i, p1);
		}

		public string GetRBDIDatabaseDate() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetRBDIDatabaseDate(i));
		}

		public void SetPathToAddrKeyDataFiles(string p1) {
			NativeMethods.mdAddrSetPathToAddrKeyDataFiles(i, p1);
		}

		public void ClearProperties() {
			NativeMethods.mdAddrClearProperties(i);
		}

		public void ResetDPV() {
			NativeMethods.mdAddrResetDPV(i);
		}

		public void SetCASSEnable(int p1) {
			NativeMethods.mdAddrSetCASSEnable(i, p1);
		}

		public void SetUseUSPSPreferredCityNames(int p1) {
			NativeMethods.mdAddrSetUseUSPSPreferredCityNames(i, p1);
		}

		public void SetDiacritics(DiacriticsMode p1) {
			NativeMethods.mdAddrSetDiacritics(i, (int)p1);
		}

		public string GetStatusCode() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetStatusCode(i));
		}

		public string GetErrorCode() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetErrorCode(i));
		}

		public string GetErrorString() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetErrorString(i));
		}

		public string GetResults() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetResults(i));
		}

		public string GetResultCodeDescription(string resultCode, ResultCodeDescriptionOption opt) {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetResultCodeDescription(i, resultCode, (int)opt));
		}

		public string GetResultCodeDescription(string resultCode) {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetResultCodeDescription(i, resultCode, (int)ResultCodeDescriptionOption.ResultCodeDescriptionLong));
		}

		public void SetPS3553_B1_ProcessorName(string p1) {
			NativeMethods.mdAddrSetPS3553_B1_ProcessorName(i, p1);
		}

		public void SetPS3553_B4_ListName(string p1) {
			NativeMethods.mdAddrSetPS3553_B4_ListName(i, p1);
		}

		public void SetPS3553_D3_Name(string p1) {
			NativeMethods.mdAddrSetPS3553_D3_Name(i, p1);
		}

		public void SetPS3553_D3_Company(string p1) {
			NativeMethods.mdAddrSetPS3553_D3_Company(i, p1);
		}

		public void SetPS3553_D3_Address(string p1) {
			NativeMethods.mdAddrSetPS3553_D3_Address(i, p1);
		}

		public void SetPS3553_D3_City(string p1) {
			NativeMethods.mdAddrSetPS3553_D3_City(i, p1);
		}

		public void SetPS3553_D3_State(string p1) {
			NativeMethods.mdAddrSetPS3553_D3_State(i, p1);
		}

		public void SetPS3553_D3_ZIP(string p1) {
			NativeMethods.mdAddrSetPS3553_D3_ZIP(i, p1);
		}

		public string GetFormPS3553() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetFormPS3553(i));
		}

		public bool SaveFormPS3553(string p1) {
			return (NativeMethods.mdAddrSaveFormPS3553(i, p1) != 0);
		}

		public void ResetFormPS3553() {
			NativeMethods.mdAddrResetFormPS3553(i);
		}

		public void ResetFormPS3553Counter() {
			NativeMethods.mdAddrResetFormPS3553Counter(i);
		}

		public void SetStandardizationType(StandardizeMode mode) {
			NativeMethods.mdAddrSetStandardizationType(i, (int)mode);
		}

		public void SetSuiteParseMode(SuiteParseMode mode) {
			NativeMethods.mdAddrSetSuiteParseMode(i, (int)mode);
		}

		public void SetAliasMode(AliasPreserveMode mode) {
			NativeMethods.mdAddrSetAliasMode(i, (int)mode);
		}

		public string GetFormSOA() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetFormSOA(i));
		}

		public void SaveFormSOA(string p1) {
			NativeMethods.mdAddrSaveFormSOA(i, p1);
		}

		public void ResetFormSOA() {
			NativeMethods.mdAddrResetFormSOA(i);
		}

		public void SetSOACustomerInfo(string customerName, string customerAddress) {
			NativeMethods.mdAddrSetSOACustomerInfo(i, customerName, customerAddress);
		}

		public void SetSOACPCNumber(string CPCNumber) {
			NativeMethods.mdAddrSetSOACPCNumber(i, CPCNumber);
		}

		public string GetSOACustomerInfo() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetSOACustomerInfo(i));
		}

		public string GetSOACPCNumber() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetSOACPCNumber(i));
		}

		public int GetSOATotalRecords() {
			return NativeMethods.mdAddrGetSOATotalRecords(i);
		}

		public float GetSOAAAPercentage() {
			return NativeMethods.mdAddrGetSOAAAPercentage(i);
		}

		public string GetSOAAAExpiryDate() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetSOAAAExpiryDate(i));
		}

		public string GetSOASoftwareInfo() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetSOASoftwareInfo(i));
		}

		public string GetSOAErrorString() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetSOAErrorString(i));
		}

		public void SetCompany(string p1) {
			NativeMethods.mdAddrSetCompany(i, p1);
		}

		public void SetLastName(string p1) {
			NativeMethods.mdAddrSetLastName(i, p1);
		}

		public void SetAddress(string p1) {
			NativeMethods.mdAddrSetAddress(i, p1);
		}

		public void SetAddress2(string p1) {
			NativeMethods.mdAddrSetAddress2(i, p1);
		}

		public void SetLastLine(string p1) {
			NativeMethods.mdAddrSetLastLine(i, p1);
		}

		public void SetSuite(string p1) {
			NativeMethods.mdAddrSetSuite(i, p1);
		}

		public void SetCity(string p1) {
			NativeMethods.mdAddrSetCity(i, p1);
		}

		public void SetState(string p1) {
			NativeMethods.mdAddrSetState(i, p1);
		}

		public void SetZip(string p1) {
			NativeMethods.mdAddrSetZip(i, p1);
		}

		public void SetPlus4(string p1) {
			NativeMethods.mdAddrSetPlus4(i, p1);
		}

		public void SetUrbanization(string p1) {
			NativeMethods.mdAddrSetUrbanization(i, p1);
		}

		public void SetParsedAddressRange(string p1) {
			NativeMethods.mdAddrSetParsedAddressRange(i, p1);
		}

		public void SetParsedPreDirection(string p1) {
			NativeMethods.mdAddrSetParsedPreDirection(i, p1);
		}

		public void SetParsedStreetName(string p1) {
			NativeMethods.mdAddrSetParsedStreetName(i, p1);
		}

		public void SetParsedSuffix(string p1) {
			NativeMethods.mdAddrSetParsedSuffix(i, p1);
		}

		public void SetParsedPostDirection(string p1) {
			NativeMethods.mdAddrSetParsedPostDirection(i, p1);
		}

		public void SetParsedSuiteName(string p1) {
			NativeMethods.mdAddrSetParsedSuiteName(i, p1);
		}

		public void SetParsedSuiteRange(string p1) {
			NativeMethods.mdAddrSetParsedSuiteRange(i, p1);
		}

		public void SetParsedRouteService(string p1) {
			NativeMethods.mdAddrSetParsedRouteService(i, p1);
		}

		public void SetParsedLockBox(string p1) {
			NativeMethods.mdAddrSetParsedLockBox(i, p1);
		}

		public void SetParsedDeliveryInstallation(string p1) {
			NativeMethods.mdAddrSetParsedDeliveryInstallation(i, p1);
		}

		public void SetCountryCode(string p1) {
			NativeMethods.mdAddrSetCountryCode(i, p1);
		}

		public bool VerifyAddress() {
			return (NativeMethods.mdAddrVerifyAddress(i) != 0);
		}

		public string GetCompany() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetCompany(i));
		}

		public string GetLastName() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetLastName(i));
		}

		public string GetAddress() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetAddress(i));
		}

		public string GetAddress2() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetAddress2(i));
		}

		public string GetSuite() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetSuite(i));
		}

		public string GetCity() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetCity(i));
		}

		public string GetCityAbbreviation() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetCityAbbreviation(i));
		}

		public string GetState() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetState(i));
		}

		public string GetZip() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetZip(i));
		}

		public string GetPlus4() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetPlus4(i));
		}

		public string GetCarrierRoute() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetCarrierRoute(i));
		}

		public string GetDeliveryPointCode() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetDeliveryPointCode(i));
		}

		public string GetDeliveryPointCheckDigit() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetDeliveryPointCheckDigit(i));
		}

		public string GetCountyFips() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetCountyFips(i));
		}

		public string GetCountyName() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetCountyName(i));
		}

		public string GetAddressTypeCode() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetAddressTypeCode(i));
		}

		public string GetAddressTypeString() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetAddressTypeString(i));
		}

		public string GetUrbanization() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetUrbanization(i));
		}

		public string GetCongressionalDistrict() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetCongressionalDistrict(i));
		}

		public string GetLACS() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetLACS(i));
		}

		public string GetLACSLinkIndicator() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetLACSLinkIndicator(i));
		}

		public string GetPrivateMailbox() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetPrivateMailbox(i));
		}

		public string GetTimeZoneCode() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetTimeZoneCode(i));
		}

		public string GetTimeZone() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetTimeZone(i));
		}

		public string GetMsa() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetMsa(i));
		}

		public string GetPmsa() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetPmsa(i));
		}

		public string GetDefaultFlagIndicator() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetDefaultFlagIndicator(i));
		}

		public string GetSuiteStatus() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetSuiteStatus(i));
		}

		public string GetEWSFlag() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetEWSFlag(i));
		}

		public string GetCMRA() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetCMRA(i));
		}

		public string GetDsfNoStats() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetDsfNoStats(i));
		}

		public string GetDsfVacant() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetDsfVacant(i));
		}

		public string GetDsfDNA() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetDsfDNA(i));
		}

		public string GetCountryCode() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetCountryCode(i));
		}

		public string GetZipType() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetZipType(i));
		}

		public string GetFalseTable() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetFalseTable(i));
		}

		public string GetDPVFootnotes() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetDPVFootnotes(i));
		}

		public string GetLACSLinkReturnCode() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetLACSLinkReturnCode(i));
		}

		public string GetSuiteLinkReturnCode() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetSuiteLinkReturnCode(i));
		}

		public string GetRBDI() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetRBDI(i));
		}

		public string GetELotNumber() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetELotNumber(i));
		}

		public string GetELotOrder() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetELotOrder(i));
		}

		public string GetAddressKey() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetAddressKey(i));
		}

		public string GetMelissaAddressKey() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetMelissaAddressKey(i));
		}

		public string GetMelissaAddressKeyBase() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetMelissaAddressKeyBase(i));
		}

		public bool FindSuggestion() {
			return (NativeMethods.mdAddrFindSuggestion(i) != 0);
		}

		public bool FindSuggestionNext() {
			return (NativeMethods.mdAddrFindSuggestionNext(i) != 0);
		}

		public int GetPS3553_B6_TotalRecords() {
			return NativeMethods.mdAddrGetPS3553_B6_TotalRecords(i);
		}

		public int GetPS3553_C1a_ZIP4Coded() {
			return NativeMethods.mdAddrGetPS3553_C1a_ZIP4Coded(i);
		}

		public int GetPS3553_C1c_DPBCAssigned() {
			return NativeMethods.mdAddrGetPS3553_C1c_DPBCAssigned(i);
		}

		public int GetPS3553_C1d_FiveDigitCoded() {
			return NativeMethods.mdAddrGetPS3553_C1d_FiveDigitCoded(i);
		}

		public int GetPS3553_C1e_CRRTCoded() {
			return NativeMethods.mdAddrGetPS3553_C1e_CRRTCoded(i);
		}

		public int GetPS3553_C1f_eLOTAssigned() {
			return NativeMethods.mdAddrGetPS3553_C1f_eLOTAssigned(i);
		}

		public int GetPS3553_E_HighRiseDefault() {
			return NativeMethods.mdAddrGetPS3553_E_HighRiseDefault(i);
		}

		public int GetPS3553_E_HighRiseExact() {
			return NativeMethods.mdAddrGetPS3553_E_HighRiseExact(i);
		}

		public int GetPS3553_E_RuralRouteDefault() {
			return NativeMethods.mdAddrGetPS3553_E_RuralRouteDefault(i);
		}

		public int GetPS3553_E_RuralRouteExact() {
			return NativeMethods.mdAddrGetPS3553_E_RuralRouteExact(i);
		}

		public int GetZip4HRDefault() {
			return NativeMethods.mdAddrGetZip4HRDefault(i);
		}

		public int GetZip4HRExact() {
			return NativeMethods.mdAddrGetZip4HRExact(i);
		}

		public int GetZip4RRDefault() {
			return NativeMethods.mdAddrGetZip4RRDefault(i);
		}

		public int GetZip4RRExact() {
			return NativeMethods.mdAddrGetZip4RRExact(i);
		}

		public int GetPS3553_E_LACSCount() {
			return NativeMethods.mdAddrGetPS3553_E_LACSCount(i);
		}

		public int GetPS3553_E_EWSCount() {
			return NativeMethods.mdAddrGetPS3553_E_EWSCount(i);
		}

		public int GetPS3553_E_DPVCount() {
			return NativeMethods.mdAddrGetPS3553_E_DPVCount(i);
		}

		public int GetPS3553_X_POBoxCount() {
			return NativeMethods.mdAddrGetPS3553_X_POBoxCount(i);
		}

		public int GetPS3553_X_HCExactCount() {
			return NativeMethods.mdAddrGetPS3553_X_HCExactCount(i);
		}

		public int GetPS3553_X_FirmCount() {
			return NativeMethods.mdAddrGetPS3553_X_FirmCount(i);
		}

		public int GetPS3553_X_GenDeliveryCount() {
			return NativeMethods.mdAddrGetPS3553_X_GenDeliveryCount(i);
		}

		public int GetPS3553_X_MilitaryZipCount() {
			return NativeMethods.mdAddrGetPS3553_X_MilitaryZipCount(i);
		}

		public int GetPS3553_X_NonDeliveryCount() {
			return NativeMethods.mdAddrGetPS3553_X_NonDeliveryCount(i);
		}

		public int GetPS3553_X_StreetCount() {
			return NativeMethods.mdAddrGetPS3553_X_StreetCount(i);
		}

		public int GetPS3553_X_HCDefaultCount() {
			return NativeMethods.mdAddrGetPS3553_X_HCDefaultCount(i);
		}

		public int GetPS3553_X_OtherCount() {
			return NativeMethods.mdAddrGetPS3553_X_OtherCount(i);
		}

		public int GetPS3553_X_LacsLinkCodeACount() {
			return NativeMethods.mdAddrGetPS3553_X_LacsLinkCodeACount(i);
		}

		public int GetPS3553_X_LacsLinkCode00Count() {
			return NativeMethods.mdAddrGetPS3553_X_LacsLinkCode00Count(i);
		}

		public int GetPS3553_X_LacsLinkCode14Count() {
			return NativeMethods.mdAddrGetPS3553_X_LacsLinkCode14Count(i);
		}

		public int GetPS3553_X_LacsLinkCode92Count() {
			return NativeMethods.mdAddrGetPS3553_X_LacsLinkCode92Count(i);
		}

		public int GetPS3553_X_LacsLinkCode09Count() {
			return NativeMethods.mdAddrGetPS3553_X_LacsLinkCode09Count(i);
		}

		public int GetPS3553_X_SuiteLinkCodeACount() {
			return NativeMethods.mdAddrGetPS3553_X_SuiteLinkCodeACount(i);
		}

		public int GetPS3553_X_SuiteLinkCode00Count() {
			return NativeMethods.mdAddrGetPS3553_X_SuiteLinkCode00Count(i);
		}

		public string GetParsedAddressRange() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetParsedAddressRange(i));
		}

		public string GetParsedPreDirection() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetParsedPreDirection(i));
		}

		public string GetParsedStreetName() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetParsedStreetName(i));
		}

		public string GetParsedSuffix() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetParsedSuffix(i));
		}

		public string GetParsedPostDirection() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetParsedPostDirection(i));
		}

		public string GetParsedSuiteName() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetParsedSuiteName(i));
		}

		public string GetParsedSuiteRange() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetParsedSuiteRange(i));
		}

		public string GetParsedPrivateMailboxName() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetParsedPrivateMailboxName(i));
		}

		public string GetParsedPrivateMailboxNumber() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetParsedPrivateMailboxNumber(i));
		}

		public string GetParsedGarbage() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetParsedGarbage(i));
		}

		public string GetParsedRouteService() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetParsedRouteService(i));
		}

		public string GetParsedLockBox() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetParsedLockBox(i));
		}

		public string GetParsedDeliveryInstallation() {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetParsedDeliveryInstallation(i));
		}

		public void SetReserved(string p1, string p2) {
			NativeMethods.mdAddrSetReserved(i, p1, p2);
		}

		public string GetReserved(string p1) {
			return Marshal.PtrToStringAnsi(NativeMethods.mdAddrGetReserved(i, p1));
		}
	}
}
