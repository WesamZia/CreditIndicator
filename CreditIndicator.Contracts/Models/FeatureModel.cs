using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CreditIndicator.Contracts.Models
{
    public class FeatureModel
    {
        [Key]
        public int Id { get; set; }

        public long AcquireDate { get; set; }

        [DefaultValue("")]
        public string AssetNumber { get; set; }

        [DefaultValue(0)]
        public bool InInventory { get; set; }
    }
}
