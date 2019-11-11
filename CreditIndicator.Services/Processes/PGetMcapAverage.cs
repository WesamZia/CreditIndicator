using CreditIndicator.Services.Helpers;
using System;
using System.Linq;

namespace CreditIndicator.Services.Processes
{
    public class PGetMcapAverage
    {
        private readonly ExceptionLogger logger = new ExceptionLogger();
        public static string executionStatus = string.Empty;

        private long _startDate;
        public long StartDate { set { _startDate = value; } }

        private long _endDate;
        public long EndDate { set { _endDate = value; } }

        public decimal Process(long StartDate, long EndDate, int NumberOfDays)
        {
            var ItemId = new int();
            var McapAverage = new decimal();
            var DateRangePercentage = new decimal();

            NumberOfDays = 3;
            ItemId = 93;

            try
            {
                DateRangePercentage = DBModelHelper.GetDatesCoveragePercentage(StartDate, EndDate, ItemId);
                // makes sure assets which are in the universe (InUniverse = 1) are at least for 90% of the dates in the date range
                if (DateRangePercentage >= .90m)
                {// find Val list for records and sums there value
                    var McapAverageRecordsList = DBModelHelper.GetItemValue(ItemId, StartDate, EndDate);
                    McapAverage = McapAverageRecordsList.Sum(item => item.ItemValue) / NumberOfDays;
                }
            }
            catch (Exception ex)
            {
                logger.Handle(ex.ToString(), executionStatus);
                throw new ApplicationException("PGetMcapAverage :: Exception occured", ex);
            }

            return McapAverage;
        }
    }
}
