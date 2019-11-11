using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace CreditIndicator.Contracts.Interfaces
{
    [ServiceContract()]
    public interface IDataIndicatorService
    {
        /// <summary>
        /// Performs Finding of Cash flow ration under a certin Date Range (start date and end date)
        /// </summary>
        /// <param name="StartDate">Date range start value</param>
        /// <param name="EndDate">Date range end value</param>
        /// <returns></returns>
        [OperationContract]
        decimal GetCreditFlow(long StartDate, long EndDate);
        /// <summary>
        /// Performs fetching total assets under certin Date Range (start date and end date)
        /// </summary>
        /// <param name="StartDate">Date range start value</param>
        /// <param name="EndDate">Date range end value</param>
        /// <returns></returns>
        [OperationContract]
        decimal GetTotalAssets(long StartDate, long EndDate);
        /// <summary>
        /// Getting MCap average under certin Date Range (start date and end date)
        /// </summary>
        /// <param name="StartDate">Date range start value</param>
        /// <param name="EndDate">Date range end value</param>
        /// <param name="NumberOfDays">Average Mcap of last n days</param>
        /// <returns></returns>
        [OperationContract]
        decimal GetMcapAverage(long StartDate, long EndDate, int NumberOfDays);
        /// <summary>
        /// calculates how many dates in a date range that are available as a record in database
        /// with its property "In Universe" is true and exceed the percentage of 90% of the available dates
        /// </summary>
        /// <param name="StartDate">Date range start value</param>
        /// <param name="EndDate">end range start value</param>
        /// <param name="ItemId">records with this item id to be calculated </param>
        /// <returns></returns>
        [OperationContract]
        decimal GetAssetDatesCoverage(long StartDate, long EndDate, int ItemId);
        /// <summary>
        /// determines the company type if non-Financial or Financial
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool GetCompanyType();
        /// <summary>
        /// Performs Getting Operating Income under a certin Date Range (start date and end date)
        /// </summary>
        /// <param name="StartDate">Date range start value</param>
        /// <param name="EndDate">Date range end value</param>
        /// <returns></returns>
        [OperationContract]
        decimal GetOperatingIncome(long StartDate, long EndDate);
        /// <summary>
        /// saves indicator value under item id 900 in num table
        /// </summary>
        [OperationContract]
        void SaveIndicatorValue(long StartDate, long EndDate);
    }
}
