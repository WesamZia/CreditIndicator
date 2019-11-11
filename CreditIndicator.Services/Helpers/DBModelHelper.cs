using CreditIndicator.Contracts.Interfaces;
using CreditIndicator.Contracts.Models;
using CreditIndicator.DAL;
using CreditIndicator.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreditIndicator.Services.Helpers
{
    public static class DBModelHelper
    {
        internal static List<DigitModel> GetItemValue(int ItemID, long StartDate, long EndDate)
        {
            // returns for "Val" feild for a certain itemid
            List<DigitModel> _DigitModelList = new List<DigitModel>();

            using (var _DB = new DBEntity())
            {
                _DigitModelList = _DB.Digits.Where(a => a.ItemCode == ItemID && (a.AcquireDate >= StartDate && a.AcquireDate <= EndDate)).ToList();
            }

            return _DigitModelList;
        }
        internal static decimal GetDatesCoveragePercentage(long StartDate, long EndDate, int ItemID)
        {
            IDataIndicatorService _service = new DataIndicatorService();

            var Percentage = _service.GetAssetDatesCoverage(StartDate, EndDate, ItemID);

            return Percentage;
        }
        internal static List<long> GetDatesInDateRange(long StartDate, long EndDate)
        {
            // extracts all possible dates in a certain daterange(start-end)
            var DatesList = new List<long>();

            DateTime SDate = DateTime.ParseExact(StartDate.ToString(), "yyyyMMdd", null);
            DateTime EDate = DateTime.ParseExact(EndDate.ToString(), "yyyyMMdd", null);

            for (DateTime date = SDate; date <= EDate; date = date.AddDays(1))
            {
                long n = long.Parse(date.ToString("yyyyMMdd"));
                DatesList.Add(n);
            }

            return DatesList.ToList(); ;
        }
    }
}
