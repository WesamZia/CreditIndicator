using CreditIndicator.Contracts.Interfaces;
using CreditIndicator.DAL;
using CreditIndicator.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CreditIndicator.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCreditFlow()
        {
            //Arrange
            IDataIndicatorService _service = new DataIndicatorService();
            var StartDate = new long();
            var EndDate = new long();

            //Act
            StartDate = 20180920;
            EndDate = 20180928;

            //Assert
            Assert.IsNotNull(_service.GetCreditFlow(StartDate, EndDate));
        }

        [TestMethod]
        public void GetTotalAssets()
        {
            //Arrange
            IDataIndicatorService _service = new DataIndicatorService();
            var StartDate = new long();
            var EndDate = new long();

            //Act
            StartDate = 20180920;
            EndDate = 20180928;

            //Assert
            Assert.IsNotNull(_service.GetTotalAssets(StartDate, EndDate));
        }

        [TestMethod]
        public void GetMcapAverage()
        {
            //Arrange
            IDataIndicatorService _service = new DataIndicatorService();
            var StartDate = new long();
            var EndDate = new long();
            var NumberOfDays = new int();

            //Act
            StartDate = 20180920;
            EndDate = 20180928;

            //Assert
            Assert.IsNotNull(_service.GetMcapAverage(StartDate, EndDate, NumberOfDays));
        }

        [TestMethod]
        public void GetAssetDatesCoverage()
        {
            //Arrange
            IDataIndicatorService _service = new DataIndicatorService();
            var StartDate = new long();
            var EndDate = new long();
            var itemId = new int();

            //Act
            StartDate = 20180920;
            EndDate = 20180928;
            itemId = 750;

            //Assert
            Assert.IsNotNull(_service.GetAssetDatesCoverage(StartDate, EndDate, itemId));
        }

        [TestMethod]
        public void GetCompanyType()
        {
            //Arrange
            IDataIndicatorService _service = new DataIndicatorService();

            //Assert
            Assert.IsNotNull(_service.GetCompanyType());
        }

        [TestMethod]
        public void GetOperatingIncome()
        {
            //Arrange
            IDataIndicatorService _service = new DataIndicatorService();
            var StartDate = new long();
            var EndDate = new long();

            //Act
            StartDate = 20180920;
            EndDate = 20180929;

            //Assert
            Assert.IsNotNull(_service.GetOperatingIncome(StartDate, EndDate));
        }

        [TestMethod]
        public void GetAllPropertyData()
        {

            using (var _db = new DBEntity())
            {
                var _Properties = _db.Features.ToList();
                Assert.IsNotNull(_Properties);
            }
        }

        [TestMethod]
        public void GetAllNumData()
        {
            using (var _db = new DBEntity())
            {
                var _Nums = _db.Digits.ToList();
                Assert.IsNotNull(_Nums);
            }
        }
    }
}
