using OpenMelissa.Configuration;
using OpenMelissa.Models;

namespace OpenMelissa
{
    public class MelissaClient : IMelissaClient
    {
        #region Object LazyLoaders/Getters

        AddressObject _addressObject;
        ParseObject _parseObject;
        EmailObject _emailObject;

        public AddressObject AddressObject
        {
            get
            {
                if (_addressObject == null)
                    _addressObject = new AddressObject(Config);

                return _addressObject;
            }
        }

        public ParseObject ParseObject
        {
            get
            {
                if (_parseObject == null)
                    _parseObject = new ParseObject(Config);

                return _parseObject;
            }
        }

        public EmailObject EmailObject
        {
            get
            {
                if (_emailObject == null)
                    _emailObject = new EmailObject(Config);

                return _emailObject;
            }
        }

        #endregion

        readonly MelissaClientConfig Config;

        public MelissaClient(MelissaClientConfig config)
        {
            Config = config; 
        }

        /// <summary>
        /// Disposes of the MD Objects.
        /// <para>MD Objects will be recreated on use.</para>
        /// </summary>
        public void ResetObjects()
            => Dispose();

        /// <summary>
        /// Validate an Address.
        /// </summary>
        public ValidationResponse<ValidatedAddress> ValidateAddress(Address address)
            => AddressObject?.ValidateAddress(address);

        /// <summary>
        /// Parses a US Address; Does not validate addresses.
        /// </summary>
        public ParsedResult ParseUSAddress(Address address)
        {
            var addressLine = string.Format("{0} {1} {2}", address.Address1, address.Address2, address.Suite);
            var lastLine = string.Format("{0}{1}{2}", address.City, address.State, address.PostalCode);
            return ParseObject?.ParseUS(addressLine, lastLine);
        }

        /// <summary>
        /// Parses a Canadian Address; Does not validate addresses.
        /// </summary>
        public ParsedResult ParseCanadianAddress(Address address)
        {
            var addressLine = string.Format("{0} {1} {2}", address.Address1, address.Address2, address.Suite);
            var lastLine = string.Format("{0}{1}{2}", address.City, address.State, address.PostalCode);
            return ParseObject?.ParseCanadian(addressLine, lastLine);
        }

        public ValidationResponse<ValidatedEmailAddress> ValidateEmailAddress(EmailAddress emailAddress)
            => EmailObject?.VerifyEmail(emailAddress);

        /// <summary>
        /// Safely dispose of MD Objects.
        /// </summary>
        public void Dispose()
        {
            AddressObject?.Dispose();
            ParseObject?.Dispose();
        }
    }
}
