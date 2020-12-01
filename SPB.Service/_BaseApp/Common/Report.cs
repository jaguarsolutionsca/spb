using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Common
{
    public enum ReportFormat
    {
        Excel,
        Pdf,
        Word
    }

    public class ReportResult
    {
        public byte[] bytes { get; set; }
        public string mimeType { get; set; }
    }
}
