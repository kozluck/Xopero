using System;

abstract class Contract
{
    protected double monthlyRate;
    protected int overtimeAmount;

    public abstract double Salary();
}
class Internship : Contract
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

class Fulltime : Contract
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