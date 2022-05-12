using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.models
{
    public class Internship : Contract
    {
        public Internship(double monthlyRate = 0, int overtimeAmount = 0)
        {
            if (monthlyRate == 0)
                this.monthlyRate = 2000;
            else
                this.monthlyRate = monthlyRate;
        }

        public override double Salary()
        {
            return this.monthlyRate;
        }
    }
}
