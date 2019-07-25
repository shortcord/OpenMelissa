using System;

namespace OpenMelissa.Models
{
    public class RBDIStatusCode : IEquatable<RBDIStatusCode>
    {
        public RBDIStatusCode() { }
        public RBDIStatusCode(string code)
        {
            if (code == "R")
            {
                Status = "Residential";
                Code = "R";
            }
            else if (code == "B")
            {
                Status = "Business";
                Code = "B";
            }
            else
            {
                Status = "Unknown";
                Code = "U";
            }
        }

        public string Code { get; set; }
        public string Status { get; set; }

        public bool Equals(RBDIStatusCode other)
        {
            return Code == other.Code &&
                Status == other.Status;
        }
    }
}
