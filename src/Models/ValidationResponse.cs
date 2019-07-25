using System.Collections.Generic;

namespace OpenMelissa.Models
{
    public sealed class ValidationResponse<T> where T: class
    {
        internal ValidationResponse() { }

        public T Data { get; internal set; }
        public HashSet<ResultMessage> StatusCodes { get; internal set; }
        public bool IsValid { get; internal set; }
        public BuildInfo BuildInfo { get; internal set; }
    }
}
