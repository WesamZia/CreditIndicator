using CreditIndicator.Contracts.Models;
using System.Data.Entity.ModelConfiguration;

namespace CreditIndicator.DAL.FluentAPIMappers
{
    public class DigitMapper : EntityTypeConfiguration<DigitModel>
    {
        public void NumMapper()
        {
            ToTable("Num");
            HasKey(o => o.Id);
        }
    }
}
