using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class IndoorFactory: AbstractDepartmentFactory
    {
        public IOvertimePay GetFactory(string deptname)
        {
            if (deptname.Equals("IT"))
            {
                return new ITOverTimePay();
            }
            else if (deptname.Equals("HR"))
            {
                return new HROverTimePay();
            }
            return null;
        }
    }
}
