using System;

namespace Firma.models
{
    public abstract class Contract
    {
        protected double monthlyRate;
        protected int overtimeAmount;

        public abstract double Salary();
    }
}