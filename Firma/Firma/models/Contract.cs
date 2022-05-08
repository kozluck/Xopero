using System;

class Contract
{
    private String type;
    private double monthlyRate;
    private int overtimeAmount;



    public Contract(String type, double monthlyRate = 0, int overtimeAmount = 0)
    {
        this.type = type;
        this.type = type;
        if (monthlyRate == 0)
        {
            if (type.Equals("Staż")) this.monthlyRate = 2000;
            if (type.Equals("Etat")) this.monthlyRate = 4600;
        }
        else
            this.monthlyRate = monthlyRate;

        this.overtimeAmount = overtimeAmount;
    }

    public double Salary()
    {
        if (this.getType().Equals("Staż")) return this.getMonthlyRate();
        else return this.getMonthlyRate() + this.getOvertimeAmount() * (this.getMonthlyRate() / 60);
    }


    public String getType() { return this.type; }
    public double getMonthlyRate() { return this.monthlyRate; }
    public int getOvertimeAmount() { return this.overtimeAmount; }
}