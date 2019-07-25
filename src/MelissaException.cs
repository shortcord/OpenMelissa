using System;

namespace OpenMelissa
{
    public class MelissaException : Exception
    {
        public MelissaException():
            base() { }

        public MelissaException(string message)
            :base(message) { }

        public MelissaException(string message, Exception innerException)
            :base(message, innerException) { }
    }
}
