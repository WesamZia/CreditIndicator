using CreditIndicator.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreditIndicator.Services.Processes
{
    public class PGetTotalAssets
    {
        private readonly ExceptionLogger logger = new ExceptionLogger();
        public static string executionStatus = string.Empty;

        private long _startDate;
        public long StartDate { set => _startDate = value; }

        private long _endDate;
        public long EndDate { set => _endDate = value; }

        public decimal Process(long StartDate, long EndDate)
        {
            var ItemId = new int();
            var TotalAssets = new decimal();
            var DateRangePercentage = new decimal();
            ItemId = 93;

            try
            {
                DateRangePercentage = DBModelHelper.GetDatesCoveragePercentage(StartDate, EndDate, ItemId);
                // makes sure assets which are in the universe (InUniverse = 1) are at least for 90% of the dates in the date range
                if (DateRangePercentage >= .90m)
                {// find Val list for records and sums there value
                    var TotalAssetRecordsList = DBModelHelper.GetItemValue(ItemId, StartDate, EndDate);
                    TotalAssets = TotalAssetRecordsList.Sum(item => item.ItemValue);
                }

            }
            catch (Exception ex)
            {
                logger.Handle(ex.ToString(), executionStatus);
                throw new ApplicationException("PGetTotalAssets :: Exception occured", ex);
            }

            return TotalAssets;
        }
    }
}
