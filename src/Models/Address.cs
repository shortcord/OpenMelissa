using System;

namespace OpenMelissa.Models
{
    /// <summary>
    /// Interface of a generic processed address
    /// </summary>
    public class Address : IEquatable<Address>
    {
        public Address() { }

        /// <summary>
        /// Company name; if any
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// Address line 1
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// Address Line 2
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// Suite number; if any
        /// </summary>
        public string Suite { get; set; }
        /// <summary>
        /// City Name
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Zip/Postal Code
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// Zip/Postal code +4
        /// </summary>
        public string Plus4 { get; set; }
        /// <summary>
        /// City, State, and Zip/Postal code all in one line
        /// </summary>
        public string LastLine { get; set; }
        /// <summary>
        /// Country code where this address is located
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// <para>For US addresses, only applies to Puerto Rican address.</para>
        /// <para>Used to break ties when a Zip/Postal code is linked to multiple instances of the same address.</para>
        /// </summary>
        public string Urbanization { get; set; }
        /// <summary>
        /// The address key for this address, hashed with SHA1
        /// </summary>
        public string AddressKey 
            => this.GetAddressKey();

        public bool Equals(Address other)
        {
            return Company == other.Company &&
                Address1 == other.Address1 &&
                Address2 == other.Address2 &&
                Suite == other.Suite &&
                City == other.City &&
                State == other.State &&
                PostalCode == other.PostalCode &&
                Plus4 == other.Plus4 &&
                CountryCode == other.CountryCode &&
                Urbanization == other.Urbanization;
        }
    }
}
