using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_21_Singleton_
{
    public class Singleton
    {
        private static Singleton instance = new Singleton();
        private Singleton() { }
        public static Singleton GetInstance
        {
            get
            {
                return instance;
            }
        }
    }
}
