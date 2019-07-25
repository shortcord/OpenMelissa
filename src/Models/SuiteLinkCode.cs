using System;

namespace OpenMelissa.Models
{
    public class SuiteLinkCode : IEquatable<SuiteLinkCode>
    {
        public SuiteLinkCode() { }
        public SuiteLinkCode(string statusCode)
        {
            if (string.IsNullOrWhiteSpace(statusCode))
            {
                Matched = false;
            }
            else if (statusCode == "A")
            {
                Matched = true;
                Code = "A";
            }
            else if (statusCode == "00")
            {
                Matched = false;
                Code = "00";
            }
        }

        public bool Matched { get; set; }
        public string Code { get; set; }

        public bool Equals(SuiteLinkCode other)
        {
            return Matched == other.Matched &&
                Code == other.Code;
        }
    }
}
