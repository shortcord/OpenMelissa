using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using OpenMelissa.Models;

namespace OpenMelissa
{
    internal static class Helpers
    {
        internal static HashSet<ResultMessage> GetParsedResultCodes(this Internal.IResultCode mdObject)
        {
            var toReturn = new HashSet<ResultMessage>();

            string codes = mdObject.GetResults();

            // if the codes are null then just return an empty hashset
            if (string.IsNullOrWhiteSpace(codes))
                return toReturn;

            var rawCodes = codes
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToHashSet();

            // same here, if the resulting codes count is zero then return an empty hashset
            if (rawCodes.Count == 0)
                return toReturn;

            foreach (var rawCode in rawCodes)
            {
                var shortDescription = mdObject.GetResultCodeDescription(rawCode, ResultCodeDescriptionOption.ResultCodeDescriptionShort);
                var longDescription = mdObject.GetResultCodeDescription(rawCode, ResultCodeDescriptionOption.ResultCodeDescriptionLong);

                var toAdd = new ResultMessage
                {
                    Code = rawCode,
                    ShortDesc = shortDescription,
                    LongDesc = longDescription
                };

                toReturn.Add(toAdd);
            }

            return toReturn;
        }

        internal static string ToSHA1String(this string s)
        {
            using (var sha1 = new SHA1Managed())
            {
                var bytes = Encoding.UTF8.GetBytes(s);
                var hash = sha1.ComputeHash(bytes);
                return string.Concat(hash.Select(x => x.ToString("x2")));
            }
        }

        internal static string GetAddressKey(this Address address)
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(address.Address1))
                sb.Append(address.Address1);

            if (!string.IsNullOrWhiteSpace(address.Address2))
                sb.Append(address.Address2);

            if (!string.IsNullOrWhiteSpace(address.Suite))
                sb.Append(address.Suite);

            if (!string.IsNullOrWhiteSpace(address.City))
                sb.Append(address.City);

            if (!string.IsNullOrWhiteSpace(address.State))
                sb.Append(address.State);

            if (!string.IsNullOrWhiteSpace(address.PostalCode))
                sb.Append(address.PostalCode);

            if (sb.Length == 0)
                return null;

            return sb
                .ToString()
                .ToSHA1String();
        }
    }
}
