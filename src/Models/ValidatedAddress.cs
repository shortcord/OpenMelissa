using System;

namespace OpenMelissa.Models
{
    public class ValidatedAddress : Address, IEquatable<ValidatedAddress>
    {
        public ValidatedAddress() { }

        public ValidatedAddress(Address address)
        {
            Company = address.Company;
            Address1 = address.Address1;
            Address2 = address.Address2;
            Suite = address.Suite;
            City = address.City;
            State = address.State;
            City = address.City;
            State = address.State;
            PostalCode = address.PostalCode;
            Plus4 = address.Plus4;
            LastLine = address.LastLine;
            CountryCode = address.CountryCode;
            Urbanization = address.Urbanization;
        }

        public ValidatedAddress(Address address, bool valid)
            : this(address)
        {
            IsValid = valid;
        }

        /// <summary>
        /// Is this address Valid.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Delivery Number and Order
        /// </summary>
        public ELotOrder ELot { get; set; }
        /// <summary>
        /// Delivery Point Verification Status
        /// </summary>
        public DPVStatus DPVStatus { get; set; }
        /// <summary>
        /// SuiteLink Status
        /// </summary>
        public SuiteLinkCode SuiteLink { get; set; }
        /// <summary>
        /// Residential Business Delivery Indicator
        /// </summary>
        public RBDIStatusCode RBDIStatusCode { get; set; }

        public bool Equals(ValidatedAddress other)
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
                Urbanization == other.Urbanization &&
                ELot == other.ELot &&
                DPVStatus == other.DPVStatus &&
                SuiteLink == other.SuiteLink &&
                RBDIStatusCode == other.RBDIStatusCode &&
                IsValid == other.IsValid;
        }
    }
}
