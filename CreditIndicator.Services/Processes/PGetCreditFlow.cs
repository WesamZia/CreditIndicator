using CreditIndicator.Contracts.Models;
using CreditIndicator.DAL;
using CreditIndicator.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreditIndicator.Services.Processes
{
    public class PGetCreditFlow
    {
        private ExceptionLogger logger = new ExceptionLogger();
        public static string executionStatus = string.Empty;

        private long _startDate;

        internal decimal Process(long startDate, long endDate)
        {
            throw new NotImplementedException();
        }

        public long StartDate { set { _startDate = value; } }

        private long _endDate;
        public long EndDate { set { _endDate = value; } }

        private int _itemId;
        public int ItemId { set { _itemId = value; } }

        public decimal Process(long StartDate, long EndDate, int ItemId)
        {
            var ListOfDates = new List<long>();
            var percentageCoverd = new Decimal();
            var ListOfAssets = new List<string>();
            var ListOfAssetsInRange = new List<FeatureModel>();
            var AssetsInUniverseList = new List<FeatureModel>();
            try
            {
                using (var _DB = new DBEntity())
                {
                    ListOfDates = DBModelHelper.GetDatesInDateRange(StartDate, EndDate);

                    // get Assets Using ItemId , that is to be checked from Proprty table that only has assetid
                    ListOfAssets = _DB.Digits.Where(o => o.ItemCode == ItemId).Select(o => o.AssetNumber).ToList();

                    // get all assets under the date range dates , along with the ids brought from the list above "ListOfAssets"
                    ListOfAssetsInRange = _DB.Features.Where(o => ListOfAssets.Contains(o.AssetNumber) && ListOfDates.Contains(o.AcquireDate)).ToList();

                    //total assets that under date range and are in Universe(InUniverse = true in num table)
                    AssetsInUniverseList = ListOfAssetsInRange.Where(o => o.InInventory == true).ToList();

                    // total dates in date range that are actully in DB as well
                    var totalDatesInDateRange = ListOfAssetsInRange.Count;

                    // total assets under available dates from the date range that are  InUniverse == True
                    var TotalAssetsInUniverseCount = AssetsInUniverseList.Count;

                    // percentage of InUniverse assets in the daterange
                    //(used to makes sure assets which are in the universe are at least for 90% of the dates in the date range)
                    decimal NumberOfTotalAssetsInUniverse = TotalAssetsInUniverseCount;
                    decimal NumberOftotalDates = totalDatesInDateRange;
                    percentageCoverd = (NumberOfTotalAssetsInUniverse / NumberOftotalDates);

                };
            }
            catch (Exception ex)
            {
                logger.Handle(ex.ToString(), executionStatus);
                throw new ApplicationException("PGetAssetDatesCoverage :: Exception occured", ex);
            }
            return percentageCoverd;
        }
    }
}
