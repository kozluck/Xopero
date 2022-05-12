using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.models
{
    public class Fulltime : Contract
    {
        public Fulltime(double monthlyRate = 0, int overtimeAmount = 0)
        {
            if (monthlyRate == 0)
                this.monthlyRate = 4600;
            else
                this.monthlyRate = monthlyRate;

            this.overtimeAmount = overtimeAmount;
        }

        public override double Salary()
        {
            return this.monthlyRate + this.overtimeAmount * (monthlyRate / 60);
        }
    }
}
