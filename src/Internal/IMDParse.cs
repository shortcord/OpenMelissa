using System;

namespace OpenMelissa.Internal
{
    internal interface IMDParse : IDisposable
    {
        ProgramStatus Initialize(string p1);
        string GetBuildNumber();
        void Parse(string p1);
        void ParseCanadian(string p1);
        bool ParseNext();
        void LastLineParse(string p1);
        string GetZip();
        string GetPlus4();
        string GetCity();
        string GetState();
        string GetStreetName();
        string GetRange();
        string GetPreDirection();
        string GetPostDirection();
        string GetSuffix();
        string GetSuiteName();
        string GetSuiteNumber();
        string GetPrivateMailboxNumber();
        string GetPrivateMailboxName();
        string GetGarbage();
        string GetRouteService();
        string GetDeliveryInstallation();
        string GetLockBox();
        int ParseRule();
    }
}