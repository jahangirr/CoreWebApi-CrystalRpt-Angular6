using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public string UserName { get; set; }
        public string  ReportName { get; set; }

        public string ReportData { get; set; }

        public DateTime? ReportTime { get; set; } = DateTime.Now;

    }
}