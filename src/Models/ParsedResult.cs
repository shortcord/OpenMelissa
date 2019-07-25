using System.Text;

namespace OpenMelissa.Models
{
    public sealed class ParsedResult
    {
        public string Range { get; set; }
        public string PreDirection { get; set; }
        public string PostDirection { get; set; }
        public string StreetName { get; set; }
        public string Suffix { get; set; }
        public string SuiteName { get; set; }
        public string SuiteNumber { get; set; }
        public string PrivateMailboxName { get; set; }
        public string PrivateMailboxNumber { get; set; }
        public string RouteService { get; set; }
        public string LockBox { get; set; }
        public string DeliveryInstallation { get; set; }
        public string Garbage { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Plus4 { get; set; }

        public Address ToAddress()
        {
            var addressLine1 = new StringBuilder();
            var suiteLine = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(Range))
                addressLine1.AppendFormat("{0} ", Range);

            if (!string.IsNullOrWhiteSpace(PreDirection))
                addressLine1.AppendFormat("{0} ", PreDirection);

            if (!string.IsNullOrWhiteSpace(StreetName))
                addressLine1.AppendFormat("{0} ", StreetName);

            if (!string.IsNullOrWhiteSpace(Suffix))
                addressLine1.AppendFormat("{0} ", Suffix);

            if (!string.IsNullOrWhiteSpace(PostDirection))
                addressLine1.AppendFormat("{0} ", PostDirection);

            suiteLine.AppendFormat("{0} ", SuiteName);
            suiteLine.AppendFormat("{0} ", SuiteNumber);

            return new Address
            {
                Address1 = addressLine1
                    .ToString()
                    .Trim(),
                Suite = suiteLine
                    .ToString()
                    .Trim(),
                City = City,
                State = State,
                PostalCode = PostalCode,
                Plus4 = Plus4
            };
        }
    }
}
