using System;
using System.Collections.Generic;
using System.Text;

namespace BaseApp.DTO
{
    public class DTO_Summary
    {
        public string title { get; set; }
        public int? prevAuditId { get; set; }
        public int? nextAuditId { get; set; }
        public bool? isBeforeLast { get; set; }
    }
}
