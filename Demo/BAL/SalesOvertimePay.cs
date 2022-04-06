using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class SalesOvertimePay : IOvertimePay
    {
        public int MyOverTimePay(int hour)
        {
            int departmentpay = 100;
            return hour * departmentpay;
        }
    }
}
