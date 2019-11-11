using CreditIndicator.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace CreditIndicator.DAL.FluentAPIMappers
{
    class FeatureMapper : EntityTypeConfiguration<FeatureModel>
    {
        public void PropertyMapper()
        {
            ToTable("Property");
            HasKey(o => o.Id);
        }
    }
}
