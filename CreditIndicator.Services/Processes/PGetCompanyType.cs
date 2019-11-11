using CreditIndicator.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreditIndicator.Services.Processes
{
    public class PGetCompanyType
    {
        public bool Process()
        {
            bool IsFinancial = false;
            var itemId = 356;

            using (var _db = new DBEntity())
            {

                var _Nums = _db.Digits.Where(o => o.ItemCode == itemId).ToList();

                foreach (var numREcord in _Nums)
                {
                    if (numREcord.IsFinancial)
                    {
                        IsFinancial = true;
                        break;
                    }
                }
            }

            return IsFinancial;
        }
    }
}
