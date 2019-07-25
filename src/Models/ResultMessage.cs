using System;

namespace OpenMelissa.Models
{
    /// <summary>
    /// <para>Melissa Data result code mapping object.</para>
    /// See <see cref="Helpers.GetParsedResultCodes(Internal.IResultCode)"/>
    /// </summary>
    public sealed class ResultMessage: IEquatable<ResultMessage>
    {
        internal ResultMessage() { }

        /// <summary>
        /// The Melissa data result code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// A short description of this code
        /// </summary>
        public string ShortDesc { get; set; }
        /// <summary>
        /// A more detailed description of this code
        /// </summary>
        public string LongDesc { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as ResultMessage;
            if (item == null)
                return false;

            return item.Code.Equals(Code);
        }

        public bool Equals(ResultMessage other)
        {
            return other.Code.Equals(Code);
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }
}
