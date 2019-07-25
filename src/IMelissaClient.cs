using OpenMelissa.Models;
using System;

namespace OpenMelissa
{
    public interface IMelissaClient : IDisposable
    {
        AddressObject AddressObject { get; }
        ParseObject ParseObject { get; }
        ValidationResponse<ValidatedAddress> ValidateAddress(Address address);
        ParsedResult ParseUSAddress(Address address);
        ParsedResult ParseCanadianAddress(Address address);
        ValidationResponse<ValidatedEmailAddress> ValidateEmailAddress(EmailAddress emailAddress);
    }
}
