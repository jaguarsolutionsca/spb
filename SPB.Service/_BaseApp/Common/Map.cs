using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Common
{
    public enum MapFormat
    {
        Png,
        Jpeg,
    }

    public class MapResult
    {
        public byte[] bytes { get; set; }
        public string mimeType { get; set; }
    }
}