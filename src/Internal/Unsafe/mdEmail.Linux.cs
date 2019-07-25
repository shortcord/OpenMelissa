using OpenMelissa.Internal;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace OpenMelissa
{
    internal class mdEmailLinux : IDisposable, IMDEmail
    {
        private readonly IntPtr i;

        [SuppressUnmanagedCodeSecurity]
        private class NativeMethods
        {
            const string LibName = "libmdEmail";

            [DllImport(LibName, EntryPoint = "mdEmailCreate", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailCreate();
            [DllImport(LibName, EntryPoint = "mdEmailDestroy", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdEmailDestroy(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailSetLicenseString", CallingConvention = CallingConvention.Cdecl)]
            public static extern Int32 mdEmailSetLicenseString(IntPtr i, string License);
            [DllImport(LibName, EntryPoint = "mdEmailSetPathToEmailFiles", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdEmailSetPathToEmailFiles(IntPtr i, string emailDataFiles);
            [DllImport(LibName, EntryPoint = "mdEmailInitializeDataFiles", CallingConvention = CallingConvention.Cdecl)]
            public static extern Int32 mdEmailInitializeDataFiles(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetInitializeErrorString", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetInitializeErrorString(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetBuildNumber", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetBuildNumber(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetDatabaseDate", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetDatabaseDate(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetDatabaseExpirationDate", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetDatabaseExpirationDate(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetLicenseStringExpirationDate", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetLicenseStringExpirationDate(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailVerifyEmail", CallingConvention = CallingConvention.Cdecl)]
            public static extern Int32 mdEmailVerifyEmail(IntPtr i, string email);
            [DllImport(LibName, EntryPoint = "mdEmailSetCorrectSyntax", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdEmailSetCorrectSyntax(IntPtr i, Int32 p1);
            [DllImport(LibName, EntryPoint = "mdEmailSetUpdateDomain", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdEmailSetUpdateDomain(IntPtr i, Int32 p1);
            [DllImport(LibName, EntryPoint = "mdEmailSetDatabaseLookup", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdEmailSetDatabaseLookup(IntPtr i, Int32 p1);
            [DllImport(LibName, EntryPoint = "mdEmailSetFuzzyLookup", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdEmailSetFuzzyLookup(IntPtr i, Int32 p1);
            [DllImport(LibName, EntryPoint = "mdEmailSetWSLookup", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdEmailSetWSLookup(IntPtr i, Int32 p1);
            [DllImport(LibName, EntryPoint = "mdEmailSetWSMailboxLookup", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdEmailSetWSMailboxLookup(IntPtr i, Int32 mailboxLookupmode);
            [DllImport(LibName, EntryPoint = "mdEmailSetMXLookup", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdEmailSetMXLookup(IntPtr i, Int32 p1);
            [DllImport(LibName, EntryPoint = "mdEmailSetStandardizeCasing", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdEmailSetStandardizeCasing(IntPtr i, Int32 p1);
            [DllImport(LibName, EntryPoint = "mdEmailGetStatusCode", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetStatusCode(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetErrorCode", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetErrorCode(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetErrorString", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetErrorString(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetChangeCode", CallingConvention = CallingConvention.Cdecl)]
            public static extern UInt32 mdEmailGetChangeCode(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetResults", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetResults(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetResultCodeDescription", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetResultCodeDescription(IntPtr i, string resultCode, Int32 opt);
            [DllImport(LibName, EntryPoint = "mdEmailGetMailBoxName", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetMailBoxName(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetDomainName", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetDomainName(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetTopLevelDomain", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetTopLevelDomain(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetTopLevelDomainDescription", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetTopLevelDomainDescription(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailGetEmailAddress", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetEmailAddress(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdEmailSetReserved", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdEmailSetReserved(IntPtr i, string Property, string Value_);
            [DllImport(LibName, EntryPoint = "mdEmailGetReserved", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdEmailGetReserved(IntPtr i, string Property_);
            [DllImport(LibName, EntryPoint = "mdEmailSetCachePath", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdEmailSetCachePath(IntPtr i, string cachePath);
            [DllImport(LibName, EntryPoint = "mdEmailSetCacheUse", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdEmailSetCacheUse(IntPtr i, Int32 cacheUse);
        }

        public mdEmailLinux()
        {
            i = NativeMethods.mdEmailCreate();
        }

        public virtual void Dispose()
        {
            lock (this)
            {
                NativeMethods.mdEmailDestroy(i);
                GC.SuppressFinalize(this);
            }
        }

        public bool SetLicenseString(string License)
        {
            return (NativeMethods.mdEmailSetLicenseString(i, License) != 0);
        }

        public void SetPathToEmailFiles(string emailDataFiles)
        {
            NativeMethods.mdEmailSetPathToEmailFiles(i, emailDataFiles);
        }

        public ProgramStatus InitializeDataFiles()
        {
            return (ProgramStatus)NativeMethods.mdEmailInitializeDataFiles(i);
        }

        public string GetInitializeErrorString()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetInitializeErrorString(i));
        }

        public string GetBuildNumber()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetBuildNumber(i));
        }

        public string GetDatabaseDate()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetDatabaseDate(i));
        }

        public string GetDatabaseExpirationDate()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetDatabaseExpirationDate(i));
        }

        public string GetLicenseStringExpirationDate()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetLicenseStringExpirationDate(i));
        }

        public bool VerifyEmail(string email)
        {
            return (NativeMethods.mdEmailVerifyEmail(i, email) != 0);
        }

        public void SetCorrectSyntax(bool p1)
        {
            NativeMethods.mdEmailSetCorrectSyntax(i, (p1 ? 1 : 0));
        }

        public void SetUpdateDomain(bool p1)
        {
            NativeMethods.mdEmailSetUpdateDomain(i, (p1 ? 1 : 0));
        }

        public void SetDatabaseLookup(bool p1)
        {
            NativeMethods.mdEmailSetDatabaseLookup(i, (p1 ? 1 : 0));
        }

        public void SetFuzzyLookup(bool p1)
        {
            NativeMethods.mdEmailSetFuzzyLookup(i, (p1 ? 1 : 0));
        }

        public void SetWSLookup(bool p1)
        {
            NativeMethods.mdEmailSetWSLookup(i, (p1 ? 1 : 0));
        }

        public void SetWSMailboxLookup(MailboxLookupMode mailboxLookupmode)
        {
            NativeMethods.mdEmailSetWSMailboxLookup(i, (int)mailboxLookupmode);
        }

        public void SetMXLookup(bool p1)
        {
            NativeMethods.mdEmailSetMXLookup(i, (p1 ? 1 : 0));
        }

        public void SetStandardizeCasing(bool p1)
        {
            NativeMethods.mdEmailSetStandardizeCasing(i, (p1 ? 1 : 0));
        }

        public string GetStatusCode()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetStatusCode(i));
        }

        public string GetErrorCode()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetErrorCode(i));
        }

        public string GetErrorString()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetErrorString(i));
        }

        public uint GetChangeCode()
        {
            return NativeMethods.mdEmailGetChangeCode(i);
        }

        public string GetResults()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetResults(i));
        }

        public string GetResultCodeDescription(string resultCode, ResultCodeDescriptionOption opt)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetResultCodeDescription(i, resultCode, (int)opt));
        }

        public string GetResultCodeDescription(string resultCode)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetResultCodeDescription(i, resultCode, (int)ResultCodeDescriptionOption.ResultCodeDescriptionLong));
        }

        public string GetMailBoxName()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetMailBoxName(i));
        }

        public string GetDomainName()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetDomainName(i));
        }

        public string GetTopLevelDomain()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetTopLevelDomain(i));
        }

        public string GetTopLevelDomainDescription()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetTopLevelDomainDescription(i));
        }

        public string GetEmailAddress()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetEmailAddress(i));
        }

        public void SetReserved(string Property, string Value_)
        {
            NativeMethods.mdEmailSetReserved(i, Property, Value_);
        }

        public string GetReserved(string Property_)
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdEmailGetReserved(i, Property_));
        }

        public void SetCachePath(string cachePath)
        {
            NativeMethods.mdEmailSetCachePath(i, cachePath);
        }

        public void SetCacheUse(int cacheUse)
        {
            NativeMethods.mdEmailSetCacheUse(i, cacheUse);
        }
    }
}
