using CreditIndicator.Contracts.Interfaces;
using CreditIndicator.Contracts.Models;
using CreditIndicator.DAL;
using CreditIndicator.Services.Helpers;
using CreditIndicator.Services.Services;
using System;

namespace CreditIndicator.Services.Processes
{
    public class PSaveIndicatorValue
    {
        private ExceptionLogger logger = new ExceptionLogger();
        public static string executionStatus = string.Empty;

        private long _startDate;
        public long StartDate { set { _startDate = value; } }

        private long _endDate;
        public long EndDate { set { _endDate = value; } }

        IDataIndicatorService _service = new DataIndicatorService();

        public void Process(long StartDate, long EndDate)
        {
            bool IsFinancial = false;
            decimal Ratio = new decimal();
            decimal TotalAssets = new decimal();
            decimal AverageMcap = new decimal();
            decimal Maximum = new decimal();
            decimal IndicatorVale = new decimal();
            int NumberOfDays = new int();
            DigitModel _numRecord = new DigitModel();

            IsFinancial = _service.GetCompanyType();

            // check if company is Financial or not
            if (IsFinancial)
            { Ratio = _service.GetOperatingIncome(StartDate, EndDate); }
            else
            { Ratio = _service.GetCreditFlow(StartDate, EndDate); }

            //calculate total assets
            TotalAssets = _service.GetTotalAssets(StartDate, EndDate);

            //calculate the Mcap avg for last n days
            AverageMcap = _service.GetMcapAverage(StartDate, EndDate, NumberOfDays);

            // find the max number 
            Maximum = Math.Max(TotalAssets, AverageMcap);

            //run the equation ration / Max(Total Assets,Average Mcap of last n days)
            IndicatorVale = Ratio / Maximum;

            _numRecord.ItemValue = IndicatorVale;
            _numRecord.ItemCode = 900;

            //today's date parsed to "yyyyMMdd" formate
            var TodayDate = DateTime.Now.ToString("yyyyMMdd");
            _numRecord.AcquireDate = long.Parse(TodayDate); ;

            using (var _DB = new DBEntity())
            {
                _DB.Digits.Add(_numRecord);
                _DB.SaveChanges();
            }

        }
    }
}
