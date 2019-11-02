using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CreditIndicator.Contracts.Models
{
    public class FeatureModel
    {
        private string assetNumber;
        private bool inInventory;
        private int id;

        [Key]
        public int Id { get => id; set => id = value; }

        public long AcquireDate { get; set; }

        [DefaultValue("")]
        public string AssetNumber { get => assetNumber; set => assetNumber = value; }

        [DefaultValue(0)]
        public bool InInventory { get => inInventory; set => inInventory = value; }
    }
}
