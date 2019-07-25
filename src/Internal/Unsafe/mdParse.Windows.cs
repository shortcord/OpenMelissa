using System;
using System.Runtime.InteropServices;
using System.Security;
using OpenMelissa.Internal;

namespace OpenMelissa
{
    internal class mdParseWindows : IDisposable, IMDParse
    {
        private readonly IntPtr i;

        [SuppressUnmanagedCodeSecurity]
        private class NativeMethods
        {
            const string LibName = "mdAddr";

            [DllImport(LibName, EntryPoint = "mdParseCreate", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseCreate();
            [DllImport(LibName, EntryPoint = "mdParseDestroy", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdParseDestroy(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseInitialize", CallingConvention = CallingConvention.Cdecl)]
            public static extern Int32 mdParseInitialize(IntPtr i, string p1);
            [DllImport(LibName, EntryPoint = "mdParseGetBuildNumber", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetBuildNumber(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseParse", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdParseParse(IntPtr i, string p1);
            [DllImport(LibName, EntryPoint = "mdParseParseCanadian", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdParseParseCanadian(IntPtr i, string p1);
            [DllImport(LibName, EntryPoint = "mdParseParseNext", CallingConvention = CallingConvention.Cdecl)]
            public static extern Int32 mdParseParseNext(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseLastLineParse", CallingConvention = CallingConvention.Cdecl)]
            public static extern void mdParseLastLineParse(IntPtr i, string p1);
            [DllImport(LibName, EntryPoint = "mdParseGetZip", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetZip(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetPlus4", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetPlus4(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetCity", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetCity(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetState", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetState(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetStreetName", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetStreetName(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetRange", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetRange(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetPreDirection", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetPreDirection(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetPostDirection", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetPostDirection(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetSuffix", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetSuffix(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetSuiteName", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetSuiteName(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetSuiteNumber", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetSuiteNumber(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetPrivateMailboxNumber", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetPrivateMailboxNumber(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetPrivateMailboxName", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetPrivateMailboxName(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetGarbage", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetGarbage(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetRouteService", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetRouteService(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetLockBox", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetLockBox(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseGetDeliveryInstallation", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr mdParseGetDeliveryInstallation(IntPtr i);
            [DllImport(LibName, EntryPoint = "mdParseParseRule", CallingConvention = CallingConvention.Cdecl)]
            public static extern Int32 mdParseParseRule(IntPtr i);
        }

        public mdParseWindows()
        {
            i = NativeMethods.mdParseCreate();
        }

        public virtual void Dispose()
        {
            lock (this)
            {
                NativeMethods.mdParseDestroy(i);
                GC.SuppressFinalize(this);
            }
        }

        public ProgramStatus Initialize(string p1)
        {
            return (ProgramStatus)NativeMethods.mdParseInitialize(i, p1);
        }

        public string GetBuildNumber()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetBuildNumber(i));
        }

        public void Parse(string p1)
        {
            NativeMethods.mdParseParse(i, p1);
        }

        public void ParseCanadian(string p1)
        {
            NativeMethods.mdParseParseCanadian(i, p1);
        }

        public bool ParseNext()
        {
            return (NativeMethods.mdParseParseNext(i) != 0);
        }

        public void LastLineParse(string p1)
        {
            NativeMethods.mdParseLastLineParse(i, p1);
        }

        public string GetZip()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetZip(i));
        }

        public string GetPlus4()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetPlus4(i));
        }

        public string GetCity()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetCity(i));
        }

        public string GetState()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetState(i));
        }

        public string GetStreetName()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetStreetName(i));
        }

        public string GetRange()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetRange(i));
        }

        public string GetPreDirection()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetPreDirection(i));
        }

        public string GetPostDirection()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetPostDirection(i));
        }

        public string GetSuffix()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetSuffix(i));
        }

        public string GetSuiteName()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetSuiteName(i));
        }

        public string GetSuiteNumber()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetSuiteNumber(i));
        }

        public string GetPrivateMailboxNumber()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetPrivateMailboxNumber(i));
        }

        public string GetPrivateMailboxName()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetPrivateMailboxName(i));
        }

        public string GetGarbage()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetGarbage(i));
        }

        public string GetRouteService()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetRouteService(i));
        }

        public string GetLockBox()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetLockBox(i));
        }

        public string GetDeliveryInstallation()
        {
            return Marshal.PtrToStringAnsi(NativeMethods.mdParseGetDeliveryInstallation(i));
        }

        public int ParseRule()
        {
            return NativeMethods.mdParseParseRule(i);
        }
    }
}