using CreditIndicator.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditIndicator.DAL
{
    public class IndicatorDataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DBEntity>
    {
        protected override void Seed(DBEntity _db)
        {
            var Properties = new List<FeatureModel>
            {
            new FeatureModel{ AcquireDate=20190101,AssetNumber="A00SS1-R",InInventory=true}
            };

            Properties.ForEach(o => _db.Features.Add(o));
            _db.SaveChanges();

            var Digits = new List<DigitModel>
            {
            new DigitModel{ AcquireDate=20190101,ItemCode=350 ,AssetNumber="B00SS1-R",ItemValue=102.0m,IsFinancial=true}
            };

            Digits.ForEach(o => _db.Digits.Add(o));
            _db.SaveChanges();


            base.Seed(_db);
        }
    }
}
