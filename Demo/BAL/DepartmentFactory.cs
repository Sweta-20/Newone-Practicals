using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public class DepartmentFactory
    {
        public IOvertimePay Getobj(string DeptName)
        {
            switch (DeptName)
            {
                case "IT":
                    return new ITOverTimePay();
                case "HR":
                    return new HROverTimePay();
                case "Admin":
                    return new AdminOverTimePay();
                case "Sales":
                    return new SalesOvertimePay();
                case "On-Site":
                    return new OnSiteOverTimePay();
                default:
                    return null;

            }
        }
    }
}
