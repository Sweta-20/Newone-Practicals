using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class HROverTimePay : IOvertimePay
    {
        public int MyOverTimePay(int hour)
        {
            int departmentpay = 300;
            return hour * departmentpay;
        }
    }
}
