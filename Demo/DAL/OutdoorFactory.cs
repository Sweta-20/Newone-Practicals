using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class OutdoorFactory: AbstractDepartmentFactory
    {
        public IOvertimePay GetFactory(string deptname)
        {
            if (deptname.Equals("Sales"))
            {
                return new SalesOvertimePay();
            }
            else if (deptname.Equals("On-Site"))
            {
                return new OnSiteOverTimePay();
            }
            return null;
        }
    }
}
