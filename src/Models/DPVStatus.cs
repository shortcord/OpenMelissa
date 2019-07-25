using System;
using System.Collections.Generic;

namespace OpenMelissa.Models
{
    /// <summary>
    /// Delivery Point Verification
    /// </summary>
    public class DPVStatus : IEquatable<DPVStatus>
    {
        /// <summary>
        /// DPV Check Digit; Used for POSTNET Barcodes
        /// </summary>
        public string CheckDigit { get; set; }

        /// <summary>
        /// DPV Delivery Point code; Used for POSTNET Barcodes
        /// </summary>
        public string Code { get; set; }

        // backing field for Footnotes
        string _footnotes;
        /// <summary>
        /// Shorthand status codes for DPV Results
        /// </summary>
        public string Footnotes
        {
            get { return _footnotes; }
            set { _footnotes = value; OnFootnoteSet(value); }
        }

        /// <summary>
        /// DPV is valid; optimistic
        /// </summary>
        public bool Valid { get; set; } = true; // Optimistic view

        // backing field for Status
        List<string> _status = new List<string>();
        /// <summary>
        /// Collection of DPV status codes.
        /// </summary>
        public IReadOnlyCollection<string> Status => _status.AsReadOnly();

        public DPVStatus() { }
        public DPVStatus(string footnotes, string checkDigit, string code)
        {
            CheckDigit = checkDigit;
            Code = code;
            Footnotes = footnotes;
        }

        /// <summary>
        /// This converts the 6 Char DPV Footnote into something more readable.
        /// This also sets <see cref="Valid"/> to false when we run into an error.
        /// </summary>
        void OnFootnoteSet(string footnotes)
        {
            if (string.IsNullOrWhiteSpace(footnotes))
            {
                // footnote is null, either DPV is disabled or md blewup
                Valid = false;
                _status.Add("Internal Error (Footnote is null)");
                return;
            }
            else if (footnotes.Length > 6)
            {
                // this was caused by too long of a footnote
                Valid = false;
                _status.Add("Internal Error (Too long of a footnote)");
                return;
            }

            List<string> footnote = new List<string>();

            var count = footnotes.Length / 2;
            for (int i = 0; i < count; i++)
                footnote.Add(footnotes.Substring(i * 2, 2));

            foreach (var fnote in footnote)
            {
                switch (fnote)
                {
                    case "AA":
                        _status.Add("Input address matched to the Zip+4 file");
                        break;
                        ;
                    case "A1":
                        _status.Add("Input address not matched to the Zip+4 file");
                        Valid = false;
                        break;
                        ;
                    case "BB":
                        _status.Add("Input address matched to DPV");
                        break;
                        ;
                    case "CC":
                        _status.Add("Primary Number Matched to DPV but Secondary Number not Matched");
                        Valid = false;
                        break;
                        ;
                    case "N1":
                        _status.Add("Primary Number Matched to DPV but Highrise Address Missing Secondary Number");
                        Valid = false;
                        break;
                        ;
                    case "M1":
                        _status.Add("Primary Number Missing");
                        Valid = false;
                        break;
                        ;
                    case "M3":
                        _status.Add("Primary Number Invalid");
                        Valid = false;
                        break;
                        ;
                    case "P1":
                        _status.Add("Address Missing PO, RR, or HC Box number");
                        Valid = false;
                        break;
                        ;
                    case "P3":
                        _status.Add("Address Postal or Rural Route Primary number invalid");
                        Valid = false;
                        break;
                        ;
                    case "RR":
                        _status.Add("Input address matched to CMRA");
                        break;
                        ;
                    case "R1":
                        _status.Add("Address Matched to CMRA but Secondary Number not Present");
                        Valid = false;
                        break;
                        ;
                    case "F1":
                        _status.Add("Address was coded to a military address");
                        break;
                        ;
                    case "G1":
                        _status.Add("Address was coded to a General Delivery address");
                        break;
                        ;
                    case "U1":
                        _status.Add("Address was coded to a unique Zip Code");
                        break;
                        ;
                    case "MA1":
                        _status.Add("Address Not Matched to the ZIP+4 file");
                        Valid = false;
                        break;
                        ;
                    default:
                        _status.Add("General Error");
                        Valid = false;
                        break;
                        ;
                }
            }
        }

        public bool Equals(DPVStatus other)
        {
            return Valid == other.Valid &&
                Code == other.Code &&
                CheckDigit == other.CheckDigit &&
                Footnotes == other.Footnotes;
        }
    }
}
