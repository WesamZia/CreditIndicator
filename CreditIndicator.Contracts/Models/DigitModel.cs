using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CreditIndicator.Contracts.Models
{
    public class DigitModel
    {
        private int id;
        private long acquireDate;
        private int itemCode;
        private string assetNumber;
        private decimal itemValue;
        private bool isFinancial;

        public int Id { get => id; set => id = value; }

        public long AcquireDate { get => acquireDate; set => acquireDate = value; }

        public int ItemCode { get => itemCode; set => itemCode = value; }

        [DefaultValue("")]
        public string AssetNumber { get => assetNumber; set => assetNumber = value; }

        [DefaultValue(null)]
        public decimal ItemValue { get => itemValue; set => itemValue = value; }

        [DefaultValue(0)]
        public bool IsFinancial { get => isFinancial; set => isFinancial = value; }
    }
}
