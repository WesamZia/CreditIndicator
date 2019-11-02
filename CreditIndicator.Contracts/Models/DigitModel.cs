using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CreditIndicator.Contracts.Models
{
    public class DigitModel
    {
        public int Id { get; set; }

        public long AcquireDate { get; set; }

        public int ItemCode { get; set; }

        [DefaultValue("")]
        public string AssetNumber { get; set; }

        [DefaultValue(null)]
        public decimal ItemValue { get; set; }

        [DefaultValue(0)]
        public bool IsFinancial { get; set; }
    }
}
