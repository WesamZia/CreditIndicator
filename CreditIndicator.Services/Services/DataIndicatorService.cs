using CreditIndicator.Contracts.Interfaces;
using CreditIndicator.Services.Processes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditIndicator.Services.Services
{
    public class DataIndicatorService : IDataIndicatorService
    {
        public decimal GetCreditFlow(long StartDate, long EndDate)
        {
            PGetCreditFlow _service = new PGetCreditFlow();
            return _service.Process(StartDate, EndDate);
        }

        public decimal GetTotalAssets(long StartDate, long EndDate)
        {
            PGetTotalAssets _service = new PGetTotalAssets();
            return _service.Process(StartDate, EndDate);
        }
        public decimal GetMcapAverage(long StartDate, long EndDate, int NumberOfDays)
        {
            PGetMcapAverage _service = new PGetMcapAverage();
            return _service.Process(StartDate, EndDate, NumberOfDays);
        }

        public decimal GetAssetDatesCoverage(long StartDate, long EndDate, int ItemId)
        {
            PGetAssetDatesCoverage _service = new PGetAssetDatesCoverage();
            return _service.Process(StartDate, EndDate, ItemId);
        }
        public bool GetCompanyType()
        {
            PGetCompanyType _service = new PGetCompanyType();
            return _service.Process();
        }

        public decimal GetOperatingIncome(long StartDate, long EndDate)
        {
            PGetOperatingIncome _service = new PGetOperatingIncome();
            return _service.Process(StartDate, EndDate);
        }

        public void SaveIndicatorValue(long StartDate, long EndDate)
        {
            PSaveIndicatorValue _service = new PSaveIndicatorValue();
            _service.Process(StartDate, EndDate);
        }
    }
}
