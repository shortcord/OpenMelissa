using System;

namespace OpenMelissa.Models
{
    public class EmailAddress : IEquatable<EmailAddress>
    {
        public EmailAddress() { }

        public EmailAddress(string address)
        {
            Address = address;

            var splits = address.Split('@', StringSplitOptions.RemoveEmptyEntries);
            Mailbox = splits[0];
            Domain = splits[1];
        }

        public string Domain { get; set; }
        public string Mailbox { get; set; }
        public string Address { get; set; }

        public bool Equals(EmailAddress other)
        {
            return other.Domain.Equals(Domain)
                && other.Mailbox.Equals(Mailbox)
                && other.Address.Equals(Address);
        }

        public override string ToString()
        {
            return Address;
        }
    }
}
