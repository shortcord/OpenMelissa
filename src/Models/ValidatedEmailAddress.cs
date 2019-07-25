using System;

namespace OpenMelissa.Models
{
    public class ValidatedEmailAddress : EmailAddress, IEquatable<ValidatedEmailAddress>
    {
        public string TLD { get; set; }
        public string TLDType { get; set; }

        public bool Equals(ValidatedEmailAddress other)
        {
            return other.Domain.Equals(Domain)
                && other.Mailbox.Equals(Mailbox)
                && other.Address.Equals(Address)
                && other.TLD.Equals(TLD);
        }

        public override string ToString()
        {
            return Address;
        }
    }
}
